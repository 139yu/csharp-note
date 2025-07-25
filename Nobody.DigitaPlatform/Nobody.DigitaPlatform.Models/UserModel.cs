﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobody.DigitaPlatform.Models
{
    public class UserModel
    {
        public string Username { get; set; } = "admin";
        public string Password { get; set; } = "admin";

        public string RealName { get; set; }
        public int UserType { get; set; }
        public string PhoneNum { get; set; }
        public string Department { get; set; }
        public int Gender { get; set; }
    }
}