using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Model;
namespace DAL
{
  public class UserInfoDAL
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public static List<UserInfoModel> LoginList(string name, string pwd)
        {
            List<UserInfoModel> loginCls = GetList();
            List<UserInfoModel> listFind = loginCls.FindAll(delegate(UserInfoModel user)
            {
                return user.UserName.Equals(name) && user.UserPwd.Equals(pwd);
            });

            return listFind;

        }

        /// <summary>
        /// 查询所有用户
        /// </summary>
        /// <returns></returns>
        public static List<UserInfoModel> GetList()
        {
            string sql = "select * from UserInfo";
            DataTable dt = DBHelper.GetDataTableBySql(sql);
            List<UserInfoModel> list = new List<UserInfoModel>();
            if (dt != null && dt.Rows.Count >= 1)
            {
                foreach (DataRow item in dt.Rows)
                {
                    UserInfoModel user = new UserInfoModel();
                    user.UserID = int.Parse(item["UserID"].ToString());
                    user.UserName = item["UserName"].ToString();                   
                    user.UserPwd = item["UserPwd"].ToString();
                    user.Age = int.Parse (item["Age"].ToString());
                    user.QQ = item["QQ"].ToString();
                    user.Phone = item["Phone"].ToString();
                    user.Address = item["Address"].ToString();
                    user.CreateTime = DateTime.Now;
                    user.UserType = item["UserType"].ToString();
                    list.Add(user);
                }
                return list;
            }
            else
            {
                return null;
            }
        }

      /// <summary>
      /// 注册
      /// </summary>
      /// <returns></returns>
        //public static string[] InsertAdd(UserInfoModel m)
        //{
        //    string sql = string.Format(@"insert into UserInfo values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','普通用户  ')",m.UserName,m.UserPwd,m.Age,m.QQ,m.Phone,m.Address,DateTime.Now);
          
        
        
        
        //}




    }
}
