using System.Collections.Generic;

namespace Modbus.Communication.Common
{
    public class Result<T>
    {
        public bool Status { get; set; }
        public string Message { get; set; }

        public List<T> Data;


        private Result(bool state, string msg, List<T> data = default(List<T>))
        {
            this.Status = state;
            Message = msg;
            Data = data;
        }

        private static Result<T> Success(string msg, List<T> data)
        {
            return new Result<T>(true, msg, data);
        }
        
        public static Result<T> Success(List<T> data = default(List<T>))
        {
            return Success("OK", data);
        }

        public static Result<T> Failed(string msg = "Error",List<T> data = default(List<T>))
        {
            return new Result<T>(false,msg,data);
        }
   
    }

    public class Result
    {
        public bool Status { get; set; }
        public string Message { get; set; }

        public Result(bool status,string msg)
        {
            Status = status;
            Message = msg;
        }
        public static Result Success(string msg = "Ok")
        {
            return new Result(true, msg);
        }
        
        public static Result Failed(string msg = "Error")
        {
            return new Result(false, msg);
        }
    }
}