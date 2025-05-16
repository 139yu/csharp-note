using System.Collections.Generic;
using SmartParking.Server.Models;

namespace SamrtParking.Server.IService.Service
{
    public interface IMenuService: IBaseService
    {
        List<MenuModel> GetAllMenu();

        List<MenuModel> GetMenuTree();
        void addMenu(MenuModel menuModel);
    }
}