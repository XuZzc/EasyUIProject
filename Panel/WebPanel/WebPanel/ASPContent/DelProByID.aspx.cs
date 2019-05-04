using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Newtonsoft.Json;


namespace WebPanel.ASPContent
{
    public partial class DelProByID : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int pid =int.Parse( Request["id"].ToString());
            bool flag = ProductListBLL.DeleteById(pid);
            Response.Write(JsonConvert.SerializeObject(flag));
        }
    }
}