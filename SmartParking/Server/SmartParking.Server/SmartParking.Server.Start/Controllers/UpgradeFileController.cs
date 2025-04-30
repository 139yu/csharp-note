using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SamrtParking.Server.IService.Service;
using SmartParking.Server.Common.Entities.Response;
using SmartParking.Server.Models;

namespace SmartParking.Server.Start.Controllers
{
    [Route("api/upgradeFile")]
    [ApiController]
    public class UpgradeFileController: ControllerBase
    {
        private IUpgradeFileService _upgradeFileService;
        public UpgradeFileController(IUpgradeFileService upgradeFileService)
        {
            _upgradeFileService = upgradeFileService;
        }
        
        [AllowAnonymous]
        [HttpGet]
        [Route("getAllUpgradeFiles")]
        public IActionResult GetAllUpgradeFiles()
        {
            var upgradeFileModels = _upgradeFileService.GetAllUpgradeFiles();
            return Ok(ResponseEntity<List<UpgradeFileModel>>.Success(upgradeFileModels));
        }
    
        [AllowAnonymous]
        [HttpGet]
        [Route("Download/{fileTag}")]
        public IActionResult Download([FromRoute] string fileTag)
        {
            try
            {
                var upgradeFileModel = _upgradeFileService.GetUpgradeFileByMD5(fileTag);
                if (upgradeFileModel == null)
                {
                    return BadRequest(ResponseEntity.Failed("文件不存在"));
                }

                var fileName = upgradeFileModel.FileName;
                // AppContext.BaseDirectory exe所在目录
                var targetFile = Path.Combine(AppContext.BaseDirectory, "Client", fileName);
                FileStream fileStream = new FileStream(targetFile, FileMode.Open, FileAccess.Read);
                var type = new MediaTypeHeaderValue("application/octet-stream").MediaType;
                // enableRangeProcessing 断点续传
                return File(fileStream, type, fileName, true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return BadRequest(ResponseEntity.Failed("文件不存在"));
            }
        }
    }
}