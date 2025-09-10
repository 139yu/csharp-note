using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeiSai3800Demo
{
    public class Result
    {
        public bool Status { get; set; } = false;
        public string Msg { get; set; }
        public int Code { get; set; }

        public Result(bool status,int code,string msg)
        {
            Status = status;
            Code = code;
            Msg = msg;
        }

        public Result()
        {
            
        }

        public static Result Ok(int code,string msg)
        {
            return new Result(true, code, msg);
        }

        public static Result Ok()
        {
            return Result.Ok(0, "");
        }
        public static Result Fail(int code, string msg)
        {
            return new Result(false, code, msg);
        }
        public static Result Fail(string msg)
        {
            return Result.Fail(-1, msg);
        }
        public static Result Fail()
        {
            return Result.Fail(-1, "error");
        }
    }
}