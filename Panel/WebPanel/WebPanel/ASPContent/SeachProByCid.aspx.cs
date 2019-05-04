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
    public partial class SeachProByCid : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int cid = int.Parse(Request["cid"].ToString());
            //int pageIndex = int.Parse(Request["page"].ToString());
            //int pageSize = int.Parse(Request["rows"].ToString());
            List<UserInfoModel> plist = ProductListBLL.SelectByCid(cid);
            // 拼接json 集合 字符串，序列化到前台展示商品数据
            Response.Write("{\"total\":" + ProductListBLL.SelectByCid(cid).Count + ",\"rows\":" +
             JsonConvert.SerializeObject(plist)
             + "}");
        }
    }
}