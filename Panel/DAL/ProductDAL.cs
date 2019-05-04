using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class ProductDAL
    {
        /// <summary>
        /// 查询所有产品列表
        /// </summary>
        /// <returns></returns>
        public static List<UserInfoModel> GETselect()
        {
            string sql = string.Format(@"select * from  Product");
            DataTable dt = DBHelper.GetDataTableBySql(sql);
            List<UserInfoModel> list = new List<UserInfoModel>();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    UserInfoModel m = new UserInfoModel();
                    m.ProductID = int.Parse(item["ProductID"].ToString());
                    m.ProductName = item["ProductName"].ToString();
                    m.ProductPic = item["ProductPic"].ToString();
                    m.ProductPrice = decimal.Parse(item["ProductPrice"].ToString());
                    m.ProductDesc = item["ProductDesc"].ToString();
                    m.ClassID = int.Parse(item["ClassID"].ToString());
                    m.AddTime = DateTime.Parse(item["AddTime"].ToString());
                    list.Add(m);
                }
                return list;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <returns></returns>
        public static List<UserInfoModel> GETselectPageSize(int pageSize, int pageIndex)
        {
            string sql = string.Format(@"select top {0} * from Product where ProductID not in
                                      (select top {1} ProductID from Product order by ProductID)
                                       order by ProductID", pageSize, pageSize * (pageIndex - 1));
            DataTable dt = DBHelper.GetDataTableBySql(sql);
            List<UserInfoModel> plist = new List<UserInfoModel>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                UserInfoModel p = new UserInfoModel();
                p.ProductID = int.Parse(dt.Rows[i]["ProductID"].ToString());
                p.ProductName = dt.Rows[i]["ProductName"].ToString();
                p.ProductPic = dt.Rows[i]["ProductPic"].ToString();
                p.ProductPrice = decimal.Parse(dt.Rows[i]["ProductPrice"].ToString());
                p.ProductDesc = dt.Rows[i]["ProductDesc"].ToString();
                p.AddTime = DateTime.Parse(dt.Rows[i]["AddTime"].ToString());
                plist.Add(p);
            }

            return plist;

        }

        /// <summary>
        /// 根据Id删除
        /// </summary>
        /// <param name="Pid"></param>
        /// <returns></returns>
        public static bool DeleteById(int Pid)
        {
            string sql = string.Format("delete from Product where ProductID={0}", Pid);
            return DBHelper.ExcuteSql(sql);
        }
        /// <summary>
        /// 批量删除方法
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool DelMovie(List<UserInfoModel> list)
        {
            string sql = "";
            foreach (UserInfoModel model in list)
            {
                sql += "delete from Product where ProductID=" + model.ProductID + ";";
            }
            return DBHelper.ExcuteSql(sql);
        }
        /// <summary>
        /// 保存修改
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static string[] Update(UserInfoModel m)
        {
            string sql = string.Format(@"update Product set ProductName='{0}',ProductPrice='{1}',ProductDesc='{2}',AddTime='{3}'where ProductID='{4}'", m.ProductName, m.ProductPrice, m.ProductDesc, m.AddTime,m.ProductID);
            string[] strAry = DBHelper.operatorALL(sql);
            return strAry;       
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static string[] Insertadd(UserInfoModel m) {
            string sql = string.Format(@"insert into Product values('{0}','{1}','{2}','{3}','{4}','{5}')", m.ProductName,m.ProductPic,m.ProductPrice,m.ProductDesc,m.ClassID,m.AddTime);
            string[] strAry = DBHelper.operatorALL(sql);
            return strAry;      
        }

        /// <summary>
        /// 查询所有的类别
        /// </summary>
        /// <returns></returns>
        public static DataTable GetProClass()
        {
            string sql = "select * from ProductClass";
            return DBHelper.GetDataTableBySql(sql);
        }
        /// <summary>
        /// 根据类别查询
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="ClassId"></param>
        /// <returns></returns>
        public static List<UserInfoModel> SelectByCid(int ClassId)
        {
            string sql = string.Format(@"select  * from Product where ClassID={0}", ClassId);

            DataTable dt = DBHelper.GetDataTableBySql(sql);
            List<UserInfoModel> plist = new List<UserInfoModel>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                UserInfoModel p = new UserInfoModel();
                p.ProductID = int.Parse(dt.Rows[i]["ProductID"].ToString());
                p.ProductName = dt.Rows[i]["ProductName"].ToString();
                p.ProductPic = dt.Rows[i]["ProductPic"].ToString();
                p.ClassID = int.Parse(dt.Rows[i]["ClassId"].ToString());
                p.ProductPrice = decimal.Parse(dt.Rows[i]["ProductPrice"].ToString());
                p.ProductDesc = dt.Rows[i]["ProductDesc"].ToString();
                p.AddTime = DateTime.Parse(dt.Rows[i]["AddTime"].ToString());
                plist.Add(p);
            }

            return plist;
        }




    }
}
