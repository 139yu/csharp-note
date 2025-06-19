using Opc.Ua;
using OpcUaHelper;

namespace OPC.UA.Helper.Test
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            OpcUaClient client = new OpcUaClient();
            client.UserIdentity = new UserIdentity(new AnonymousIdentityToken());
            await client.ConnectServer("opc.tcp://127.0.0.1:49320");
            var val = client.ReadNode<ushort>("ns=2;s=通道 1.设备 1.标记 2");
            Console.WriteLine(val);
        }
    }
}
