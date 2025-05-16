using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using SmartParking.Client.Commons.Entity.Request;
using SmartParking.Client.Commons.Entity.Response;

namespace SamrtParking.Client.IDAL
{
    public interface IFileDal
    {
        Task<DataTable> GetLocalFiles();
        
        Task<ResponseResult<List<UpgradeFileModel>>> GetServerFiles(string keyword = null);

        Task<ResponseResult> DeleteFile(int fileId);
        
        public Task<ResponseResult> UploadFile(string filepath,Dictionary<string,string> metadata,Action<double> progressCallback = default);

    }
}