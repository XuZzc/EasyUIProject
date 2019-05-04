using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using Newtonsoft.Json;
namespace WebPanel.ASPContent
{
    public class MessageInfo { 
    //1操作失败  ，0操作成功
        public int intchk { get; set; }
        public string strMsg { get; set; }
    }
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["userName"] != null && Request["userPwd"] != null)
            {
                MessageInfo msg = new MessageInfo();
                string name = Request["userName"].ToString();
                string pwd = Request["userPwd"].ToString();
                List<UserInfoModel> list = UserInfoBLL.LoginList(name, pwd);

                if (list.Count > 0)
                {
                    Response.Write("{");
                    Response.Write("\"intchk\":0,");
                    Response.Write("\"strMsg\":\"登录成功！\",");
                    Response.Write("\"rows\":");
                    Response.Write(JsonConvert.SerializeObject(list));
                    Response.Write("}");
                }
                else
                {
                    msg.intchk = 1;
                    msg.strMsg = "登录失败！";
                    Response.Write(JsonConvert.SerializeObject(msg));

                }
            }
         


        }
    }
}