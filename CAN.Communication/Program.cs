using Kvaser.CanLib;

namespace CAN.Communication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 初始化
            Canlib.canInitializeLibrary();
            // 打开虚拟通道，返回值本质上是托管封装的非托管资源句柄
            // 参数channel相当于Kvaser Device Guide中的Canlib Channel
            // 如果打开失败，返回一个负数
            var handle = Canlib.canOpenChannel(0, Canlib.canOPEN_ACCEPT_VIRTUAL);
            Console.WriteLine(handle);
            // 设置波特率500k，可选操作
            Canlib.canSetBitrate(handle, 500_00);
            // 打开总线
            Canlib.canBusOn(handle);
            var writeMsg = new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05 ,0x06,0x08};
            // 发送
            // 参数flag默认为0，发送实际上都是广播
            Canlib.canWrite(handle, 12, writeMsg, 8, 0);
            // 接收
            var readMsg = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            Canlib.canRead(handle, out int id, readMsg, out int dlc, out int flag, out long time);
            // 接受指定ID的消息
            Canlib.canReadSpecific(handle, 11, readMsg, out dlc, out flag, out time);

            // 关闭
            Canlib.canBusOff(handle);
            Canlib.canClose(handle);
            Canlib.canClose(handle);
        }
    }
}
