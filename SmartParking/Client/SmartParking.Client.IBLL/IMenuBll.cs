using System.Collections.Generic;
using System.Threading.Tasks;
using SmartParking.Client.Commons.Entity.Response;

namespace SmartParking.Client.IBLL
{
    public interface IMenuBll
    {
        Task<ResponseResult<List<MenuEntity>>> GetMenuTree();
        Task<ResponseResult> addMenu(MenuEntity menuEntity);
    }
}