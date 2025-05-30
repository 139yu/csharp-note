using System.ComponentModel.DataAnnotations.Schema;

namespace SmartParking.Server.Models
{
    [Table("sys_user_role")]
    public class UserRole
    {
        [Column("user_id")]
        public int UserId { get; set; }
        [Column("role_id")]
        public int RoleId { get; set; }
    }
}