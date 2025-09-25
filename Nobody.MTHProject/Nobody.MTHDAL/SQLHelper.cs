using System;
using System.Collections.Generic;

using System.Data.SqlClient;
using System.Data;

using System.Configuration;

namespace Nobody.MTHDAL
{
    /// <summary>
    /// ͨ�����ݷ�����
    /// </summary>
    public class SQLHelper
    {
        //��ȡ�����ļ���������ַ���
        private static string connString = ConfigurationManager.ConnectionStrings["connString"].ToString();

        /// <summary>
        /// ִ��insert��update��delete���͵�SQL���
        /// </summary>
        /// <param name="cmdText">SQL����洢��������</param>
        /// <param name="paramArray">��������</param>
        /// <returns>��Ӱ�������</returns>
        public static int ExecuteNonQuery(string cmdText, SqlParameter[] paramArray = null)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            if (paramArray != null)
            {
                cmd.Parameters.AddRange(paramArray);
            }
            try
            {
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string errorMsg = $"{DateTime.Now}  : ִ�� public static int ExecuteNonQuery(string cmdText, SqlParameter[] paramArray = null)���������쳣��{ex.Message}";
                //������ط�д����־...


                throw new Exception("ִ��public static int ExecuteNonQuery(string cmdText, SqlParameter[] paramArray = null)���������쳣��" + ex.Message);
            }
            finally   //���ϲ����Ƿ����쳣������ִ�еĴ���
            {
                conn.Close();
            }
        }

        /// <summary>
        /// ���ص�һ����Ĳ�ѯ
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string cmdText, SqlParameter[] paramArray = null)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            if (paramArray != null)
            {
                cmd.Parameters.AddRange(paramArray);
            }
            try
            {
                conn.Open();
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                //������ط�д����־...

                throw new Exception("ִ�� public object ExecuteScalar(string cmdText, SqlParameter[] paramArray = null���������쳣��" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// ִ�з���һ��ֻ��������Ĳ�ѯ
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string cmdText, SqlParameter[] paramArray = null)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            if (paramArray != null)
            {
                cmd.Parameters.AddRange(paramArray);
            }
            try
            {
                conn.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection); //����������ö��
            }
            catch (Exception ex)
            {
                //������ط�д����־...

                throw new Exception("ִ�� public object SqlDataReader(string cmdText, SqlParameter[] paramArray = null)���������쳣��" + ex.Message);
            }
        }
        /// <summary>
        /// ���ذ���һ�����ݱ�����ݼ��Ĳ�ѯ
        /// </summary>
        /// <param name="sql">��ѯ���</param>
        /// <param name="tableName">���ݱ������</param>
        /// <returns></returns>
        public static DataSet GetDataSet(string sql, string tableName = null)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                if (tableName == null)
                    da.Fill(ds);
                else
                    da.Fill(ds, tableName);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("ִ�� public DataSet GetDataSet(string sql, string tableName = null)���������쳣��" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// ���ذ���һ�����ݱ�����ݼ��Ĳ�ѯ
        /// </summary>
        /// <param name="sql">��ѯ���</param>
        /// <param name="tableName">���ݱ������</param>
        /// <returns></returns>
        public static DataSet GetDataSet(string sql, SqlParameter[] paramArray = null, string tableName = null)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (paramArray != null)
            {
                cmd.Parameters.AddRange(paramArray);
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                if (tableName == null)
                    da.Fill(ds);
                else
                    da.Fill(ds, tableName);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("ִ�� public DataSet GetDataSet(string sql, string tableName = null)���������쳣��" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// ִ�в�ѯ������һ���������DataSet
        /// </summary>
        /// <param name="dicTableAndSql"></param>
        /// <returns></returns>
        public static DataSet GetDataSet(Dictionary<string, string> dicTableAndSql)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                foreach (string tbName in dicTableAndSql.Keys)
                {
                    cmd.CommandText = dicTableAndSql[tbName];
                    da.Fill(ds, tbName);
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("ִ�� public DataSet GetDataSet(Dictionary<string,string> dicTableAndSql)���������쳣��" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// ���������ύ
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paramArrayList"></param>
        /// <returns></returns>
        public static bool ExecuteNonQueryByTran(string sql, List<SqlParameter[]> paramArrayList)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            try
            {
                conn.Open();
                cmd.Transaction = conn.BeginTransaction();   //��������
                cmd.CommandText = sql;
                foreach (SqlParameter[] param in paramArrayList)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddRange(param);
                    cmd.ExecuteNonQuery();
                }
                cmd.Transaction.Commit();  //�ύ����(ͬʱ�Զ��������)
                return true;
            }
            catch (Exception ex)
            {
                if (cmd.Transaction != null)
                    cmd.Transaction.Rollback();//�ع�����(ͬʱ�Զ��������)
                throw new Exception("ExecuteNonQueryByTran(string sql,List<SqlParameter[]> paramArrayList)ʱ���ִ���" + ex.Message);
            }
            finally
            {
                if (cmd.Transaction != null)
                    cmd.Transaction = null;
                conn.Close();
            }
        }


    }
}
