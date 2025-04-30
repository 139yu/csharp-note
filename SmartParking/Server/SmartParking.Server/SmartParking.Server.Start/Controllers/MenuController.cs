using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SamrtParking.Server.IService.Service;
using SmartParking.Server.Common.Entities.Response;
using SmartParking.Server.Models;

namespace SmartParking.Server.Start.Controllers
{
    [ApiController]
    [Route("api/menu")]
    public class MenuController : ControllerBase
    {
        private IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet]
        [Route("getMenuTree")]
        public IActionResult GetMenuTree()
        {
            var menuModels = _menuService.GetMenuTree();

            return Ok(ResponseEntity<List<MenuModel>>.Success(menuModels));
        }
    }
}