using System;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Extensions.ManagedClient;
using MQTTnet.Packets;
using MQTTnet.Protocol;

namespace MQTTClient.Demo
{
    class Program
    {
        private static IManagedMqttClient client;

        static void Main(string[] args)
        {
            StartMQTTClient();
            Subscribe("test");
            Console.ReadKey();
        }

        static async Task StartMQTTClient()
        {
            client = new MqttFactory().CreateManagedMqttClient();
            var clientOptions = new MqttClientOptionsBuilder()
                    .WithClientId("customer_client")
                    .WithCredentials("admin", "1123456")
                    .WithTcpServer("127.0.0.1", 10086)
                ;
            client.ConnectingFailedAsync += async arg =>
            {
                var result = arg.ConnectResult;
                Console.WriteLine(result);
                Console.WriteLine(arg.Exception.Message);
            };
            client.ConnectingFailedAsync += async arg =>
            {
                
            };
            /*client.InternalClient.DisconnectedAsync += args =>
            {
                var reason = args.Reason;
                Console.WriteLine($"连接失败：{reason}");
                /*var reasonString = args.ConnectResult.ReasonString;
                Console.WriteLine($"连接失败：{reasonString}");#1#
                return Task.CompletedTask;
            };*/
            client.InternalClient.ConnectedAsync += arg =>
            {
                var resultCode = arg.ConnectResult.ResultCode;
                if (resultCode == MqttClientConnectResultCode.Success)
                {
                    Console.WriteLine("连接成功");
                }
                else
                {
                    Console.WriteLine("连接失败");
                }

                return Task.CompletedTask;
            };
            var options = new ManagedMqttClientOptionsBuilder()
                .WithClientOptions(clientOptions)
                .Build();
            await client.StartAsync(options);
        }

        static async Task Subscribe(string topic)
        {
            MqttTopicFilter filter = new MqttTopicFilterBuilder()
                .WithTopic(topic)
                // Qos：服务质量
                .WithQualityOfServiceLevel(MqttQualityOfServiceLevel.AtMostOnce)
                .Build();
            await client.SubscribeAsync(new[] { filter });
            var message = new MqttApplicationMessageBuilder()
                .WithTopic("Test.Topic")
                .WithPayload("1234")
                //broker持久化消息，当新客户端订阅主题时，立即收到该主题最后一次的保留消息
                .WithRetainFlag(true)
                .Build();
            client.InternalClient.PublishAsync(message);
        }
    }
}