using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartParking.Server.Models
{
    [Table("sys_role")]
    public class RoleModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("role_id")]
        public int RoleId { get; set; }
        [Column("role_name")]
        public string RoleName { get; set; }
        [Column("role_key")]
        public string RoleKey { get; set; }
    }
}