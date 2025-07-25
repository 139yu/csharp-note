using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nobody.DigitaPlatform.Entities;

namespace Nobody.DigitaPlatform.DataAccess.Impl
{
    public class LocalDataAccess : ILocalDataAccess
    {
        private SQLiteConnection conn = null;
        private SQLiteCommand cmd = null;
        private SQLiteDataAdapter adapter = null;
        private SQLiteTransaction trans = null;
        private readonly string connStr = "Data Source=data.db3;Version=3;";

        private DataTable GetData(string sql, Dictionary<string, string> param = null)
        {
            try
            {
                if (conn == null)
                {
                    conn = new SQLiteConnection(connStr);
                }

                conn.Open();
                adapter = new SQLiteDataAdapter(sql, conn);
                if (param != null)
                {
                    // List<SQLiteParameter> parameters = new List<SQLiteParameter>();
                    foreach (var item in param)
                    {
                        var sqLiteParameter = new SQLiteParameter(item.Key, DbType.String) { Value = item.Value };
                        // parameters.Add(sqLiteParameter);
                        adapter.SelectCommand.Parameters.Add(sqLiteParameter);
                    }
                }

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                this.Dispose();
            }
        }

        private int SqlExecute(List<string> sqls)
        {
            int count = 0;
            try
            {
                if (conn == null)
                {
                    conn = new SQLiteConnection(connStr);
                }

                conn.Open();
                trans = conn.BeginTransaction();
                foreach (var sql in sqls)
                {
                    cmd = new SQLiteCommand(sql, conn);
                    count += cmd.ExecuteNonQuery();
                }

                return count;
            }
            catch (Exception e)
            {
                trans.Rollback();
                throw e;
            }
            finally
            {
                this.Dispose();
            }
        }

        private void Dispose()
        {
            if (trans != null)
            {
                trans.Dispose();
                trans = null;
            }

            if (adapter != null)
            {
                adapter.Dispose();
                adapter = null;
            }

            if (cmd != null)
            {
                cmd.Dispose();
                cmd = null;
            }

            if (conn != null)
            {
                conn.Close();
                conn.Dispose();
                conn = null;
            }
        }

        public DataTable Login(string username, string password)
        {
            string sql = "select * from sys_user where username = @username and password = @password";
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("username", username);
            param.Add("password", password);
            var dataTable = this.GetData(sql, param);
            if (dataTable.Rows.Count == 0)
            {
                throw new Exception("用户名或密码错误!");
            }

            return dataTable;
        }

        public int SaveDevices(List<DeviceEntity> deviceList)
        {
            int count = 0;
            try
            {
                conn = new SQLiteConnection(connStr);
                conn.Open();
                trans = conn.BeginTransaction();
                string sql = "delete from devices";

                cmd = new SQLiteCommand(sql, conn);
                cmd.ExecuteNonQuery(); //删除
                foreach (var item in deviceList)
                {
                    sql =
                        $"insert into devices (device_num,x,y,z,w,h,type_name) values('{item.DeviceNum}','{item.X}','{item.Y}','{item.Z}','{item.W}','{item.H}','{item.TypeName}')";
                    cmd.CommandText = sql;
                    var flag = cmd.ExecuteNonQuery(); // 插入
                    cmd.CommandText = $"delete from device_properties where d_num = '{item.DeviceNum}'";
                    cmd.ExecuteNonQuery();
                    foreach (var prop in item.DeviceProps)
                    {
                        string insertPropSql = $"insert into device_properties(d_num,prop_name,prop_value)" +
                                               $"values('{item.DeviceNum}','{prop.PropName}','{prop.PropValue}')";
                        cmd.CommandText = insertPropSql;
                        cmd.ExecuteNonQuery(); // 插入设备属性
                    }
                    string delVarsSql = $"delete from variables where d_num = {item.DeviceNum}";
                    cmd.CommandText = delVarsSql;
                    cmd.ExecuteNonQuery(); // 删除旧的变量
                    foreach (var variableEntity in item.Vars)
                    {
                        string insertVarSql = $"insert into variables(d_num,v_num,header,address,offset,modulus)" +
                                              $"values('{item.DeviceNum}','{variableEntity.VarNum}','{variableEntity.Header}','{variableEntity.Address}','{variableEntity.Offset}','{variableEntity.Modulus}')";
                        cmd.CommandText = insertVarSql;
                        cmd.ExecuteNonQuery(); // 删除旧的变量
                    }
                    count += flag;
                }

                if (count != deviceList.Count)
                {
                    throw new Exception("保存设备信息失败");
                }
                trans.Commit();
            }
            catch (Exception e)
            {
                trans.Rollback();
                throw e;
            }
            finally
            {
                this.Dispose();
            }


            return count;
        }

        public List<DeviceEntity> GetDeviceList()
        {
            string sql = "select * from devices";
            var dataTable = this.GetData(sql);
            var deviceList = dataTable.AsEnumerable().Select(d =>
            {
                return new DeviceEntity()
                {
                    Id = Convert.ToInt32(d["id"]),
                    DeviceNum = d["device_num"].ToString(),
                    X = d["x"].ToString(),
                    Y = d["y"].ToString(),
                    Z = d["z"].ToString(),
                    W = d["w"].ToString(),
                    H = d["h"].ToString(),
                    TypeName = d["type_name"].ToString()
                };
            }).ToList();
            return deviceList;
        }

        public List<ThumbEntity> GetThumbList()
        {
            string sql = "select * from thumbs";
            var dataTable = this.GetData(sql);
            return dataTable.AsEnumerable().Select(d =>
            {
                return new ThumbEntity()
                {
                    Icon = d["icon"].ToString(),
                    Header = d["header"].ToString(),
                    TargetType = d["target_type"].ToString(),
                    Width = Convert.ToInt32(d["width"]),
                    Height = Convert.ToInt32(d["height"]),
                    Category = d["category"].ToString()
                };
            }).ToList();
        }

        public List<PropertyEntity> GetPropertyList()
        {
            string sql = "select * from properties";
            var dataTable = this.GetData(sql);
            return dataTable.AsEnumerable().Select(d =>
            {
                return new PropertyEntity()
                {
                    Id = Convert.ToInt32(d["id"]),
                    PropHeader = d["p_header"].ToString(),
                    PropName = d["p_name"].ToString(),
                    PropType = d["p_type"].ToString() // 0:文本框；1:下拉框
                };
            }).ToList();
        }
    }
}