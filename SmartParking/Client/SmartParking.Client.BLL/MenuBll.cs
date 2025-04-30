using System.Collections.Generic;
using System.Threading.Tasks;
using SamrtParking.Client.IDAL;
using SmartParking.Client.Commons.Entity.Response;
using SmartParking.Client.IBLL;

namespace SmartParking.Client.BLL
{
    public class MenuBll: IMenuBll
    {
        private IMenuDal _menuDal;
        public MenuBll(IMenuDal menuDal)
        {
            _menuDal = menuDal;
        }
        public Task<ResponseResult<List<MenuEntity>>> GetMenuTree()
        {
            return _menuDal.GetMenuTree();
        }
    }
}