using System.Collections.Generic;
using Modbus.Communication.Common;

namespace Modbus.Communication.Component
{
    public interface ICommunicationUnit
    {
        /// <summary>
        /// 连接超时时间
        /// </summary>
        public int ConnectTimeout { get; set; }

        /// <summary>
        /// 打开连接
        /// </summary>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        public Result Open(int timeout);

        /// <summary>
        /// 关闭连接
        /// </summary>
        /// <returns></returns>
        public void Close();
        /// <summary>
        /// 发送并接受数据
        /// </summary>
        /// <param name="requestBytes"></param>
        /// <param name="receiveLen"></param>
        /// <param name="errorLen"></param>
        /// <returns></returns>
        public Result<byte> SendAndReceive(List<byte> requestBytes,int receiveLen,int errorLen);
    }
}