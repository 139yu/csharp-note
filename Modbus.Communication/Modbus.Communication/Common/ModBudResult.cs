using System.Collections.Generic;

namespace Modbus.Communication.Common
{
    public class ModBudResult<T>
    {
        public bool Status { get; set; }
        public string Message { get; set; }

        public List<T> Data;


        private ModBudResult(bool state, string msg, List<T> data = default(List<T>))
        {
            this.Status = state;
            Message = msg;
            Data = data;
        }

        private static ModBudResult<T> Success(string msg, List<T> data)
        {
            return new ModBudResult<T>(true, msg, data);
        }
        
        public static ModBudResult<T> Success(List<T> data = default(List<T>))
        {
            return Success("OK", data);
        }

        public static ModBudResult<T> Failed(string msg = "Error",List<T> data = default(List<T>))
        {
            return new ModBudResult<T>(false,msg,data);
        }
   
    }

    public class ModBudResult
    {
        public bool Status { get; set; }
        public string Message { get; set; }

        public ModBudResult(bool status,string msg)
        {
            Status = status;
            Message = msg;
        }
        public static ModBudResult Success(string msg = "Ok")
        {
            return new ModBudResult(true, msg);
        }
        
        public static ModBudResult Failed(string msg = "Error")
        {
            return new ModBudResult(false, msg);
        }
    }
}