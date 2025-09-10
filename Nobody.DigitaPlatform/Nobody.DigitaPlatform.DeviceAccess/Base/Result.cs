﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace Nobody.DigitaPlatform.DeviceAccess.Base
{
    public class Result
    {
        public bool Status { get; set; } = true;
        public string Message { get; set; } = string.Empty;

        public Result() : this(true, "OK")
        {
        }

        public Result(bool state, string msg)
        {
            Status = state;
            Message = msg;
        }

        public static Result Success()
        {
            return new Result();
        }

        public static Result Failed()
        {
            return new Result(false,"failed");
        }
        public static Result Failed(string msg)
        {
            return new Result(false, msg);
        }
    }

    public class Result<T> : Result
    {

        public T Data { get; set; }

        public Result() : this(true, "OK")
        {
        }

        public Result(bool state, string msg) : this(state, msg, default(T))
        {
        }

        public Result(bool state, string msg, T data)
        {
            this.Status = state;
            Message = msg;
            Data = data;
        }
    }
}