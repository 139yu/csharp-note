using System.Collections.Generic;
using System.Threading.Tasks;
using SamrtParking.Client.IDAL;
using SmartParking.Client.Commons.Entity.Response;
using SmartParking.Client.Commons.IServices;

namespace SmartParking.Client.DAL
{
    public class MenuDal: IMenuDal
    {
        private IHttpService _httpService;
        public MenuDal(IHttpService httpService)
        {
            _httpService = httpService;
        }
        public Task<ResponseResult<List<MenuEntity>>> GetMenuTree()
        {
            return _httpService.GetAsync<ResponseResult<List<MenuEntity>>>("/api/menu/getMenuTree");
        }

        public Task<ResponseResult> addMenu(MenuEntity menuEntity)
        {
            return _httpService.PostAsync<ResponseResult, MenuEntity>("/api/menu/addMenu", menuEntity);
        }
    }
}