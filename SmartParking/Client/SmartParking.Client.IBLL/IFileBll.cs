using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using SmartParking.Client.Commons.Entity.Response;

namespace SmartParking.Client.IBLL
{
    public interface IFileBll
    {
        Task<DataTable> GetLocalFiles();
        Task<ResponseResult<List<UpgradeFileModel>>> GetServerFiles();
    }
}