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
    public partial class DelProByAllID : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string pid = Request.Form["ids"].ToString();
            List<UserInfoModel> list = JsonConvert.DeserializeObject<List<UserInfoModel>>(pid);
            bool flag = ProductListBLL.DelMovie(list);
            Response.Write(JsonConvert.SerializeObject(flag));
        }
    }
}