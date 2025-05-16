using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using SamrtParking.Client.IDAL;
using SmartParking.Client.Commons.Entity.Request;
using SmartParking.Client.Commons.Entity.Response;
using SmartParking.Client.IBLL;

namespace SmartParking.Client.BLL
{
    public class FileBll : IFileBll
    {
        private IFileDal _fileDal;

        public FileBll(IFileDal fileDal)
        {
            _fileDal = fileDal;
        }

        public Task<DataTable> GetLocalFiles()
        {
            return _fileDal.GetLocalFiles();
        }

        public Task<ResponseResult<List<UpgradeFileModel>>> GetServerFiles(string keyword = null)
        {
            return _fileDal.GetServerFiles(keyword);
        }

        public Task<ResponseResult> DeleteFile(int fileId)
        {
            return _fileDal.DeleteFile(fileId);
        }

        public Task<ResponseResult> UploadFile(string filepath, Dictionary<string, string> metadata,Action<double> progressCallback = default)
        {
            return _fileDal.UploadFile(filepath, metadata,progressCallback);
        }
    }
}