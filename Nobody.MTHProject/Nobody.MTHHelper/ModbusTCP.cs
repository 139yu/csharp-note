using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nobody.MTHHelper
{
    public class ModbusTCP
    {
        #region �ֶ�������
        /// <summary>
        /// ���ͳ�ʱʱ��
        /// </summary>
        public int SendTimeOut { get; set; } = 2000;

        /// <summary>
        /// ���ճ�ʱʱ��
        /// </summary>
        public int ReceiveTimeOut { get; set; } = 2000;

        //����һ��Socket����
        private Socket socket;

        /// <summary>
        ///  ������
        /// </summary>
        private SimpleHybirdLock hybirdLock = new SimpleHybirdLock();

        /// <summary>
        /// ÿ�ν���ǰ��ʱ��ʱ��
        /// </summary>
        public int SleepTime { get; set; } =50;

        /// <summary>
        /// ���ĵȴ�����
        /// </summary>
        public int MaxWaitTimes { get; set; } = 20;

        /// <summary>
        /// ��Ԫ��ʶ��
        /// </summary>
        public byte SlaveId { get; set; } = 0x01;

        #endregion

        #region ����������Ͽ�����
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="ip">IP��ַ</param>
        /// <param name="port">�˿ں�</param>
        /// <returns>���ؽ��</returns>
        public bool Connect(string ip, int port)
        {
            //Socketʵ����
            this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.socket.SendTimeout = SendTimeOut;
            this.socket.ReceiveTimeout = ReceiveTimeOut;

            try
            {
                if (IPAddress.TryParse(ip, out IPAddress ipAddress))
                {
                    this.socket.Connect(ipAddress, port);
                }
                else
                {
                    this.socket.Connect(ip, port);
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// �Ͽ�����
        /// </summary>
        public void DisConnect()
        {
            if (this.socket != null)
            {
                this.socket.Close();
            }
        }

        #endregion

        #region 01H��ȡ�����Ȧ 
        /// <summary>
        /// 01H��ȡ�����Ȧ
        /// </summary>
        /// <param name="start">��ʼ��Ȧ��ַ</param>
        /// <param name="length">��Ȧ����</param>
        /// <returns>��������</returns>
        public byte[] ReadOutputCoils(ushort start, ushort length)
        {
            //��һ����ƴ�ӱ���

            //����һ��ByteArray����
            ByteArray SendCommand = new ByteArray();

            //������ + Э���ʶ + ���� + ��Ԫ��ʶ + ������ + ��ʼ��Ȧ��ַ + ��Ȧ����

            //������ + Э���ʶ
            SendCommand.Add(0x00, 0x00, 0x00, 0x00);

            //���� + ��Ԫ��ʶ  + ������
            SendCommand.Add(0x00, 0x06, SlaveId, 0x01);

            //��ʼ��Ȧ��ַ + ��Ȧ����
            SendCommand.Add(start);
            SendCommand.Add(length);

            byte[] receive = null;

            int byteLength = length % 8 == 0 ? length / 8 : length / 8 + 1;

            //�ڶ��� �����������Ͳ����ձ���
            if (SendAndReceive(SendCommand.Array, ref receive))
            {
                //���Ĳ�����֤����

                if (receive.Length == 9 + byteLength)
                {
                    if (receive[6] == SlaveId && receive[7] == 0x01 && receive[8] == byteLength)
                    {
                        //���岽����������
                        byte[] result = new byte[byteLength];

                        Array.Copy(receive, 9, result, 0, byteLength);

                        return result;
                    }
                }
            }
            return null;
        }
        #endregion

        #region 02H��ȡ������Ȧ 
        /// <summary>
        /// 002H��ȡ������Ȧ 
        /// </summary>
        /// <param name="start">��ʼ��Ȧ��ַ</param>
        /// <param name="length">��Ȧ����</param>
        /// <returns>��������</returns>
        public byte[] ReadInputCoils(ushort start, ushort length)
        {
            //��һ����ƴ�ӱ���

            //����һ��ByteArray����
            ByteArray SendCommand = new ByteArray();

            //������ + Э���ʶ + ���� + ��Ԫ��ʶ + ������ + ��ʼ��Ȧ��ַ + ��Ȧ����

            //������ + Э���ʶ
            SendCommand.Add(0x00, 0x00, 0x00, 0x00);

            //���� + ��Ԫ��ʶ  + ������
            SendCommand.Add(0x00, 0x06, SlaveId, 0x02);

            //��ʼ��Ȧ��ַ + ��Ȧ����
            SendCommand.Add(start);
            SendCommand.Add(length);

            byte[] receive = null;

            int byteLength = length % 8 == 0 ? length / 8 : length / 8 + 1;

            //�ڶ��� �����������Ͳ����ձ���
            if (SendAndReceive(SendCommand.Array, ref receive))
            {
                //���Ĳ�����֤����

                if (receive.Length == 9 + byteLength)
                {
                    if (receive[6] == SlaveId && receive[7] == 0x02 && receive[8] == byteLength)
                    {
                        //���岽����������
                        byte[] result = new byte[byteLength];

                        Array.Copy(receive, 9, result, 0, byteLength);

                        return result;
                    }
                }
            }
            return null;
        }
        #endregion

        #region 03H��ȡ����Ĵ���

        /// <summary>
        /// ��ȡ����Ĵ���
        /// </summary>
        /// <param name="start">��ʼ�Ĵ�����ַ</param>
        /// <param name="length">�Ĵ�������</param>
        /// <returns>�����ֽ�����</returns>
        public byte[] ReadOutputRegisters(ushort start, ushort length)
        {
            //��һ����ƴ�ӱ���

            //����һ��ByteArray����
            ByteArray SendCommand = new ByteArray();

            //������ + Э���ʶ + ���� + ��Ԫ��ʶ + ������ + ��ʼ�Ĵ�����ַ + �Ĵ�������

            //������ + Э���ʶ
            SendCommand.Add(0x00, 0x00, 0x00, 0x00);

            //���� + ��Ԫ��ʶ  + ������
            SendCommand.Add(0x00, 0x06, SlaveId, 0x03);

            //��ʼ�Ĵ�����ַ + �Ĵ�������
            SendCommand.Add(start);
            SendCommand.Add(length);

            byte[] receive = null;

            int byteLength = length * 2;

            //�ڶ��� �����������Ͳ����ձ���
            if (SendAndReceive(SendCommand.Array, ref receive))
            {
                //���Ĳ�����֤����

                if (receive.Length == 9 + byteLength)
                {
                    if (receive[6] == SlaveId && receive[7] == 0x03 && receive[8] == byteLength)
                    {
                        //���岽����������
                        byte[] result = new byte[byteLength];

                        Array.Copy(receive, 9, result, 0, byteLength);

                        return result;
                    }
                }
            }
            return null;
        }

        #endregion

        #region 04H��ȡ����Ĵ���

        /// <summary>
        /// ��ȡ����Ĵ���
        /// </summary>
        /// <param name="start">��ʼ�Ĵ�����ַ</param>
        /// <param name="length">�Ĵ�������</param>
        /// <returns>�����ֽ�����</returns>
        public byte[] ReadInputRegisters(ushort start, ushort length)
        {
            //��һ����ƴ�ӱ���

            //����һ��ByteArray����
            ByteArray SendCommand = new ByteArray();

            //������ + Э���ʶ + ���� + ��Ԫ��ʶ + ������ + ��ʼ�Ĵ�����ַ + �Ĵ�������

            //������ + Э���ʶ
            SendCommand.Add(0x00, 0x00, 0x00, 0x00);

            //���� + ��Ԫ��ʶ  + ������
            SendCommand.Add(0x00, 0x06, SlaveId, 0x04);

            //��ʼ�Ĵ�����ַ + �Ĵ�������
            SendCommand.Add(start);
            SendCommand.Add(length);

            byte[] receive = null;

            int byteLength = length * 2;

            //�ڶ��� �����������Ͳ����ձ���
            if (SendAndReceive(SendCommand.Array, ref receive))
            {
                //���Ĳ�����֤����

                if (receive.Length == 9 + byteLength)
                {
                    if (receive[6] == SlaveId && receive[7] == 0x04 && receive[8] == byteLength)
                    {
                        //���岽����������
                        byte[] result = new byte[byteLength];

                        Array.Copy(receive, 9, result, 0, byteLength);

                        return result;
                    }
                }
            }
            return null;
        }

        #endregion

        #region 05HԤ�õ���Ȧ

        /// <summary>
        /// Ԥ�õ���Ȧ
        /// </summary>
        /// <param name="start">��Ȧ��ַ</param>
        /// <param name="value">��Ȧֵ</param>
        /// <returns>���ؽ��</returns>
        public bool PreSetSingleCoil(ushort start, bool value)
        {
            //��һ����ƴ�ӱ���

            //����һ��ByteArray����
            ByteArray SendCommand = new ByteArray();

            //������ + Э���ʶ + ���� + ��Ԫ��ʶ + ������ + ��Ȧ��ַ + ��Ȧֵ��0xFF 0x00 / 0x00 0x00��

            //������ + Э���ʶ
            SendCommand.Add(0x00, 0x00, 0x00, 0x00);

            //���� + ��Ԫ��ʶ  + ������
            SendCommand.Add(0x00, 0x06, SlaveId, 0x05);

            //��Ȧ��ַ
            SendCommand.Add(start);

            //��Ȧֵ
            SendCommand.Add(value ? (byte)0xFF : (byte)0x00, 0x00);

            byte[] receive = null;

            //�ڶ��� �����������Ͳ����ձ���
            if (SendAndReceive(SendCommand.Array, ref receive))
            {
                //���Ĳ�����֤����
                if (receive.Length == 12)
                {
                    return ByteArrayEquals(SendCommand.Array, receive);
                }
            }
            return false;
        }

        #endregion

        #region 06HԤ�õ��Ĵ���

        /// <summary>
        /// Ԥ�õ��Ĵ���
        /// </summary>
        /// <param name="start">�Ĵ�����ַ</param>
        /// <param name="value">�Ĵ���ֵ</param>
        /// <returns>���ؽ��</returns>
        public bool PreSetSingleRegister(ushort start, byte[] value)
        {
            //��һ����ƴ�ӱ���

            //����һ��ByteArray����
            ByteArray SendCommand = new ByteArray();

            //������ + Э���ʶ + ���� + ��Ԫ��ʶ + ������ + �Ĵ�����ַ + �Ĵ���ֵ

            //������ + Э���ʶ
            SendCommand.Add(0x00, 0x00, 0x00, 0x00);

            //���� + ��Ԫ��ʶ  + ������
            SendCommand.Add(0x00, 0x06, SlaveId, 0x06);

            //�Ĵ�����ַ
            SendCommand.Add(start);

            //�Ĵ���ֵ
            SendCommand.Add(value);

            byte[] receive = null;

            //�ڶ��� �����������Ͳ����ձ���
            if (SendAndReceive(SendCommand.Array, ref receive))
            {
                //���Ĳ�����֤����
                if (receive.Length == 12)
                {
                    return ByteArrayEquals(SendCommand.Array, receive);
                }
            }
            return false;
        }

        /// <summary>
        /// Ԥ�õ��Ĵ���
        /// </summary>
        /// <param name="start">�Ĵ�����ַ</param>
        /// <param name="value">Short����</param>
        /// <returns>���ؽ��</returns>
        public bool PreSetSingleRegister(ushort start, short value)
        {
            return PreSetSingleRegister(start, BitConverter.GetBytes(value).Reverse().ToArray());
        }

        /// <summary>
        /// Ԥ�õ��Ĵ���
        /// </summary>
        /// <param name="start">�Ĵ�����ַ</param>
        /// <param name="value">UShort����</param>
        /// <returns>���ؽ��</returns>
        public bool PreSetSingleRegister(ushort start, ushort value)
        {
            return PreSetSingleRegister(start, BitConverter.GetBytes(value).Reverse().ToArray());
        }

        #endregion

        #region 0FHԤ�ö���Ȧ

        /// <summary>
        /// Ԥ�ö���Ȧ
        /// </summary>
        /// <param name="start">��ʼ��Ȧ��ַ</param>
        /// <param name="value">д��ֵ</param>
        /// <returns>���ؽ��</returns>
        public bool PreSetMultiCoils(ushort start, bool[] value)
        {
            //��һ����ƴ�ӱ���

            //����һ��ByteArray����
            ByteArray SendCommand = new ByteArray();

            byte[] setArray = GetByteArrayFromBoolArray(value);

            //������ + Э���ʶ + ���� + ��Ԫ��ʶ + ������ + ��ʼ��Ȧ��ַ + ��Ȧ���� + �ֽڼ��� + �ֽ�����

            //������ + Э���ʶ
            SendCommand.Add(0x00, 0x00, 0x00, 0x00);

            //���� 
            SendCommand.Add((short)(7 + setArray.Length));

            //��Ԫ��ʶ + ������

            SendCommand.Add(SlaveId, 0x0F);

            //��ʼ��Ȧ��ַ
            SendCommand.Add(start);

            //��Ȧ����
            SendCommand.Add((short)value.Length);

            //�ֽڼ���
            SendCommand.Add((byte)setArray.Length);

            //�ֽ�����
            SendCommand.Add(setArray);

            byte[] receive = null;

            //�ڶ��� �����������Ͳ����ձ���
            if (SendAndReceive(SendCommand.Array, ref receive))
            {
                //���Ĳ�����֤����
                byte[] send = new byte[12];

                Array.Copy(SendCommand.Array, 0, send, 0, 12);

                send[4] = 0x00;
                send[5] = 0x06;

                return ByteArrayEquals(send, receive);
            }
            return false;
        }
        #endregion

        #region 10HԤ�ö�Ĵ���

        /// <summary>
        /// Ԥ�ö�Ĵ���
        /// </summary>
        /// <param name="start">��ʼ�Ĵ�����ַ</param>
        /// <param name="value">д��ֵ</param>
        /// <returns>���ؽ��</returns>
        public bool PreSetMultiRegisters(ushort start, byte[] values)
        {
            //��һ����ƴ�ӱ���

            if (values == null || values.Length == 0 || values.Length % 2 == 1)
            {
                return false;
            }

            //����һ��ByteArray����
            ByteArray SendCommand = new ByteArray();

            //������ + Э���ʶ + ���� + ��Ԫ��ʶ + ������ + ��ʼ�Ĵ�����ַ + �Ĵ������� + �ֽڼ��� + �ֽ�����

            //������ + Э���ʶ
            SendCommand.Add(0x00, 0x00, 0x00, 0x00);

            //���� 
            SendCommand.Add((short)(7 + values.Length));

            //��Ԫ��ʶ + ������

            SendCommand.Add(SlaveId, 0x10);

            //��ʼ�Ĵ�����ַ
            SendCommand.Add(start);

            //�Ĵ�������
            SendCommand.Add((short)(values.Length / 2));

            //�ֽڼ���
            SendCommand.Add((byte)(values.Length));

            //�ֽ�����
            SendCommand.Add(values);

            byte[] receive = null;

            //�ڶ��� �����������Ͳ����ձ���
            if (SendAndReceive(SendCommand.Array, ref receive))
            {
                //���Ĳ�����֤����
                byte[] send = new byte[12];

                Array.Copy(SendCommand.Array, 0, send, 0, 12);

                send[4] = 0x00;
                send[5] = 0x06;

                return ByteArrayEquals(send, receive);
            }
            return false;
        }
        #endregion

        #region ͨ�÷��Ͳ����շ���
        /// <summary>
        /// ���Ͳ����շ���
        /// </summary>
        /// <param name="send">���ͱ���</param>
        /// <param name="receive">���ձ���</param>
        /// <returns>���ؽ��</returns>
        private bool SendAndReceive(byte[] send, ref byte[] receive)
        {
            //����
            hybirdLock.Enter();

            byte[] buffer = new byte[1024];
            MemoryStream stream = new MemoryStream();

            try
            {
                //���ͱ���
                socket.Send(send, send.Length, SocketFlags.None);

                int timer = 0;

                while (true)
                {
                    Thread.Sleep(SleepTime);

                    //�жϻ�������û������
                    if (socket.Available > 0)
                    {
                        //�������ݲ��ŵ�Buffer
                        int count = socket.Receive(buffer, SocketFlags.None);

                        //����ȡ�����ݷŵ�Stream��
                        stream.Write(buffer, 0, count);
                    }
                    else
                    {
                        timer++;
                        //���ж�Stream��û������
                        if (stream.Length > 0)
                        {
                            break;
                        }
                        //��ʱ��ȡ
                        else if (timer > MaxWaitTimes)
                        {
                            return false;
                        }
                        else if (stream.Length > 0)
                        {
                            break;
                        }
                    }
                }

                receive = stream.ToArray();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                hybirdLock.Leave();
            }
        }

        #endregion

        #region ����ȽϷ���

        /// <summary>
        /// ����ȽϷ���    0x01 0x02   01-02
        /// </summary>
        /// <param name="b1"></param>
        /// <param name="b2"></param>
        /// <returns></returns>
        private bool ByteArrayEquals(byte[] b1, byte[] b2)
        {
            return BitConverter.ToString(b1) == BitConverter.ToString(b2);
        }

        #endregion

        #region ����������ת�����ֽ�����

        private byte[] GetByteArrayFromBoolArray(bool[] value)
        {
            int byteLength = value.Length % 8 == 0 ? value.Length / 8 : value.Length / 8 + 1;

            byte[] result = new byte[byteLength];

            for (int i = 0; i < result.Length; i++)
            {
                //��ȡÿ���ֽڵ�ֵ

                int total = value.Length < 8 * (i + 1) ? value.Length - 8 * i : 8;

                for (int j = 0; j < total; j++)
                {
                    result[i] = SetBitValue(result[i], j, value[8 * i + j]);
                }
            }
            return result;
        }

        /// <summary>
        /// ��ĳ���ֽ�ĳ��λ��λ��λ
        /// </summary>
        /// <param name="src"></param>
        /// <param name="bit"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private byte SetBitValue(byte src, int bit, bool value)
        {
            return value ? (byte)(src | (byte)Math.Pow(2, bit)) : (byte)(src & ~(byte)Math.Pow(2, bit));
        }
        #endregion
    }

    #region ByteArray
    /// <summary>
    /// ByteArray�����࣬һ������������ƴ��
    /// </summary>
    public class ByteArray
    {
        #region ��ʼ��

        private List<byte> list = new List<byte>();

        #endregion

        #region ����
        /// <summary>
        /// List����
        /// </summary>
        public List<byte> List
        {
            get { return list; }
        }

        /// <summary>
        /// Array����
        /// </summary>
        public byte[] Array
        {
            get { return list.ToArray(); }
        }

        /// <summary>
        /// ����
        /// </summary>
        public int Length
        {
            get { return list.Count; }
        }

        #endregion

        #region ����

        /// <summary>
        /// ���һ���ֽ�
        /// </summary>
        /// <param name="item"></param>
        public void Add(byte item)
        {
            list.Add(item);
        }

        /// <summary>
        /// ���һ������
        /// </summary>
        /// <param name="item"></param>
        public void Add(byte[] array)
        {
            list.AddRange(array);
        }

        /// <summary>
        /// ���һ������
        /// </summary>
        /// <param name="list"></param>
        public void Add(List<byte> list)
        {
            list.AddRange(list);
        }

        /// <summary>
        /// ������������ֽ�
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        public void Add(byte item1, byte item2)
        {
            Add(new byte[] { item1, item2 });
        }

        /// <summary>
        /// ������������ֽ�
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <param name="item3"></param>
        public void Add(byte item1, byte item2, byte item3)
        {
            Add(new byte[] { item1, item2, item3 });
        }


        /// <summary>
        /// ��������ĸ��ֽ�
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <param name="item3"></param>
        /// <param name="item4"></param>
        public void Add(byte item1, byte item2, byte item3, byte item4)
        {
            Add(new byte[] { item1, item2, item3, item4 });
        }


        /// <summary>
        /// �����������ֽ�
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <param name="item3"></param>
        /// <param name="item4"></param>
        /// <param name="item5"></param>
        public void Add(byte item1, byte item2, byte item3, byte item4, byte item5)
        {
            Add(new byte[] { item1, item2, item3, item4, item5 });
        }

        /// <summary>
        /// ���һ��ByteArray����
        /// </summary>
        /// <param name="byteArray"></param>
        public void Add(ByteArray byteArray)
        {
            Add(byteArray.Array);
        }

        /// <summary>
        /// ���һ��Short����
        /// </summary>
        /// <param name="value"></param>
        public void Add(short value)
        {
            Add((byte)(value >> 8));
            Add((byte)(value));
        }

        /// <summary>
        /// ���һ��UShort����
        /// </summary>
        /// <param name="value"></param>
        public void Add(ushort value)
        {
            Add((byte)(value >> 8));
            Add((byte)(value));
        }

        /// <summary>
        /// ���
        /// </summary>
        public void Clear()
        {
            list.Clear();
        }
        #endregion
    }

    #endregion

    #region �򵥵Ļ����
    /// <summary>
    /// һ���򵥵Ļ���߳�ͬ�����������˻�Ԫ�û��ӻ�Ԫ�ں�ͬ������ʵ��
    /// </summary>

    public sealed class SimpleHybirdLock : IDisposable
    {

        #region IDisposable Support
        private bool disposedValue = false; // Ҫ����������

        void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: �ͷ��й�״̬(�йܶ���)��
                }

                // TODO: �ͷ�δ�йܵ���Դ(δ�йܵĶ���)������������������ս�����
                // TODO: �������ֶ�����Ϊ null��
                m_waiterLock.Close();

                disposedValue = true;
            }
        }

        // TODO: �������� Dispose(bool disposing) ӵ�������ͷ�δ�й���Դ�Ĵ���ʱ������ս�����
        // ~SimpleHybirdLock() {
        //   // ������Ĵ˴��롣���������������� Dispose(bool disposing) �С�
        //   Dispose(false);
        // }

        // ��Ӵ˴�������ȷʵ�ֿɴ���ģʽ��
        /// <summary>
        /// �ͷ���Դ
        /// </summary>
        public void Dispose()
        {
            // ������Ĵ˴��롣���������������� Dispose(bool disposing) �С�
            Dispose(true);
            // TODO: ���������������������ս�������ȡ��ע�������С�
            // GC.SuppressFinalize(this);
        }
        #endregion

        /// <summary>
        /// ��Ԫ�û�ģʽ����ͬ����
        /// </summary>
        private Int32 m_waiters = 0;
        /// <summary>
        /// ��Ԫ�ں�ģʽ����ͬ����
        /// </summary>
        private AutoResetEvent m_waiterLock = new AutoResetEvent(false);

        /// <summary>
        /// ��ȡ��
        /// </summary>
        public void Enter()
        {
            if (Interlocked.Increment(ref m_waiters) == 1) return;//�û�������ʹ�õ�ʱ��ֱ�ӷ��أ���һ�ε���ʱ����
                                                                  //������������ʱ��ʹ���ں�ͬ��������
            m_waiterLock.WaitOne();
        }

        /// <summary>
        /// �뿪��
        /// </summary>
        public void Leave()
        {
            if (Interlocked.Decrement(ref m_waiters) == 0) return;//û�п��õ�����ʱ��
            m_waiterLock.Set();
        }

        /// <summary>
        /// ��ȡ��ǰ���Ƿ��ڵȴ�����
        /// </summary>
        public bool IsWaitting => m_waiters == 0;
    }
    #endregion

}
