using System.Collections.Generic;
using System.Threading.Tasks;
using SmartParking.Client.Commons.Entity.Response;

namespace SamrtParking.Client.IDAL
{
    public interface IMenuDal
    {
        Task<ResponseResult<List<MenuEntity>>> GetMenuTree();
        Task<ResponseResult> addMenu(MenuEntity menuEntity);
    }
}