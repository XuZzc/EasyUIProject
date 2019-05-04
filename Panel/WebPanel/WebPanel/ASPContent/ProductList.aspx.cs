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
    public partial class ProductList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["page"] != null && Request["rows"] != null)
            {
                //获取当前索引
                int pageIndex = int.Parse(Request["page"].ToString());
                //获取每页条数
                int pageSize = int.Parse(Request["rows"].ToString());
                List<UserInfoModel> list = ProductListBLL.GETselectPageSize(pageSize,pageIndex);
                //拼接字符，序列化到前台展示数据
                Response.Write("{\"total\":" + ProductListBLL.GETselect().Count + ",\"rows\":" + JsonConvert.SerializeObject(list) + "}");
            }
            else {
                List<UserInfoModel> list = ProductListBLL.GETselect();
                Response.Write("{\"total\":" + list.Count + ",\"rows\":" + JsonConvert.SerializeObject(list) + "}");
            }
         

        }
    }
}