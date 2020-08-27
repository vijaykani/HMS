using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using HMS.DAO;
using System.Reflection;
using HMS.Model.Model;

namespace HMS.Controllers
{
    public class AdministrationController : Controller
    {

        //private ConnectionDao objConnectionDao;
        private SqlConnection objSqlConnection;
        private SqlTransaction objSqlTransaction;
        private SqlCommand objSqlCommand;

        //public ActionResult Index()
        //{
        //    #region Local Variables
        //    ResultDto objResultDto = new ResultDto();
        //    objConnectionDao = new ConnectionDao();
        //    objSqlCommand = new SqlCommand();
        //    objSqlConnection = objConnectionDao.ConnectDB();
        //    objSqlTransaction = objSqlConnection.BeginTransaction();

        //    #endregion

        //    objSqlCommand.Connection = objSqlTransaction.Connection;
        //    objSqlCommand.Transaction = objSqlTransaction;
        //    objSqlCommand.CommandText = @"[dbo].[SP_MENU_LIST]";
        //    objSqlCommand.CommandType = CommandType.StoredProcedure;
        //    objSqlCommand.Parameters.Add("@ROLE_CODE", SqlDbType.VarChar).Value = "ADMIN";
        //    SqlDataAdapter objSqlAdapter = new SqlDataAdapter(objSqlCommand);
        //    objResultDto.ResultSet = new DataSet();
        //    objSqlAdapter.Fill(objResultDto.ResultSet);
        //    if (objResultDto.ResultSet.Tables.Count > 0)
        //    {

        //        var liSubUserMenu = objResultDto.ResultSet;
        //        List<SubMenuItems> LiUserMenu = new List<SubMenuItems>();
        //        LiUserMenu = ConvertDataTable<SubMenuItems>(objResultDto.ResultSet.Tables[0]);
        //        SubMenuItems objModel = new SubMenuItems();
        //        Session["MENU_ITEMS"] = LiUserMenu;

        //    }
        //    return View();
        //}

        // Convert datatable ------------------------------------
        public static List<T> ConvertDataTable<T>(System.Data.DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName].ToString(), null);
                    else
                        continue;
                }
            }
            return obj;
        }
        //---------------------------------------------------


    }
}
