using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobody.DigitaPlatform.Entities
{
    public class UserEntity
    {
        [Column("id")] 
        public string Id { get; set; }
        [Column("username")]
        public string Username { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("real_name")]
        public string RealName { get; set; }
        [Column("user_type")]
        public string UserType { get; set; }
        [Column("phone_num")]
        public string PhoneNum { get; set; }
        [Column("gender")]
        public string Gender { get; set; }
    }
}
