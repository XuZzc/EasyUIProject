using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
using System.Data;
namespace BLL
{
  public   class ProductListBLL
    {
          /// <summary>
        /// 查询所有产品列表
        /// </summary>
        /// <returns></returns>
        public static List<UserInfoModel> GETselect()
        {
            return ProductDAL.GETselect();
        }
          
       /// <summary>
       /// 分页
       /// </summary>
       /// <returns></returns>
        public static List<UserInfoModel> GETselectPageSize(int pageSize, int pageIndex) 
        {
            return ProductDAL.GETselectPageSize(pageSize, pageIndex);        
        }
        /// <summary>
        /// 根据Id删除
        /// </summary>
        /// <param name="Pid"></param>
        /// <returns></returns>
        public static bool DeleteById(int Pid)
        {
            return ProductDAL.DeleteById(Pid);
        }

        /// <summary>
        /// 批量删除方法
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool DelMovie(List<UserInfoModel> list)
        {
            return ProductDAL.DelMovie(list);
        }
       /// <summary>
        /// 保存修改
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static string[] Update(UserInfoModel m)
        {
            return ProductDAL.Update(m);
        
        }
          
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static string[] Insertadd(UserInfoModel m) {
            return ProductDAL.Insertadd(m);     
        }
        /// <summary>
        /// 查询所有的类别
        /// </summary>
        /// <returns></returns>
        public static DataTable GetProClass()
        {
            return ProductDAL.GetProClass();
        }

        /// <summary>
        /// 根据类别查询
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="ClassId"></param>
        /// <returns></returns>
        public static List<UserInfoModel> SelectByCid(int ClassId)
        {
            return ProductDAL.SelectByCid(ClassId);
        }




    }
}
