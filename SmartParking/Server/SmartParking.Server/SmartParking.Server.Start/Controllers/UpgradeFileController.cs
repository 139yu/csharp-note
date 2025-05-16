using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SamrtParking.Server.IService.Service;
using SmartParking.Server.Common.Entities.Request;
using SmartParking.Server.Common.Entities.Response;
using SmartParking.Server.Common.Heplers;
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
        [Route("getUpgradeFiles")]
        public IActionResult GetUpgradeFiles([FromQuery]string keyword)
        {
            var upgradeFileModels = _upgradeFileService.GetUpgradeFiles(keyword);
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

        [HttpPost]
        [Route("delete/{fileId}")]
        public IActionResult Delete([FromRoute] int fileId)
        {
            _upgradeFileService.DeleteFile(fileId);
            return Ok(ResponseEntity<List<UpgradeFileModel>>.Success());
        }

        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile file,[FromForm] Dictionary<string,string> metadata)
        {
            var directory = Path.Combine(AppContext.BaseDirectory, "Client");
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var filename = file.FileName;
            var targetFile = Path.Combine(AppContext.BaseDirectory, "Client", filename);
            using (FileStream fs = new FileStream(targetFile, FileMode.Create, FileAccess.Write))
            {
                await file.CopyToAsync(fs);
            }

            var fileModel = new UpgradeFileModel()
            {
                OutputDir = metadata["outputDir"],
                FileName = filename,
                FileMd5 = metadata["fileMd5"],
                FileLen = file.Length,
                UploadTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };
            _upgradeFileService.saveFile(fileModel);
            return Ok(ResponseEntity.Success());
        }
    }
}