using System.ComponentModel.DataAnnotations.Schema;

namespace SmartParking.Server.Models
{
    [Table("sys_role_menu")]
    public class RoleMenu
    {
        [Column("role_id")]
        public int RoleId { get; set; }
        [Column("menu_id")]
        public int MenuId { get; set; }
    }
}