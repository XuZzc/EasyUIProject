using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserInfoModel
    {
        /// <summary>
        /// UserInfo 用户表
        /// </summary>
        public int UserID { get; set; }//ID
        public string UserName { get; set; }//用户名
        public string UserPwd { get; set; }//密码
        public int Age { get; set; }//年龄
        public string QQ { get; set; }//QQ
        public string Phone { get; set; }//电话
        public string Address { get; set; }//地址
        public DateTime CreateTime { get; set; }//注册时间
        public string UserType { get; set; }//用户权限

        /// <summary>
        /// Product 产品列表
        /// </summary>
        public int ProductID { get; set; }//产品ID
        public string ProductName { get; set; }//产品名称
        public string ProductPic { get; set; }//图片
        public decimal ProductPrice { get; set; }//产品价格
        public string ProductDesc { get; set; }//产品介绍
        public int ClassID { get; set; }//产品类别
        public DateTime AddTime { get; set; }//添加时间
       



    }
}
