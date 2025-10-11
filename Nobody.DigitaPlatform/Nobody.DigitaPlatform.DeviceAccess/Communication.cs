
using System.Reflection;
using System.Text;
using Nobody.DigitaPlatform.DeviceAccess.Base;
using Nobody.DigitaPlatform.DeviceAccess.Execute;
using Nobody.DigitaPlatform.DeviceAccess.Transfer;
using Nobody.DigitaPlatform.Entities;

namespace Nobody.DigitaPlatform.DeviceAccess
{
    public class Communication
    {
        private static Communication instance;
        private static object lockObj = new object();
        public static Communication GetInstance()
        {
            if (instance == null)
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        instance = new Communication();
                    }
                }
            }
            
            return instance;
        }
        private Communication()
        {
            
        }

        private readonly List<TransferObject> _transfers = new List<TransferObject>();

        public Result<ExecuteObject> GetExecuteObject(List<DevicePropEntity> deviceProps)
        {
            Result<ExecuteObject> result = new Result<ExecuteObject>();
            try
            {
                var protocolEntity = deviceProps.FirstOrDefault(p => p.PropName.Equals("Protocol"));
                if (protocolEntity == null || protocolEntity.PropValue == null)
                {
                    throw new Exception("未知通信协议");
                }

                var protocol = protocolEntity.PropValue;

                var type = Assembly.Load("Nobody.DigitaPlatform.DeviceAccess")
                    .GetType("Nobody.DigitaPlatform.DeviceAccess.Execute." + protocol);
                if (type == null)
                {
                    throw new Exception("通信协议不存在");
                }

                var eo = Activator.CreateInstance(type) as ExecuteObject;
                eo.Match(deviceProps, _transfers);
                result.Data = eo;
            }
            catch (Exception e)
            {
                result.Status = false;
                result.Message = e.Message;
            }

            return result;
        }
        /// <summary>
        /// 将字节数组转换为指定类型
        /// </summary>
        /// <param name="valueBytes"></param>
        /// <param name="targetType"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Result<object> ConvertType(List<byte> valueBytes, Type targetType)
        {
            Result<object> result = new Result<object>();
            try
            {
                if (targetType == typeof(bool))
                {
                    result.Data = valueBytes[0] != 0;
                }
                else if (targetType == typeof(string))
                {
                    result.Data = Encoding.UTF8.GetString(valueBytes.ToArray());
                }
                else
                {
                    var convertType = typeof(BitConverter);
                    var targetMethod = convertType
                            .GetMethods(BindingFlags.Static | BindingFlags.Public)
                            .FirstOrDefault(m =>
                                m.ReturnParameter.ParameterType == targetType && m.GetParameters().Length == 2) as
                        MethodInfo;
                    if (targetMethod == null)
                    {
                        throw new Exception($"不支持的类型转换: {targetType.Name}");
                    }

                    result.Data = targetMethod.Invoke(convertType, new object[] { valueBytes.ToArray(), 0 });
                }
            }
            catch (Exception e)
            {
                result.Status = false;
                result.Message = e.Message;
            }

            return result;
        }
    }

}
