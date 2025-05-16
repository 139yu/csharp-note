using System.Collections.Generic;
using SmartParking.Server.Models;

namespace SamrtParking.Server.IService.Service
{
    public interface IUpgradeFileService : IBaseService
    {
        List<UpgradeFileModel> GetUpgradeFiles(string keyword);
        
        UpgradeFileModel GetUpgradeFileByMD5(string fileMD5);

        void DeleteFile(int fileId);
        void saveFile(UpgradeFileModel fileModel);
    }
}