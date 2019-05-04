using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
namespace WebPanel.ASPContent
{
    public partial class ProClassList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = ProductListBLL.GetProClass();
            Response.Write(JsonConvert.SerializeObject(dt));
        }
    }
}