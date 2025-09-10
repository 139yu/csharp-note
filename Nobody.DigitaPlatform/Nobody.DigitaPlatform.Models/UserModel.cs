using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace Nobody.DigitaPlatform.Models
{
    public class UserModel: ObservableObject
    {
        public string Username { get; set; } = "admin";
        public string Password { get; set; } = "admin";

        public string RealName { get; set; }

        /// <summary>
        /// 用户类型：0-管理员，1-普通用户
        /// </summary>
        public int UserType { get; set; }

        public string PhoneNum { get; set; }
        public string Department { get; set; }
        public int Gender { get; set; }
        private string _displayGender;
        public string DisplayGender
        {
            get => _displayGender;
            set
            {
                Set(ref _displayGender, value);
                if (_displayGender.Equals("男"))
                {
                    Gender = 0;
                }
                else
                {
                    Gender = 1;
                }
            }
        }
    }
}