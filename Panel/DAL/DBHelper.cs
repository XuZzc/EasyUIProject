using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DAL
{
    public class DBHelper
    {
        //1、数据库连接字符串
        public static string connectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
        
        /// <summary>
        /// 2、根据sql查询表返回datatable（查询）
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDataTableBySql(string sql)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            try
            {
                sda.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 3、执行sql（删除添加编辑）
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static bool ExcuteSql(string sql)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand com = new SqlCommand(sql, conn);
            try
            {
                com.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }


        /// <summary>
        /// 4、查询sql单行单列值（聚合函数或者单个值）
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int GetSingleBySql(string sql)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand com = new SqlCommand(sql, conn);
            int result = 0;
            try
            {
                result = (int)com.ExecuteScalar();
                return result;
            }
            catch
            {
                return result;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 5、完成对数据的增加、删除和修改操作 (适用于EasyUI)
        /// </summary>
        /// <param name="strSQL">SQL语句</param>
        /// <returns>提示信息</returns>
        public static string[] operatorALL(string strSQL)
        {
            string[] arrstrA = new string[2];
            string strChk = "1";//成功
            string strInfo = "操作成功";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(strSQL, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                strChk = "0";//失败
                strInfo = "操作失败：" + ex.Message;
            }
            arrstrA[0] = strChk;
            arrstrA[1] = strInfo;
            return arrstrA;
        }

        /// <summary>
        ///6、 执行存储过程获得数据集
        /// </summary>
        /// <param name="proName">存储过程名</param>
        /// <param name="paras">存储过程参数</param>
        /// <returns>DataTable数据集</returns>
        public static DataTable GetDataTableByProcedure(string proName, SqlParameter[] paras)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(proName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            for (int i = 0; i < paras.Length; i++)
            {
                cmd.Parameters.Add(paras[i]);
            }
            try
            {
                da.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
            finally
            {
                conn.Close();
            }

        }
    }
}