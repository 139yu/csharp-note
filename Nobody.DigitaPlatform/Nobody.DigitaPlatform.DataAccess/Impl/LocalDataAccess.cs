using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Nobody.DigitaPlatform.Entities;

namespace Nobody.DigitaPlatform.DataAccess.Impl
{
    public class LocalDataAccess : ILocalDataAccess
    {
        private object lockObj = new object();
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
            lock (lockObj)
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

                    trans.Commit();
                    return count;
                }
                catch (Exception e)
                {
                    trans?.Rollback();
                    throw e;
                }
                finally
                {
                    this.Dispose();
                }
            }
        }

        private void Dispose()
        {
            lock (lockObj)
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

        public int SaveTrend(List<TrendEntity> trends)
        {
            int count = 0;
            try
            {
                conn = new SQLiteConnection(connStr);
                conn.Open();
                trans = conn.BeginTransaction();
                string sql = "delete from trend;delete from section;delete from series;delete from axis;";
                cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                foreach (var item in trends)
                {
                    sql = "insert into trend(t_num,trend_header,show_legend) " +
                          $"values('{item.TNum}','{item.TrendHeader}','{item.ShowLegend}')";
                    cmd.CommandText = sql;
                    var flag = cmd.ExecuteNonQuery(); // 插入
                    count += flag;

                    foreach (var a in item.TrendAxisList)
                    {
                        sql =
                            "insert into axis(trend_num,axis_num,title,show_title,min,max,show_seperator,label_formatter,position) " +
                            $"values('{item.TNum}','{a.ANum}','{a.Title}','{a.IsShowTitle.ToString()}','{a.Minimum}','{a.Maximum}','{a.IsShowSeperator.ToString()}','{a.LabelFormatter}','{a.Position}')";
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery(); // 插入

                        foreach (var s in a.Sections)
                        {
                            sql = "insert into section(axis_num,value,color) " +
                                  $"values('{a.ANum}','{s.Value}','{s.Color}')";
                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery(); // 插入
                        }
                    }

                    // 保存对应的点位信息
                    // 清除点位前,需要将报警条件\联控条件清除,再重新添加
                    foreach (var s in item.Series)
                    {
                        sql = "insert into series(d_num,v_num,t_num,title,color,axis_index)" +
                              $" values('{s.DNum}','{s.VNum}','{item.TNum}','{s.Title}','{s.Color}','{s.AxisNum}')";
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery(); // 插入
                    }
                }

                if (count != trends.Count)
                    throw new Exception("设备数据未完全保存");

                trans.Commit();
            }
            catch (Exception e)
            {
                trans?.Rollback();
                throw e;
            }

            return count;
        }

        public List<TrendEntity> GetTrends()
        {
            string sql = "select * from trend";
            DataTable dt_trend = this.GetData(sql, null);

            sql = $"select * from axis";
            DataTable dt_axis = this.GetData(sql, null);

            sql = $"select * from section";
            DataTable dt_section = this.GetData(sql, null);

            sql = $"select * from series";
            DataTable dt_series = this.GetData(sql, null);

            var result = dt_trend.AsEnumerable().Select(dt =>
            {
                return new TrendEntity()
                {
                    TNum = dt["t_num"].ToString(),
                    TrendHeader = dt["trend_header"].ToString(),
                    ShowLegend = bool.Parse(dt["show_legend"].ToString()),

                    TrendAxisList = dt_axis.AsEnumerable()
                        .Where(da => da["trend_num"].ToString() == dt["t_num"].ToString())
                        .Select(da => new TrendAxisEntity()
                        {
                            ANum = da["axis_num"].ToString(),
                            Title = da["title"].ToString(),
                            IsShowTitle = bool.Parse(da["show_title"].ToString()),
                            Minimum = da["min"].ToString(),
                            Maximum = da["max"].ToString(),
                            IsShowSeperator = bool.Parse(da["show_seperator"].ToString()),
                            LabelFormatter = da["label_formatter"].ToString(),
                            Position = da["position"].ToString(),

                            Sections = dt_section.AsEnumerable()
                                .Where(ds => ds["axis_num"].ToString() == da["axis_num"].ToString())
                                .Select(ds => new TrendSectionEntity()
                                {
                                    Value = ds["value"].ToString(),
                                    Color = ds["color"].ToString()
                                }).ToList()
                        }).ToList(),

                    Series = dt_series.AsEnumerable().Where(ds => ds["t_num"].ToString() == dt["t_num"].ToString())
                        .Select(ds => new TrendSeriesEntity()
                        {
                            DNum = ds["d_num"].ToString(),
                            VNum = ds["v_num"].ToString(),
                            Title = ds["title"].ToString(),
                            Color = ds["color"].ToString(),
                            AxisNum = ds["axis_index"].ToString()
                        }).ToList()
                };
            });
            return result.ToList();
        }

        public int SaveDevices(List<DeviceEntity> deviceList)
        {
            int count = 0;
            try
            {
                conn = new SQLiteConnection(connStr);
                conn.Open();
                trans = conn.BeginTransaction();
                string delSql =
                    "delete from devices;delete from device_properties;delete from conditions;delete from variables;" +
                    "delete from manual_controls;delete from manual_controls;";
                cmd = conn.CreateCommand();
                cmd.CommandText = delSql;
                cmd.ExecuteNonQuery(); // 删除旧的变量
                foreach (var item in deviceList)
                {
                    string sql =
                        $"insert into devices (device_name ,device_num,x,y,z,w,h,rotate,flow_direction,type_name) values('{item.DeviceName}','{item.DeviceNum}','{item.X}','{item.Y}','{item.Z}','{item.W}','{item.H}','{item.Rotate}','{item.FlowDirection}','{item.TypeName}')";
                    cmd.CommandText = sql;
                    var flag = cmd.ExecuteNonQuery(); // 插入

                    foreach (var prop in item.DeviceProps)
                    {
                        string insertPropSql = $"insert into device_properties(d_num,prop_name,prop_value)" +
                                               $"values('{item.DeviceNum}','{prop.PropName}','{prop.PropValue}')";
                        cmd.CommandText = insertPropSql;
                        cmd.ExecuteNonQuery();
                    }

                    foreach (var m in item.ManualControls)
                    {
                        if (string.IsNullOrEmpty(m.Address) || string.IsNullOrEmpty(m.Value)) continue;

                        sql = "insert into manual_controls(d_num,c_header,c_address,c_value)" +
                              $" values('{item.DeviceNum}','{m.Header}','{m.Address}','{m.Value}')";
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery(); // 插入
                    }

                    foreach (var variableEntity in item.Vars)
                    {
                        string insertVarSql =
                            $"insert into variables(d_num,v_num,header,address,offset,modulus,var_type)" +
                            $"values('{item.DeviceNum}','{variableEntity.VarNum}','{variableEntity.Header}','{variableEntity.Address}','{variableEntity.Offset}','{variableEntity.Modulus}','{variableEntity.VarType}')";
                        cmd.CommandText = insertVarSql;
                        cmd.ExecuteNonQuery();
                        foreach (var condition in variableEntity.Conditions)
                        {
                            string insertConditionSql =
                                $"insert into conditions(c_num,var_num,operator,value,message)" +
                                $"values('{condition.CNum}','{variableEntity.VarNum}','{condition.Operator}','{condition.CompareValue}','{condition.AlarmContent}')";
                            cmd.CommandText = insertConditionSql;
                            cmd.ExecuteNonQuery();
                        }

                        foreach (var condition in variableEntity.UnionConditions)
                        {
                            string insertConditionSql =
                                $"insert into conditions(c_num,var_num,operator,value,message)" +
                                $"values('{condition.CNum}','{condition.VarNum}','{condition.Operator}','{condition.CompareValue}','{condition.AlarmContent}')";
                            cmd.CommandText = insertConditionSql;
                            cmd.ExecuteNonQuery();
                            foreach (var unionDevice in condition.UnionDeviceList)
                            {
                                string insertSql = "insert into union_devices(c_num,u_num,d_num,v_addr,value,v_type)" +
                                                   $"values('{condition.CNum}','{unionDevice.UNum}','{unionDevice.DNum}','{unionDevice.VAddr}','{unionDevice.Value}','{unionDevice.VType}')";
                                cmd.CommandText = insertSql;
                                cmd.ExecuteNonQuery();
                            }
                        }
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
            var deviceTable = this.GetData(sql);
            sql = "select * from variables";
            var vars = this.GetData(sql);
            sql = "select * from device_properties";
            var props = this.GetData(sql);
            sql = "select * from conditions";
            var conditions = this.GetData(sql);
            sql = "select * from manual_controls";
            var manuals = this.GetData(sql);
            sql = "select * from union_devices";
            var unionDevices = this.GetData(sql);
            var deviceList = deviceTable.AsEnumerable().Select(d =>
            {
                return new DeviceEntity()
                {
                    Id = Convert.ToInt32(d["id"]),
                    DeviceName = d["device_name"].ToString(),
                    DeviceNum = d["device_num"].ToString(),
                    X = d["x"].ToString(),
                    Y = d["y"].ToString(),
                    Z = d["z"].ToString(),
                    W = d["w"].ToString(),
                    H = d["h"].ToString(),
                    FlowDirection = d["flow_direction"].ToString(),
                    TypeName = d["type_name"].ToString(),
                    Rotate = d["rotate"].ToString(),
                    Vars = vars.AsEnumerable()
                        .Where(dv => dv["d_num"].Equals(d["device_num"]))
                        .Select(dv =>
                        {
                            return new VariableEntity()
                            {
                                Id = Convert.ToInt32(dv["id"]),
                                DeviceNum = dv["d_num"].ToString(),
                                VarNum = dv["v_num"].ToString(),
                                Header = dv["header"].ToString(),
                                Address = dv["address"].ToString(),
                                Offset = double.Parse(dv["offset"].ToString()),
                                Modulus = double.Parse(dv["modulus"].ToString()),
                                VarType = dv["var_type"].ToString(),
                                Conditions = conditions.AsEnumerable()
                                    .Where(c => c["var_num"].Equals(dv["v_num"]) &&
                                                !c["c_num"].ToString().StartsWith("U"))
                                    .Select(c => new ConditionEntity()
                                    {
                                        VarNum = c["var_num"].ToString(),
                                        CNum = c["c_num"].ToString(),
                                        Operator = c["operator"].ToString(),
                                        CompareValue = c["value"].ToString(),
                                        AlarmContent = c["message"].ToString()
                                    }).ToList(),
                                UnionConditions = conditions.AsEnumerable()
                                    .Where(c => c["var_num"].Equals(dv["v_num"]) &&
                                                c["c_num"].ToString().StartsWith("U"))
                                    .Select(c => new ConditionEntity()
                                    {
                                        VarNum = c["var_num"].ToString(),
                                        CNum = c["c_num"].ToString(),
                                        Operator = c["operator"].ToString(),
                                        CompareValue = c["value"].ToString(),
                                        AlarmContent = c["message"].ToString(),
                                        UnionDeviceList = unionDevices.AsEnumerable()
                                            .Where(u => c["c_num"].Equals(u["c_num"]))
                                            .Select(du => new UnionDeviceEntity()
                                            {
                                                UNum = du["u_num"].ToString(),
                                                DNum = du["d_num"].ToString(),
                                                VAddr = du["v_addr"].ToString(),
                                                Value = du["value"].ToString(),
                                                VType = du["v_type"].ToString()
                                            })
                                            .ToList()
                                    }).ToList()
                            };
                        }).ToList(),
                    DeviceProps = props.AsEnumerable()
                        .Where(dp => dp["d_num"].Equals(d["device_num"]))
                        .Select(dp => new DevicePropEntity()
                        {
                            PropName = dp["prop_name"].ToString(),
                            PropValue = dp["prop_value"].ToString()
                        }).ToList(),
                    ManualControls = manuals.AsEnumerable()
                        .Where(m => m["d_num"].Equals(d["device_num"]))
                        .Select(m => new ManualEntity()
                        {
                            Header = m["c_header"].ToString(),
                            Address = m["c_address"].ToString(),
                            DNum = m["d_num"].ToString(),
                            Value = m["c_value"].ToString()
                        })
                        .ToList()
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


        public int SaveAlarmMessage(AlarmEntity alarm)
        {
            string sql =
                "insert into alarms(a_num,c_num,d_num,v_num,content,date_time,level,state,alarm_value,user_id)" +
                $"values('{alarm.AlarmNum}','{alarm.CNum}','{alarm.DeviceNum}','{alarm.VariableNum}','{alarm.AlarmContent}','{alarm.RecordTime}','{alarm.AlarmLevel}','{alarm.State}','{alarm.RecordValue}','{alarm.UserId}')";
            return this.SqlExecute(new List<string> { sql });
        }

        public List<AlarmEntity> GetAlarmList(string condition)
        {
            string sql = "select a.*,b.device_name d_header,d.header v_header,e.real_name from alarms a " +
                         "LEFT JOIN devices b on b.device_num=a.d_num " +
                         "LEFT JOIN variables d on d.v_num=a.v_num " +
                         "LEFT JOIN sys_user e ON e.username=a.user_id " +
                         "where 1=1 ";

            if (!string.IsNullOrEmpty(condition))
            {
                sql += $" and (a.d_num LIKE '%{condition}%' or" +
                       $" b.device_name LIKE '%{condition}%' or" +
                       $" a.v_num LIKE '%{condition}%' or" +
                       $" d.header LIKE '%{condition}%' or" +
                       $" content LIKE '%大%') ";
            }

            sql += "order by a.date_time desc";

            // 字段到实体的映射
            return this.GetDatas<AlarmEntity>(sql, null);
        }

        public int UpdateAlarmState(string alarmNum, string solveTime)
        {
            string sql = $"update alarms set state = '1',solve_time='{solveTime}' where a_num = '{alarmNum}'";
            return this.SqlExecute(new List<string> { sql });
        }

        private List<T> GetDatas<T>(string sql, Dictionary<string, string> param = null)
        {
            List<T> list = new List<T>();
            var dataTable = this.GetData(sql, param);
            var properties = typeof(T).GetProperties();
            foreach (DataRow row in dataTable.Rows)
            {
                var instance = Activator.CreateInstance<T>();
                foreach (var p in properties)
                {
                    var columnAttr = (ColumnAttribute)p.GetCustomAttribute(typeof(ColumnAttribute));
                    if (columnAttr == null) continue;
                    if (dataTable.Columns.Contains(columnAttr.Name))
                    {
                        p.SetValue(instance, row[columnAttr.Name].ToString());
                    }
                }

                list.Add(instance);
            }

            return list;
        }

        public List<RecordReadEntity> GetRecords()
        {
            string sql = "SELECT " +
                         "var_name, " +
                         "var_num, " +
                         "device_num," +
                         "device_name," +
                         "record_value as last_value, " +
                         "AVG( record_value ) AS avg, " +
                         "Max( record_value ) AS max, " +
                         "min( record_value ) AS min, " +
                         "SUM( CASE WHEN alarm_num = '' OR alarm_num ISNULL THEN 0 ELSE 1 END ) alarm_count, " +
                         "SUM( CASE WHEN union_num = '' OR union_num ISNULL THEN 0 ELSE 1 END ) union_count , " +
                         "datetime(MAX(strftime('%s',record_time)),'unixepoch') last_time, " +
                         "count(1) record_count " +
                         "FROM Record " +
                         "GROUP BY device_num,var_num";
            return this.GetDatas<RecordReadEntity>(sql, null);
        }

        public int SaveRecord(List<RecordWriteEntity> records)
        {
            List<string> sqls = new List<string>();
            foreach (var item in records)
            {
                string sql =
                    "insert into record(device_num,device_name,var_num,var_name,record_value,alarm_num,union_num,record_time,user_name)" +
                    $" values('{item.DeviceNum}','{item.DeviceName}','{item.VarNum}','{item.VarName}','{item.RecordValue}','{item.AlarmNum}','{item.UnionNum}','{item.RecordTime}','{item.UserName}')";
                sqls.Add(sql);
            }

            return this.SqlExecute(sqls);
        }

        public List<UserEntity> getUserList()
        {
            return this.GetDatas<UserEntity>("select * from sys_user");
        }

        public void SaveSettings(List<BaseInfoEntity> configs, List<UserEntity> users)
        {
            List<string> sqls = new List<string>()
                { "delete from base_info;"};

            foreach (var item in configs)
            {
                string sql = "insert into base_info(b_num,header,content,value,d_num,v_num,type)" +
                             $" values('{item.BaseNum}','{item.Header}','{item.Description}','{item.Value}','{item.DeviceNum}','{item.VariableNum}','{item.type}')";
                sqls.Add(sql);
            }

            sqls.Add("delete from sys_user;");
            foreach (var item in users)
            {
                string sql = "insert into sys_user(username,password,user_type,real_name,gender,phone_num) " +
                             $"values('{item.Username}','{item.Password}','{item.UserType}','{item.RealName}','{item.Gender}','{item.PhoneNum}')";
                sqls.Add(sql);
            }

            this.SqlExecute(sqls);
        }

        public List<BaseInfoEntity> GetBaseInfos()
        {
            return this.GetDatas<BaseInfoEntity>("select * from base_info");
        }
    }
}