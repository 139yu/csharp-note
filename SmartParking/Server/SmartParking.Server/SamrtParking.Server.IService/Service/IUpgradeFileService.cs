using System.Collections.Generic;
using SmartParking.Server.Models;

namespace SamrtParking.Server.IService.Service
{
    public interface IUpgradeFileService : IBaseService
    {
        List<UpgradeFileModel> GetAllUpgradeFiles();
        
        UpgradeFileModel GetUpgradeFileByMD5(string fileMD5);
    }
}