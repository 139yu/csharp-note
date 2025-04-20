using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartParking.Server.Models
{   
    [Table("sys_user")]
    public class UserModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("user_id")]
        public int UserId { get; set; }
        [Column("username")]
        public string Username { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("birthday")]
        public DateTime? Birthday { get; set; }
        [Column("real_name")]
        public string? RealName{ get; set; }
        [Column("is_deleted")]
        public byte? IsDeleted { get; set; }
    }
}