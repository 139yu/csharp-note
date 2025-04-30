using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using SamrtParking.Client.IDAL;
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

        public Task<ResponseResult<List<UpgradeFileModel>>> GetServerFiles()
        {
            return _fileDal.GetServerFiles();
        }
    }
}