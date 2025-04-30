using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartParking.Server.Models
{
    [Table("sys_menu")]
    public class MenuModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("menu_id")]
        public int MenuId { get; set; }

        [Required]
        [MaxLength(30)]
        [Column("menu_title")]
        public string MenuTitle { get; set; }

        [MaxLength(50)]
        [Column("target_view")]
        public string TargetView { get; set; }

        [Required]
        [Column("parent_id")]
        public int ParentId { get; set; } = 0;

        [MaxLength(30)]
        [Column("menu_icon")]
        public string MenuIcon { get; set; }
        
        [Column("menu_type")]
        public int MenuType { get; set; } = 0;

        [Column("state")]
        public int State { get; set; } = 0;   
        
        [NotMapped]
        public List<MenuModel> Children { get; set; }
    }
}