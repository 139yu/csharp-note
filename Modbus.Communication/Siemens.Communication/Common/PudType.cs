namespace Siemens.Communication.Common
{
    public enum PudType
    {
        /// <summary>
        /// 连接请求
        /// </summary>
        ConnectionRequest = 0xe0,
        /// <summary>
        /// 连接确认
        /// </summary>
        ConnectionConfirm = 0xd0,
        /// <summary>
        /// 数据
        /// </summary>
        Data = 0x08,
        /// <summary>
        /// 断开连接请求
        /// </summary>
        DisconnectRequest = 0x0c,
        /// <summary>
        /// 断开连接确认
        /// </summary>
        DisconnectConfirm = 0xc0,
        /// <summary>
        /// 解决访问
        /// </summary>
        HandlerRequest = 0x05,
        /// <summary>
        /// 加急数据
        /// </summary>
        UrgentData = 0x01,
        /// <summary>
        /// 加急确认数据
        /// </summary>
        UrgentConfirmData = 0x02,
        /// <summary>
        /// 用户数据
        /// </summary>
        UserData = 0x04,
        /// <summary>
        /// TPDU错误
        /// </summary>
        TPUDError = 0x07,
        /// <summary>
        /// 数据传输
        /// </summary>
        DataTransmission = 0xf0
    }
}