using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using SamrtParking.Client.IDAL;
using SmartParking.Client.Commons.Entity.Request;
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

        public async Task<ResponseResult<List<UpgradeFileModel>>> GetServerFiles(string keyword = null)
        {
            Dictionary<string, string> querys = null;
            if (!string.IsNullOrEmpty(keyword))
            {
                querys = new Dictionary<string, string>();
                querys["keyword"] = keyword;   
            }
            return await _httpService.
                GetAsync<ResponseResult<List<UpgradeFileModel>>>("api/upgradeFile/getUpgradeFiles", querys);
        }

        public Task<ResponseResult> DeleteFile(int fileId)
        {
            return _httpService.PostAsync<ResponseResult>($"api/upgradeFile/delete/{fileId}");
        }

        public Task<ResponseResult> UploadFile(string filepath, Dictionary<string, string> metadata,Action<double> progressCallback = default)
        {
            return _httpService.PostFileAsync<ResponseResult>("api/upgradeFile/upload", filepath, metadata,progressCallback);
        }
    }
}