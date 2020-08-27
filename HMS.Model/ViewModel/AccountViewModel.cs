using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Model.Model;
using System.Data.OracleClient;
using HMS.DAO;
using HMS.UTILITY;
using System.Data;
namespace HMS.Model.ViewModel
{
    public class AccountViewModel : IDisposable
    {
        public LoginViewModel objLoginViewModel { get; set; }
        public List<Notifications> liNotification { get; set; }
        public static List<User> FetchUserDetails(UserDetails objUserDetails)
        {
            DataValue dv = new DataValue();
            dv.Add("@USERNAME", objUserDetails.E_USER_ID, EnumCommand.DataType.Varchar);
            dv.Add("@PASSWORD", objUserDetails.E_PASSWORD, EnumCommand.DataType.Varchar);
            dv.Add("@ORGID", objUserDetails.E_COMPANY, EnumCommand.DataType.Int);
            //var liUserDetails = (List<User>)OracleHelper.FetchData<User>(Oraparam, Common.Queries.CMS_SP_INSERT_USER_MANAGER, EnumCommand.DataSource.list).DataSource.Data;
            //return liUserDetails;

            var liUserDetails = (List<User>)SQLHelper.FetchData<User>(Common.Queries.SP_LOGIN_USER, EnumCommand.DataSource.list, dv).DataSource.Data;
            return liUserDetails;

            
        }

        public static List<SubMenuItems> FetchUserSubMenu(UserDetails objUserDetails)
        {
            DataValue dv = new DataValue();
            dv.Add("@ROLE_CODE", objUserDetails.E_ROLE_CODE, EnumCommand.DataType.Varchar);
            dv.Add("@ORGID", objUserDetails.E_COMPANY, EnumCommand.DataType.Int);
            var liSubUserMenu = (List<SubMenuItems>)SQLHelper.FetchData<SubMenuItems>(Common.Queries.SP_MENU_LIST, EnumCommand.DataSource.list, dv).DataSource.Data;
            return liSubUserMenu;
        }
        public static List<MenuItems> FetchUserMenu(UserDetails objUserDetails)
        {
            OracleParameterCollection param = new OracleParameterCollection();
            param.Add(new OracleParameter("E_USERID", objUserDetails.E_USER_ID));
            param.Add(new OracleParameter("P_OUTTBL1", OracleType.Cursor));
            param["P_OUTTBL1"].Direction = ParameterDirection.Output;
            OracleParameter[] Oraparam = new OracleParameter[param.Count];
            param.CopyTo(Oraparam, 0);
            param.Clear();
            var liUserMenu = (List<MenuItems>)OracleHelper.FetchData<MenuItems>(Oraparam, Common.Queries.CMS_SP_FETCH_MENUS_USER_WISE, EnumCommand.DataSource.list).DataSource.Data;
            return liUserMenu;
        }
        public static List<Branch> FetchBranchCode(UserDetails objUserDetails)
        {
            OracleParameterCollection param = new OracleParameterCollection();
            param.Add(new OracleParameter(Common.POS_SP_FETCH_BRANCH.P_USERID, objUserDetails.E_USER_ID));
            param.Add(new OracleParameter(Common.POS_SP_FETCH_BRANCH.P_OUTTBL, OracleType.Cursor));
            param[Common.POS_SP_FETCH_BRANCH.P_OUTTBL].Direction = ParameterDirection.Output;
            OracleParameter[] Oraparam = new OracleParameter[param.Count];
            param.CopyTo(Oraparam, 0);
            param.Clear();
            var liBranch = (List<Branch>)OracleHelper.FetchData<Branch>(Oraparam, Common.Queries.POS_SP_FETCH_BRANCH, EnumCommand.DataSource.list).DataSource.Data;
            return liBranch;
        }
        public static List<User> UpdateLastLogin(User user)
        {
            OracleParameterCollection param = new OracleParameterCollection();
            param.Add(new OracleParameter(Common.POS_SP_FETCH_BRANCH.P_USERID, user.USER_ID));
            param.Add(new OracleParameter(Common.POS_SP_FETCH_BRANCH.P_OUTTBL, OracleType.Cursor));
            param[Common.POS_SP_FETCH_BRANCH.P_OUTTBL].Direction = ParameterDirection.Output;
            OracleParameter[] Oraparam = new OracleParameter[param.Count];
            param.CopyTo(Oraparam, 0);
            param.Clear();
            var liUser = (List<User>)OracleHelper.FetchData<User>(Oraparam, Common.Queries.POS_SP_UPDATE_LAST_LOGIN, EnumCommand.DataSource.list).DataSource.Data;
            return liUser;
        }
        public static List<User> FetchExternalUserDetails(UserDetails objUserDetails)
        {
            OracleParameterCollection param = new OracleParameterCollection();
            param.Add(new OracleParameter(Common.CMS_SP_INSERT_USER_MANAGER.E_USER_ID, objUserDetails.E_USER_ID));
            param.Add(new OracleParameter(Common.CMS_SP_INSERT_USER_MANAGER.P_OUTTBL, OracleType.Cursor));
            param[Common.CMS_SP_INSERT_USER_MANAGER.P_OUTTBL].Direction = ParameterDirection.Output;
            OracleParameter[] Oraparam = new OracleParameter[param.Count];
            param.CopyTo(Oraparam, 0);
            param.Clear();
            var liBranch = (List<User>)OracleHelper.FetchData<User>(Oraparam, Common.Queries.CMS_SP_CHECK_EXTERNAL_USER, EnumCommand.DataSource.list).DataSource.Data;
            return liBranch;
        }
        
