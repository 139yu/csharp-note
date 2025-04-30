using System.Data;

namespace SamrtParking.Client.IDAL
{
    public interface ILocalDataAccess
    {
        DataTable GetLocalFiles();
    }
}