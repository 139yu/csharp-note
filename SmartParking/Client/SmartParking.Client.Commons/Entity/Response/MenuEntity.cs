using System.Collections.Generic;

namespace SmartParking.Client.Commons.Entity.Response
{
    public class MenuEntity
    {
        public int MenuId { get; set; }

        public string MenuTitle { get; set; }

        public string TargetView { get; set; }

        public int ParentId { get; set; } = 0;

        public string MenuIcon { get; set; }
        
        public int MenuType { get; set; } = 0;

        public int State { get; set; } = 0;   
        
        public List<MenuEntity> Children { get; set; }
    }
}