        public static List<Notifications> GetOverAllNotifications(Notifications objnotifications)
        {
            OracleParameterCollection param = new OracleParameterCollection();
            param.Add(new OracleParameter("P_USERID", objnotifications.USER_ID));
            param.Add(new OracleParameter("P_ROLE_CODE", objnotifications.ROLE));
            param.Add(new OracleParameter("P_OUTTBL", OracleType.Cursor));
            param["P_OUTTBL"].Direction = ParameterDirection.Output;
            OracleParameter[] Oraparam = new OracleParameter[param.Count];
            param.CopyTo(Oraparam, 0);
            param.Clear();
            var liNotification = (List<Notifications>)OracleHelper.FetchData<Notifications>(Oraparam, Common.Queries.POS_SP_OVERALL_NOTIFICATION, EnumCommand.DataSource.list).DataSource.Data;
            return liNotification;
        }
        public static List<Notifications> GetAllNotifications(string LoginID, string sUserRole, string sLastLogin, string sIsNewUser)
        {
            OracleParameterCollection param = new OracleParameterCollection();
            param.Add(new OracleParameter("P_USERID", LoginID));
            param.Add(new OracleParameter("P_ROLE_CODE", sUserRole));
            param.Add(new OracleParameter("P_LAST_LOGIN", sLastLogin));
            param.Add(new OracleParameter("P_IS_NEW_USER", sIsNewUser));
            param.Add(new OracleParameter("P_OUTTBL", OracleType.Cursor));
            param["P_OUTTBL"].Direction = ParameterDirection.Output;
            OracleParameter[] Oraparam = new OracleParameter[param.Count];
            param.CopyTo(Oraparam, 0);
            param.Clear();
            var liNotification = (List<Notifications>)OracleHelper.FetchData<Notifications>(Oraparam, Common.Queries.POS_SP_ALL_NOTIFICATION, EnumCommand.DataSource.list).DataSource.Data;
            return liNotification;
        }
        public static List<Notifications> UpdateNotifications(string sUserId,string sRole,string sNotificationId, string sIsBulk)
        {
            OracleParameterCollection param = new OracleParameterCollection();
            param.Add(new OracleParameter("P_USER_ID", sUserId));
            param.Add(new OracleParameter("P_ROLE_CODE", sRole));
            param.Add(new OracleParameter("P_NOTIFICATION_ID", sNotificationId));
            param.Add(new OracleParameter("P_IS_BULK", sIsBulk));
            param.Add(new OracleParameter("P_OUTTBL", OracleType.Cursor));
            param["P_OUTTBL"].Direction = ParameterDirection.Output;
            OracleParameter[] Oraparam = new OracleParameter[param.Count];
            param.CopyTo(Oraparam, 0);
            param.Clear();
            var liNotification = (List<Notifications>)OracleHelper.FetchData<Notifications>(Oraparam, Common.Queries.POS_SP_UPDATE_NOTIFICATION, EnumCommand.DataSource.list).DataSource.Data;
            return liNotification;
        }
        #region IDisposeMethod
        public void Dispose()
        {
            GC.Collect();
        }
        #endregion
    }
}
