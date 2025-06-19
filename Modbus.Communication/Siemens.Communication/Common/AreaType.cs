namespace Siemens.Communication.Common
{
    public enum AreaType
    {
        /// <summary>
        /// System info of 200 family | 200系列系统信息
        /// </summary>
        SysInfoOf200 = 0x03,
        /// <summary>
        /// System flags of 200 family | 200系列系统标志
        /// </summary>
        SysFlagsOf200 = 0x05,
        /// <summary>
        /// Analog inputs of 200 family | 200系列模拟量输入
        /// </summary>
        AnalogInputsOf200 = 0x06,
        /// <summary>
        /// Analog outputs of 200 family | 200系列模拟量输出
        /// </summary>
        AnalogOutputsOf200 = 0x07,
        /// <summary>
        /// Direct peripheral access (P) | 直接访问外设
        /// </summary>
        DirectAccess = 0x80,
        /// <summary>
        /// Inputs (I) | 输入（I）
        /// </summary>
        Inputs = 0x80,
        /// <summary>
        /// Outputs (Q) | 输出（Q）
        /// </summary>
        Outputs = 0x82,
        /// <summary>
        /// M
        /// </summary>
        M = 0x83,
        DataBlocks = 0x84,
        /// <summary>
        /// Data blocks (DB) | 数据块（DB）  V
        /// </summary>
        InstanceDataBlocks = 0x85,
        /// <summary>
        /// Instance data blocks (DI) | 背景数据块（DI）
        /// </summary>
        LocalData = 0x86,
        /// <summary>
        /// Local data (L) | 局部变量（L）
        /// </summary>
        GlobalVal = 0x87,
        /// <summary>
        /// S7 counters (C) | S7计数器（C）
        /// </summary>
        S7Counters = 0x1c,
        /// <summary>
        /// S7 timers (T) | S7定时器（T
        /// </summary>
        S7Timers = 0x1d,
        /// <summary>
        /// IEC counters (200 family) | IEC计数器（200系列）
        /// </summary>
        IECCountersOf200 = 0x1e,
        /// <summary>
        /// IEC timers (200 family) | IEC定时器（200系列）
        /// </summary>
        IECTimersOf200 = 0x1f
    }
}