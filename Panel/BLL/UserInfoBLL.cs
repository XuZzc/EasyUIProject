using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
namespace BLL
{
    public class UserInfoBLL
    {
          /// <summary>
        /// 登录
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public static List<UserInfoModel> LoginList(string name, string pwd)
        {
            return UserInfoDAL.LoginList(name, pwd);
        }
    }
}
