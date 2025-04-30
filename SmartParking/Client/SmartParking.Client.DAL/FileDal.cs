using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using SamrtParking.Client.IDAL;
using SmartParking.Client.Commons.Entity.Response;
using SmartParking.Client.Commons.IServices;

namespace SmartParking.Client.DAL
{
    public class FileDal : IFileDal
    {
        private ILocalDataAccess _localDataAccess;
        private IHttpService _httpService;
        public FileDal(ILocalDataAccess dataAccess,IHttpService httpService)
        {
            _localDataAccess = dataAccess;
            _httpService = httpService;
        }

        public async Task<DataTable> GetLocalFiles()
        {
            return _localDataAccess.GetLocalFiles();
        }

        public async Task<ResponseResult<List<UpgradeFileModel>>> GetServerFiles()
        {
            return await _httpService.GetAsync<ResponseResult<List<UpgradeFileModel>>>("api/upgradeFile/getAllUpgradeFiles");
        }
    }
}