using System;
using System.Threading;

namespace DataBindStudy.Models
{
    public class DelayMode
    {
        public string Value1
        {
            get
            {
                Thread.Sleep(5000);
                throw new Exception("不知名错误");
            }
            set
            {
                Value1 = value;
            }
        }

        public string Value2 
        {
            get
            {
                Thread.Sleep(3000);
                return "Hello World2";
            }
            set
            {
                Value2 = value;
            }
        }

        public string Value3
        {
            get
            {
                Thread.Sleep(2000);
                return "Hello World3";
            }
            set
            {
                Value3 = value;
            }
        }
    }
}