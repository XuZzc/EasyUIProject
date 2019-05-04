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
    public partial class Addregist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string proName = Request["proName"].ToString();
            string proimg = Request["proimg"].ToString();
            decimal proprice = decimal.Parse(Request["proprice"].ToString());
            string prodeil = Request["prodeil"].ToString();
            //int protype = int.Parse(Request["protype"].ToString());
            int protype = 1;
            UserInfoModel m = new UserInfoModel();
            m.ProductName = proName;
            m.ProductPic = proimg;
            m.ProductPrice = proprice;
            m.ProductDesc = prodeil;
            m.ClassID = protype;
            m.AddTime = DateTime.Now;
            string[] strArr = ProductListBLL.Insertadd(m);
        
            Response.Write(JsonConvert.SerializeObject(strArr));
           


        




        }
    }
}