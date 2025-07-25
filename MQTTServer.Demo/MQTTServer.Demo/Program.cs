using System;
using System.Net;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client.Receiving;
using MQTTnet.Protocol;
using MQTTnet.Server;

namespace MQTTServer.Demo
{
    class Program
    {
        private static IMqttServer mqttServer = null;

        static void Main(string[] args)
        {
            StartServer();
            Console.WriteLine(">>> MQTT Server启动");
            Console.ReadKey();
        }

        static async Task StartServer()
        {
            mqttServer = new MqttFactory().CreateMqttServer();
            var options = new MqttServerOptionsBuilder()
                .WithDefaultEndpointBoundIPAddress(IPAddress.Any)
                .WithDefaultEndpointPort(10086)
                .WithConnectionValidator(context =>
                {
                    if (!"admin".Equals(context.Username) || !"123456".Equals(context.Password))
                    {
                        context.ReasonCode = MqttConnectReasonCode.BadUserNameOrPassword;
                        context.ReasonString = "用户名密码错误";
                        Console.WriteLine("用户名密码错误");
                        return;
                    }

                    context.ReasonCode = MqttConnectReasonCode.Success;
                }).Build();
            mqttServer.ClientConnectedHandler = new MqttServerClientConnectedHandlerDelegate(handler =>
            {
                Console.WriteLine($">>> 客户端：{handler.ClientId}已连接");
            });
            mqttServer.ClientSubscribedTopicHandler = new MqttServerClientSubscribedTopicHandlerDelegate(arg =>
            {
                var clientId = arg.ClientId;
                var topic = arg.TopicFilter.Topic;
                Console.WriteLine($">>> 客户端：{clientId}订阅了主题：{topic}");
            });
            mqttServer.ApplicationMessageReceivedHandler = new MqttApplicationMessageReceivedHandlerDelegate(
                async arg =>
                {
                    // 接收到的消息（字节数组）
                    // var dataBytes = arg.ApplicationMessage.CorrelationData;
                    // 将消息转成string
                    var clientId = arg.ClientId;
                    var topic = arg.ApplicationMessage.Topic;
                    var data = arg.ApplicationMessage.ConvertPayloadToString();
                    Console.WriteLine($">>> 客户端：{clientId}向主题：{topic}发送消息：{data}");
                    // 这里不需要做任何发布操作，Broker已经自动处理了转发
                    /*var message =
                        await mqttServer.PublishAsync(builder =>
                        {
                            return new MqttApplicationMessageBuilder()
                                .WithTopic(topic)
                                .WithPayload(arg.ApplicationMessage.CorrelationData)
                        });*/
                });
            await mqttServer.StartAsync(options);
        }
    }
}