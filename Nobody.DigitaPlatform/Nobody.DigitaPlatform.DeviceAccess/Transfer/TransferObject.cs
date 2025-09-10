using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nobody.DigitaPlatform.DeviceAccess.Base;
using Nobody.DigitaPlatform.Entities;

namespace Nobody.DigitaPlatform.DeviceAccess.Transfer
{
    internal abstract class TransferObject
    {
        internal List<string> Conditions = new List<string>();

        internal bool ConnectState { get; set; }

        public virtual Result Connect(int tryCount = 30)
        {
            return Result.Failed();
        }

        internal virtual Result Config(List<DevicePropEntity> props)
        {
            return Result.Failed();
        }
        public virtual Result<List<byte>> SendAndReceive(List<byte> readPdu, int len1,int len2, int timeout)
        {
            return new Result<List<byte>>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="readPdu"></param>
        /// <param name="headerLen">报文头长度</param>
        /// <param name="len2"></param>
        /// <param name="timeout"></param>
        /// <param name="calLen">通过报文头计算后续字节长度(不包括报文头长度)</param>
        /// <returns></returns>
        public virtual Result<List<byte>> SendAndReceive(List<byte> readPdu, int headerLen, int len2, int timeout, Func<byte[],int> calLen)
        {
            return new Result<List<byte>>();
        }
        public virtual void Close()
        {
            this.ConnectState = false;
        }
    }
}
