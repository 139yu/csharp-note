namespace Modbus.Communication.Common
{
    public enum FuncEnum
    {
        /// <summary>
        /// 读输入线圈
        /// </summary>
        ReadCoil = 0x01,
        /// <summary>
        /// 写输出线圈
        /// </summary>
        WriteCoil = 0x05,
        /// <summary>
        /// 写多个线圈
        /// </summary>
        WriteMultiCoil = 0x0F,
        /// <summary>
        /// 读离散输入寄存器
        /// </summary>
        ReadInput = 0x02,
        /// <summary>
        /// 读多个保持寄存器
        /// </summary>
        ReadHoldingRegister = 0x03,
        /// <summary>
        /// 写保持寄存器
        /// </summary>
        WriteHoldingRegister = 0x06,
        /// <summary>
        /// 写多个保持寄存器
        /// </summary>
        WriteMultiHoldingRegister = 0x10,
        /// <summary>
        /// 读多个输入寄存器
        /// </summary>
        ReadInputRegister = 0x04,
    }
}