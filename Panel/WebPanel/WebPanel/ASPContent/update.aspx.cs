using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using Newtonsoft.Json;
namespace WebPanel.ASPContent
{
    
    public partial class update : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            int ProductID = int.Parse(Request["ProductID"].ToString());
            string ProductName = Request["ProductName"].ToString();
            string ProductPic = Request["ProductPic"].ToString();
            decimal ProductPrice = decimal.Parse(Request["ProductPrice"].ToString());
            string ProductDesc = Request["ProductDesc"].ToString();
            DateTime AddTime = DateTime.Parse(Request["AddTime"].ToString());
            UserInfoModel m=new UserInfoModel ();
            m.ProductID=ProductID;
            m.ProductName=ProductName;
            m.ProductPic=ProductPic;
            m.ProductPrice=ProductPrice;
            m.ProductDesc=ProductDesc;
            m.AddTime=AddTime;
            string[] strArr = ProductListBLL.Update(m);
            Response.Write("{");
            Response.Write("\"strChk\":" + strArr[0] + ",");
            Response.Write("\"strInfo\":\"" + strArr[1] + "\"");        
            Response.Write("}");



        }
    }
}