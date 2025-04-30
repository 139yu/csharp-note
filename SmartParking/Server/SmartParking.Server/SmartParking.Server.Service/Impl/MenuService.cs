using System.Collections.Generic;
using System.Linq;
using SamrtParking.Server.IService.Service;
using SmartParking.Server.Models;

namespace SmartParking.Server.Service.Impl
{
    public class MenuService : BaseService, IMenuService
    {
        public MenuService(IDBConfig.IDBConfig dbConfig) : base(dbConfig)
        {
        }

        public List<MenuModel> GetAllMenu()
        {
            return Query<MenuModel>(m => m.State == 0).ToList();
        }

        public List<MenuModel> GetMenuTree()
        {
            var menuList = GetAllMenu();
            if (menuList == null || menuList.Count <= 1)
            {
                return menuList;
            }
            var rootMenus = menuList.Where(m => m.ParentId == 0).ToList();
            var rootChildrenMap = menuList
                .Where(m => m.ParentId != 0)
                .GroupBy(m => m.ParentId)
                .ToDictionary(g => g.Key,g => g.ToList());
            foreach (var menu in rootMenus)
            {
                GetMenuTree( menu,rootChildrenMap);
            }

            return rootMenus;
        }

        private void GetMenuTree(MenuModel parent, Dictionary<int,List<MenuModel>> rootChildren)
        {
            if (rootChildren.TryGetValue(parent.MenuId,out var children))
            {
                parent.Children = children;
                foreach (var menu in children)
                {
                    GetMenuTree(menu, rootChildren);
                }
            }
            else
            {
                parent.Children = new List<MenuModel>();
            }
        }
    }
}