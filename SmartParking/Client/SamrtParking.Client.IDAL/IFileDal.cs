using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using SmartParking.Client.Commons.Entity.Response;

namespace SamrtParking.Client.IDAL
{
    public interface IFileDal
    {
        Task<DataTable> GetLocalFiles();
        
        Task<ResponseResult<List<UpgradeFileModel>>> GetServerFiles();
    }
}