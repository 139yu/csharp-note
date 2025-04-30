using SmartParking.Client.UpgradeApp.DAL;
using SmartParking.Client.UpgradeApp.Models;

namespace SmartParking.Client.UpgradeApp.BLL
{
    public class LocalFileBll
    {
        private LocalDataAccess _localDataAccess = new LocalDataAccess();
      
        /// <summary>
        /// 如果文件存在，就更新，负责插入
        /// </summary>
        /// <param name="file"></param>
        public void AddOrUpdate(UpgradeFileModel file)
        {
            if (_localDataAccess.FileExists(file.FileName))
            {
                _localDataAccess.UpdateFile(file);
            }
            else
            {
                _localDataAccess.InsertFile(file);
            }
        }
    }
}