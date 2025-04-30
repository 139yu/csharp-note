using System;
using System.Data.SQLite;
using System.IO;
using System.Threading;
using SmartParking.Client.UpgradeApp.Models;

namespace SmartParking.Client.UpgradeApp.DAL
{
    public class LocalDataAccess
    {
        private readonly string _connectionString =
            $"Data Source={Path.Combine("Data", "SmartParking.db")};Pooling=True;Max Pool Size=100;";


        /*public LocalDataAccess()
        {
            _threadLocalConn = new ThreadLocal<SQLiteConnection>(() =>
            {
                var conn = new SQLiteConnection(_connectionString);
                conn.Open();
                return conn;
            }, trackAllValues: true );
        }*/

        

        private SQLiteConnection Connection()
        {
            var conn = new SQLiteConnection(_connectionString);
            conn.Open();
            return conn;
        }
        public bool FileExists(string filename)
        {
            using (var conn = Connection())
            {
                string sql = "select count(1) from file_version where file_name = @filename";
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@filename", filename);
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        return (long)result > 0;
                    }
                }
            }

            return false;
        }

        public void UpdateFile(UpgradeFileModel file)
        {
            using (var conn = Connection())
            {
                string sql =
                    "update file_version set file_md5 = @fileMd5,file_len = @fileLen,upload_time = @uploadTime where file_name = @filename";
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@fileMd5", file.FileMd5);
                    cmd.Parameters.AddWithValue("@fileLen", file.FileLen);
                    var milliseconds = StrToMilliseconds(file.UploadTime);
                    cmd.Parameters.AddWithValue("@uploadTime", milliseconds);
                    cmd.Parameters.AddWithValue("@filename", file.FileName);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void InsertFile(UpgradeFileModel file)
        {
            using (var conn = Connection())
            {
                try
                {
                    string sql =
                        "insert into file_version (file_name,file_md5,file_len,upload_time) values (@fileName,@fileMD5,@fileLen,@uploadTime)";
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@fileName", file.FileName);
                        cmd.Parameters.AddWithValue("@fileMD5", file.FileMd5);
                        cmd.Parameters.AddWithValue("@fileLen", file.FileLen.ToString());
                        string milliseconds = StrToMilliseconds(file.UploadTime);
                        cmd.Parameters.AddWithValue("@uploadTime", milliseconds);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        private string StrToMilliseconds(string modelTime)
        {
            long milliseconds = 0l;
            DateTime uploadTime = DateTime.Now;
            var isDate = DateTime.TryParse(modelTime, out uploadTime);
            if (isDate)
            {
                DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                var timeSpan = uploadTime - unixEpoch;
                milliseconds = (long)timeSpan.TotalMilliseconds;
            }
            else
            {
                long.TryParse(modelTime, out milliseconds);
            }

            return milliseconds.ToString();
        }
    }
}