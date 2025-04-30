using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using SamrtParking.Client.IDAL;

namespace SmartParking.Client.DAL
{
    public class LocalDataAccess: ILocalDataAccess
    {
        private readonly string _connectionString = $"Data Source={Path.Combine("Data", "SmartParking.db")}";
        private SQLiteConnection conn = null;
        private SQLiteCommand cmd = null;
        private SQLiteDataAdapter adapter = null;
        private SQLiteTransaction tran = null;
        
        private void Dispose()
        {
            tran?.Dispose();
            adapter?.Dispose();
            cmd?.Dispose();
            conn?.Dispose();
        }

        public bool Connect()
        {
            
            try
            {
                if (conn == null)
                {
                    conn = new SQLiteConnection(_connectionString);
                }
                conn.Open();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
               return false;
            }
            
        }
        public DataTable GetLocalFiles()
        {
            try
            {
                if (this.Connect())
                {
                    string sql = "select file_id,file_name,file_md5,file_len from file_version";
                    adapter = new SQLiteDataAdapter(sql, conn);
                    var dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                this.Dispose();   
            }
            return null;
        }
    }
}