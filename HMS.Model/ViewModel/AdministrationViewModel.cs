using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Model.Model;
using System.Data.OracleClient;
using System.Data;
using HMS.DAO;
using HMS.UTILITY;
using System.Web;

namespace HMS.Model.ViewModel
{
    public class AdministrationViewModel
    {
        #region Properties
        public List<CompanyMaster> liCompanyMaster { get; set; }
        public List<ActionMaster> liActionMaster { get; set; }
        public List<ResultMaster> liResultMaster { get; set; }
        public List<AreaMaster> liAreaMaster { get; set; }
        public List<RoleMaster> liRoleMaster { get; set; }
        public List<ModuleMaster> liModuleMaster { get; set; }
        public List<BankMaster> liBankMaster { get; set; }
        public List<BankMaster> liChargeType { get; set; }
        public List<BankMaster> liChargePattern { get; set; }
        public List<ProductMaster> liProductMaster { get; set; }
        public List<BillingMaster> liBillingMaster { get; set; }
        public List<ZonalMaster> liZonalMaster { get; set; }
        public List<UserMaster> liUserMaster { get; set; }
        public List<UserMaster> liTVSCSAreaCode { get; set; }
        public List<UserMaster> liRoleList { get; set; }
        public List<RegionMaster> liRegionMaster { get; set; }
        public List<YardMaster> liYardMaster { get; set; }
        public List<EmployeeMaster> liEmpMaster { get; set; }


       // public SelectList siSelectedList { get; set; }
        #endregion
        #region CompanyMaster Methods
        public static List<CompanyMaster> FetchCompanyMaster()
        {
            OracleParameterCollection param = new OracleParameterCollection();
            param.Add(new OracleParameter(Common.CMS_SP_INSERT_USER_MANAGER.P_OUTTBL, OracleType.Cursor));
            param[Common.CMS_SP_INSERT_USER_MANAGER.P_OUTTBL].Direction = ParameterDirection.Output;
            OracleParameter[] Oraparam = new OracleParameter[param.Count];
            param.CopyTo(Oraparam, 0);
            param.Clear();
            var liCompanyMaster = (List<CompanyMaster>)OracleHelper.FetchData<CompanyMaster>(Oraparam, Common.Queries.CMS_SP_GET_COMPANTY_MST, EnumCommand.DataSource.list).DataSource.Data;
            return liCompanyMaster;
        }
        public static List<CompanyMaster> SaveCompanyMaster(CompanyMaster companymaster)
        {
            OracleParameterCollection param = new OracleParameterCollection();
            param.Add(new OracleParameter(Common.CMS_SP_INSERT_COMPANY_MST.E_KEY, companymaster.KEY));
            param.Add(new OracleParameter(Common.CMS_SP_INSERT_COMPANY_MST.E_COMPANY_CODE, companymaster.COMPANY_CODE));
            param.Add(new OracleParameter(Common.CMS_SP_INSERT_COMPANY_MST.E_COMPANY_DESC, companymaster.COMPANY_NAME));
            param.Add(new OracleParameter(Common.CMS_SP_INSERT_COMPANY_MST.E_CREATED_BY, companymaster.CREATED_BY));
            param.Add(new OracleParameter(Common.CMS_SP_INSERT_COMPANY_MST.E_COMPANY_UPDATE_BY, companymaster.UPDATED_BY));
            param.Add(new OracleParameter(Common.CMS_SP_INSERT_COMPANY_MST.E_ACTIVE, companymaster.COMP_ACTIVE));
            param.Add(new OracleParameter(Common.CMS_SP_INSERT_COMPANY_MST.P_OUTTBL, OracleType.Cursor));
            param[Common.CMS_SP_INSERT_COMPANY_MST.P_OUTTBL].Direction = ParameterDirection.Output;
            OracleParameter[] Oraparam = new OracleParameter[param.Count];
            param.CopyTo(Oraparam, 0);
            param.Clear();
            var liCompanyMaster = (List<CompanyMaster>)OracleHelper.FetchData<CompanyMaster>(Oraparam, Common.Queries.CMS_SP_INSERT_COMPANY_MST, EnumCommand.DataSource.list).DataSource.Data;
            return liCompanyMaster;
        }
        #endregion
        #region Action Master
        public static List<ActionMaster> FetchActionMaster()
        {
            OracleParameterCollection param = new OracleParameterCollection();
            param.Add(new OracleParameter(Common.CMS_SP_INSERT_USER_MANAGER.P_OUTTBL, OracleType.Cursor));
            param[Common.CMS_SP_INSERT_USER_MANAGER.P_OUTTBL].Direction = ParameterDirection.Output;
            OracleParameter[] Oraparam = new OracleParameter[param.Count];
            param.CopyTo(Oraparam, 0);
            param.Clear();
            var liActionMaster = (List<ActionMaster>)OracleHelper.FetchData<ActionMaster>(Oraparam, Common.Queries.CMS_SP_GET_ACTION_MST, EnumCommand.DataSource.list).DataSource.Data;
            return liActionMaster;
        }
        public static List<ActionMaster> SaveActionMaster(ActionMaster actionmaster)
        {
            OracleParameterCollection param = new OracleParameterCollection();
            param.Add(new OracleParameter(Common.CMS_SP_INSERT_ACTION_MST.E_KEY, actionmaster.KEY));
            param.Add(new OracleParameter(Common.CMS_SP_INSERT_ACTION_MST.E_ACTION_CODE, actionmaster.ACTION_CODE));
            param.Add(new OracleParameter(Common.CMS_SP_INSERT_ACTION_MST.E_ACTION_DESC, actionmaster.ACTION_DESC));
            param.Add(new OracleParameter(Common.CMS_SP_INSERT_ACTION_MST.E_ACTIVE, actionmaster.USER_ACTIVE));
            param.Add(new OracleParameter(Common.CMS_SP_INSERT_ACTION_MST.P_OUTTBL, OracleType.Cursor));
            param[Common.CMS_SP_INSERT_ACTION_MST.P_OUTTBL].Direction = ParameterDirection.Output;
            OracleParameter[] Oraparam = new OracleParameter[param.Count];
            param.CopyTo(Oraparam, 0);
            param.Clear();
            var liActionMaster = (List<ActionMaster>)OracleHelper.FetchData<ActionMaster>(Oraparam, Common.Queries.CMS_SP_INSERT_ACTION_MST, EnumCommand.DataSource.list).DataSource.Data;
            return liActionMaster;
        }
        #endregion
        #region Result Master
        public static List<ResultMaster> FetchResultMaster()
        {
            OracleParameterCollection param = new OracleParameterCollection();
            param.Add(new OracleParameter(Common.CMS_SP_INSERT_RESULT_MST.E_KEY, ""));
            param.Add(new OracleParameter(Common.CMS_SP_INSERT_RESULT_MST.P_OUTTBL, OracleType.Cursor));
            param[Common.CMS_SP_INSERT_RESULT_MST.P_OUTTBL].Direction = ParameterDirection.Output;
            OracleParameter[] Oraparam = new OracleParameter[param.Count];
            param.CopyTo(Oraparam, 0);
            param.Clear();
            var liResultMaster = (List<ResultMaster>)OracleHelper.FetchData<ResultMaster>(Oraparam, Common.Queries.CMS_SP_GET_RESULT_MST, EnumCommand.DataSource.list).DataSource.Data;
            return liResultMaster;
        }
        public static List<ActionMaster> FetchActionCodeAndDesc()
        {
            OracleParameterCollection param = new OracleParameterCollection();
            param.Add(new OracleParameter(Common.CMS_SP_INSERT_ACTION_MST.E_KEY, Common.ActiveLog.Inverse));
            param.Add(new OracleParameter(Common.CMS_SP_INSERT_ACTION_MST.P_OUTTBL, OracleType.Cursor));
            param[Common.CMS_SP_INSERT_USER_MANAGER.P_OUTTBL].Direction = ParameterDirection.Output;
            OracleParameter[] Oraparam = new OracleParameter[param.Count];
            param.CopyTo(Oraparam, 0);
            param.Clear();
            var liActionMaster = (List<ActionMaster>)OracleHelper.FetchData<ActionMaster>(Oraparam, Common.Queries.CMS_SP_GET_ACTION_LIST, EnumCommand.DataSource.list).DataSource.Data;
            return liActionMaster;
        }
        public static List<ResultMaster> SaveResultMaster(ResultMaster resultmaster)
        {
            OracleParameterCollection param = new OracleParameterCollection();
            param.Add(new OracleParameter(Common.CMS_SP_INSERT_RESULT_MST.E_KEY, resultmaster.KEY));
            param.Add(new OracleParameter(Common.CMS_SP_INSERT_RESULT_MST.E_ACTION_ID, resultmaster.ACTION_ID));
            param.Add(new OracleParameter(Common.CMS_SP_INSERT_RESULT_MST.E_RESULT_CODE, resultmaster.RESULT_CODE));
            param.Add(new OracleParameter(Common.CMS_SP_INSERT_RESULT_MST.E_RESULT_DESC, resultmaster.RESULT_DESC));
            param.Add(new OracleParameter(Common.CMS_SP_INSERT_RESULT_MST.E_ACTIVE, resultmaster.USER_ACTIVE));
            param.Add(new OracleParameter(Common.CMS_SP_INSERT_RESULT_MST.P_OUTTBL, OracleType.Cursor));
            param[Common.CMS_SP_INSERT_RESULT_MST.P_OUTTBL].Direction = ParameterDirection.Output;
            OracleParameter[] Oraparam = new OracleParameter[param.Count];
            param.CopyTo(Oraparam, 0);
            param.Clear();
            var liResultMaster = (List<ResultMaster>)OracleHelper.FetchData<ResultMaster>(Oraparam, Common.Queries.CMS_SP_INSERT_RESULT_MST, EnumCommand.DataSource.list).DataSource.Data;
            return liResultMaster;
        }
        #endregion
        #region Area Master
        public static List<AreaMaster> FetchAreaMaster()
        {
            OracleParameterCollection param = new OracleParameterCollection();
            param.Add(new OracleParameter(Common.POS_SP_GET_AREAREGION_DTLS.P_AREA_CODE, ""));
            param.Add(new OracleParameter(Common.POS_SP_GET_AREAREGION_DTLS.P_REGION_CODE, ""));
            param.Add(new OracleParameter(Common.POS_SP_GET_AREAREGION_DTLS.P_AREA_NAME, ""));
            param.Add(new OracleParameter(Common.POS_SP_GET_AREAREGION_DTLS.P_OUTTBL, OracleType.Cursor));
            param[Common.POS_SP_GET_AREAREGION_DTLS.P_OUTTBL].Direction = ParameterDirection.Output;
            OracleParameter[] Oraparam = new OracleParameter[param.Count];
            param.CopyTo(Oraparam, 0);
            param.Clear();
            var liAreaMaster = (List<AreaMaster>)OracleHelper.FetchData<AreaMaster>(Oraparam, Common.Queries.POS_SP_GET_AREAREGION_DTLS, EnumCommand.DataSource.list).DataSource.Data;
            return liAreaMaster;
        }
        #endregion
        #region Role Master
        public static List<RoleMaster> FetchRoleMaster(RoleMaster rolemaster)
        {
            OracleParameterCollection param = new OracleParameterCollection();
            param.Add(new OracleParameter(Common.POS_SP_FETCH_ROLE_LIST.E_ROLE_ID, rolemaster.ROLE_ID));
            param.Add(new OracleParameter(Common.POS_SP_FETCH_ROLE_LIST.P_OUTTBL, OracleType.Cursor));
            param[Common.POS_SP_FETCH_ROLE_LIST.P_OUTTBL].Direction = ParameterDirection.Output;
            OracleParameter[] Oraparam = new OracleParameter[param.Count];
            param.CopyTo(Oraparam, 0);
            param.Clear();
            var liRoleMaster = (List<RoleMaster>)OracleHelper.FetchData<RoleMaster>(Oraparam, Common.Queries.POS_SP_FETCH_ROLE_LIST, EnumCommand.DataSource.list).DataSource.Data;
            return liRoleMaster;
        }
        public static List<RoleMaster> FetchRoleMasterByRole(RoleMaster rolemaster)
        {
            OracleParameterCollection param = new OracleParameterCollection();
            param.Add(new OracleParameter(Common.POS_SP_FETCH_ROLE_LIST.E_ROLE_ID, rolemaster.ROLE_ID));
            param.Add(new OracleParameter(Common.POS_SP_FETCH_ROLE_LIST.P_OUTTBL, OracleType.Cursor));
            param[Common.POS_SP_FETCH_ROLE_LIST.P_OUTTBL].Direction = ParameterDirection.Output;
            OracleParameter[] Oraparam = new OracleParameter[param.Count];
            param.CopyTo(Oraparam, 0);
            param.Clear();
            var liRoleMaster = (List<RoleMaster>)OracleHelper.FetchData<RoleMaster>(Oraparam, Common.Queries.POS_SP_FETCH_MENU_BY_ROLE_ID, EnumCommand.DataSource.list).DataSource.Data;
            return liRoleMaster;
        }
        public static List<RoleMaster> SaveRoleMaster(string XMLString)
        {
            OracleParameterCollection param = new OracleParameterCollection();
            param.Add(new OracleParameter(Common.CMS_SP_INSERT_RESULT_MST.E_KEY, XMLString));
            param.Add(new OracleParameter(Common.CMS_SP_INSERT_RESULT_MST.P_OUTTBL, OracleType.Cursor));
            param[Common.CMS_SP_INSERT_RESULT_MST.P_OUTTBL].Direction = ParameterDirection.Output;
            OracleParameter[] Oraparam = new OracleParameter[param.Count];
            param.CopyTo(Oraparam, 0);
            param.Clear();
            var liRoleMaster = (List<RoleMaster>)OracleHelper.FetchData<RoleMaster>(Oraparam, Common.Queries.CMS_SP_INSERT_RESULT_MST, EnumCommand.DataSource.list).DataSource.Data;
            return liRoleMaster;
        }
        #endregion
        #region Billing Master
        public static List<BankMaster> FetchBankMasterByZoneKey(BankMaster bankmaster)
        {
            OracleParameterCollection param = new OracleParameterCollection();
            param.Add(new OracleParameter(Common.CMS_SP_INSERT_RESULT_MST.E_KEY, bankmaster.KEY));
            param.Add(new OracleParameter(Common.CMS_SP_INSERT_RESULT_MST.P_OUTTBL, OracleType.Cursor));
            param[Common.CMS_SP_INSERT_RESULT_MST.P_OUTTBL].Direction = ParameterDirection.Output;
            OracleParameter[] Oraparam = new OracleParameter[param.Count];
            param.CopyTo(Oraparam, 0);
            param.Clear();
            var liBankMaster = (List<BankMaster>)OracleHelper.FetchData<BankMaster>(Oraparam, Common.Queries.CMS_SP_GET_BANKZONREG_MST, EnumCommand.DataSource.list).DataSource.Data;
            return liBankMaster;
        }
        public static List<BankMaster> FetchGCMDetails(BankMaster bankmaster)
        {
            OracleParameterCollection param = new OracleParameterCollection();
            param.Add(new OracleParameter(Common.POS_SP_GET_GCM_DET.P_IN_CODE, bankmaster.KEY));
            param.Add(new OracleParameter(Common.POS_SP_GET_GCM_DET.P_OUTTBL, OracleType.Cursor));
            param[Common.POS_SP_GET_GCM_DET.P_OUTTBL].Direction = ParameterDirection.Output;
            OracleParameter[] Oraparam = new OracleParameter[param.Count];
            param.CopyTo(Oraparam, 0);
            param.Clear();
            var liBankMaster = (List<BankMaster>)OracleHelper.FetchData<BankMaster>(Oraparam, Common.Queries.POS_SP_GET_GCM_DET, EnumCommand.DataSource.list).DataSource.Data;
            return liBankMaster;
        }
        public static List<BillingMaster> FetchBillingMasterHRD(BillingMaster billingmaster)
        {
            OracleParameterCollection param = new OracleParameterCollection();
            param.Add(new OracleParameter(Common.POS_SP_GET_BILLING_MASTER.P_KEY_CODE, billingmaster.KEY));
            param.Add(new OracleParameter(Common.POS_SP_GET_BILLING_MASTER.P_BANK_ID, billingmaster.BANK_ID));
            param.Add(new OracleParameter(Common.POS_SP_GET_BILLING_MASTER.P_CHRG_TYPE, billingmaster.CHARGE_TYPE));
            param.Add(new OracleParameter(Common.POS_SP_GET_BILLING_MASTER.P_PRODUCT, billingmaster.PRODUCT_ID));
            param.Add(new OracleParameter(Common.POS_SP_GET_BILLING_MASTER.P_OUT_TBL, OracleType.Cursor));
            param[Common.POS_SP_GET_BILLING_MASTER.P_OUT_TBL].Direction = ParameterDirection.Output;
            OracleParameter[] Oraparam = new OracleParameter[param.Count];
            param.CopyTo(Oraparam, 0);
            param.Clear();
            var liBillingMaster = (List<BillingMaster>)OracleHelper.FetchData<BillingMaster>(Oraparam, Common.Queries.POS_SP_GET_BILLING_MASTER, EnumCommand.DataSource.list).DataSource.Data;
            return liBillingMaster;
        }
        #endregion
        #region Product Master
        public static List<ProductMaster> GetProductList()
        {
            OracleParameterCollection param = new OracleParameterCollection();
            param.Add(new OracleParameter(Common.CMS_SP_INSERT_PRODUCT_MST.P_OUTTBL, OracleType.Cursor));
            param[Common.CMS_SP_INSERT_PRODUCT_MST.P_OUTTBL].Direction = ParameterDirection.Output;
            OracleParameter[] Oraparam = new OracleParameter[param.Count];
            param.CopyTo(Oraparam, 0);
            param.Clear();
            var liProductMaster = (List<ProductMaster>)OracleHelper.FetchData<ProductMaster>(Oraparam, Common.Queries.CMS_SP_GET_PRODUCT_MST, EnumCommand.DataSource.list).DataSource.Data;
            return liProductMaster;
        }
        public static List<ProductMaster> SaveProductMaster(ProductMaster ProductMaster, string UserID)
        {
            OracleParameterCollection param = new OracleParameterCollection();
            param.Add(new OracleParameter(Common.CMS_SP_INSERT_PRODUCT_MST.E_KEY, ProductMaster.KEY));
            param.Add(new OracleParameter(Common.CMS_SP_INSERT_PRODUCT_MST.E_PRODUCT_CODE, ProductMaster.PRODUCT_CODE));
            param.Add(new OracleParameter(Common.CMS_SP_INSERT_PRODUCT_MST.E_PRODUCT_DESC, ProductMaster.PRODUCT_DESC));
            param.Add(new OracleParameter(Common.CMS_SP_INSERT_PRODUCT_MST.E_CREATED_BY, UserID));
            param.Add(new OracleParameter(Common.CMS_SP_INSERT_PRODUCT_MST.E_UPDATED_BY, UserID));
            param.Add(new OracleParameter(Common.CMS_SP_INSERT_PRODUCT_MST.E_ACTIVE, ProductMaster.PRODUCT_ACTIVE));
            param.Add(new OracleParameter(Common.CMS_SP_INSERT_PRODUCT_MST.P_OUTTBL, OracleType.Cursor));
            param[Common.CMS_SP_INSERT_COMPANY_MST.P_OUTTBL].Direction = ParameterDirection.Output;
            OracleParameter[] Oraparam = new OracleParameter[param.Count];
            param.CopyTo(Oraparam, 0);
            param.Clear();
            var liProductMaster = (List<ProductMaster>)OracleHelper.FetchData<ProductMaster>(Oraparam, Common.Queries.CMS_SP_INSERT_PRODUCT_MST, EnumCommand.DataSource.list).DataSource.Data;
            return liProductMaster;
        }
        #endregion
        #region Zonal Master
        public static List<ZonalMaster> GetZonalList()
        {
            OracleParameterCollection param = new OracleParameterCollection();
            param.Add(new OracleParameter(Common.CMS_SP_REGZONCOLLECTION_MST.E_KEY, Common.Keys.GZonalMaster));
            param.Add(new OracleParameter(Common.CMS_SP_REGZONCOLLECTION_MST.P_OUTTBL, OracleType.Cursor));
            param[Common.CMS_SP_REGZONCOLLECTION_MST.P_OUTTBL].Direction = ParameterDirection.Output;
            OracleParameter[] Oraparam = new OracleParameter[param.Count];
            param.CopyTo(Oraparam, 0);
            param.Clear();
            var liZonalMaster = (List<ZonalMaster>)OracleHelper.FetchData<ZonalMaster>(Oraparam, Common.Queries.CMS_SP_REGZONCOLLECTION_LIST, EnumCommand.DataSource.list).DataSource.Data;
            return liZonalMaster;
        }

        public static List<ZonalMaster> SaveZonalMaster(ZonalMaster ZonalMaster, string UserID)
        {
            OracleParameterCollection param = new OracleParameterCollection();
            param.Add(new OracleParameter(Common.CMS_SP_REGZONCOLLECTION_MST.E_KEY, ZonalMaster.KEY));
            param.Add(new OracleParameter(Common.CMS_SP_REGZONCOLLECTION_MST.E_CODE, ZonalMaster.ZONE_CODE));
            param.Add(new OracleParameter(Common.CMS_SP_REGZONCOLLECTION_MST.E_CODE_DESC, ZonalMaster.ZONE_DESC));
            param.Add(new OracleParameter(Common.CMS_SP_REGZONCOLLECTION_MST.E_ACTIVE, ZonalMaster.USER_ACTIVE));
            param.Add(new OracleParameter(Common.CMS_SP_REGZONCOLLECTION_MST.E_ZONE_CODE, null));
            param.Add(new OracleParameter(Common.CMS_SP_REGZONCOLLECTION_MST.E_CREATED_BY, UserID));
            param.Add(new OracleParameter(Common.CMS_SP_REGZONCOLLECTION_MST.P_OUTTBL, OracleType.Cursor));
            param[Common.CMS_SP_REGZONCOLLECTION_MST.P_OUTTBL].Direction = ParameterDirection.Output;
            OracleParameter[] Oraparam = new OracleParameter[param.Count];
            param.CopyTo(Oraparam, 0);
            param.Clear();
            var liZonalMaster = (List<ZonalMaster>)OracleHelper.FetchData<ZonalMaster>(Oraparam, Common.Queries.CMS_SP_REGZONCOLLECTION_MST, EnumCommand.DataSource.list).DataSource.Data;
            return liZonalMaster;
        }
        #endregion
        #region User Master
        public static List<UserMaster> GetUserList()
        {
            OracleParameterCollection param = new OracleParameterCollection();
            param.Add(new OracleParameter(Common.CMS_SP_INSERT_USER_MANAGER.P_OUTTBL, OracleType.Cursor));
            param[Common.CMS_SP_INSERT_USER_MANAGER.P_OUTTBL].Direction = ParameterDirection.Output;
            OracleParameter[] Oraparam = new OracleParameter[param.Count];
            param.CopyTo(Oraparam, 0);
            param.Clear();
            var liUserMaster = (List<UserMaster>)OracleHelper.FetchData<UserMaster>(Oraparam, Common.Queries.CMS_SP_GET_USER_MAPPING_MST, EnumCommand.DataSource.list).DataSource.Data;
            return liUserMaster;
        }

        public static List<UserMaster> GetTVSCSAreaList()
        {
            OracleParameterCollection param = new OracleParameterCollection();
            param.Add(new OracleParameter(Common.CMS_SP_INSERT_USER_MANAGER.P_OUTTBL, OracleType.Cursor));
            param[Common.CMS_SP_INSERT_USER_MANAGER.P_OUTTBL].Direction = ParameterDirection.Output;
            OracleParameter[] Oraparam = new OracleParameter[param.Count];
            param.CopyTo(Oraparam, 0);
            param.Clear();
            var liTVSCSAreaCode = (List<UserMaster>)OracleHelper.FetchData<UserMaster>(Oraparam, Common.Queries.CMS_SP_GET_AREACODE_MST, EnumCommand.DataSource.list).DataSource.Data;
            return liTVSCSAreaCode;
        }

        public static List<UserMaster> GetRoleList()
        {
            OracleParameterCollection param = new OracleParameterCollection();
            param.Add(new OracleParameter(Common.CMS_SP_INSERT_USER_MANAGER.E_KEY, Common.Keys.RoleKey));
            param.Add(new OracleParameter(Common.CMS_SP_INSERT_USER_MANAGER.P_OUTTBL, OracleType.Cursor));
            param[Common.CMS_SP_INSERT_USER_MANAGER.P_OUTTBL].Direction = ParameterDirection.Output;
            OracleParameter[] Oraparam = new OracleParameter[param.Count];
            param.CopyTo(Oraparam, 0);
            param.Clear();
            var liRoleList = (List<UserMaster>)OracleHelper.FetchData<UserMaster>(Oraparam, Common.Queries.CMS_SP_GET_ROLE_LIST, EnumCommand.DataSource.list).DataSource.Data;
            return liRoleList;
        }

        public static List<UserMaster> SaveUserMaster(UserMaster UserMaster, string UserID)
        {
            OracleParameterCollection param = new OracleParameterCollection();
            param.Add(new OracleParameter(Common.CMS_SP_INSERT_USER_MANAGER.E_KEY, UserMaster.KEY));
            param.Add(new OracleParameter(Common.CMS_SP_INSERT_USER_MANAGER.E_USER_ID, UserMaster.USER_ID));
            param.Add(new OracleParameter(Common.CMS_SP_INSERT_USER_MANAGER.E_USER_NAME, UserMaster.USER_NAME));
            param.Add(new OracleParameter(Common.CMS_SP_INSERT_USER_MANAGER.E_USER_TYPE, UserMaster.USER_TYPE));
            param.Add(new OracleParameter(Common.CMS_SP_INSERT_USER_MANAGER.E_EMAIL, UserMaster.EMAIL));
            param.Add(new OracleParameter(Common.CMS_SP_INSERT_USER_MANAGER.E_MOBILE, UserMaster.MOBILE));
            param.Add(new OracleParameter(Common.CMS_SP_INSERT_USER_MANAGER.E_DESIGNATION, UserMaster.DESIGNATION));
            param.Add(new OracleParameter(Common.CMS_SP_INSERT_USER_MANAGER.E_ROLE_CODE, UserMaster.ROLE_CODE));
            param.Add(new OracleParameter(Common.CMS_SP_INSERT_USER_MANAGER.E_USER_ACTIVE, UserMaster.USER_ACTIVE));
            param.Add(new OracleParameter(Common.CMS_SP_INSERT_USER_MANAGER.E_CREATED_BY, UserID));
            param.Add(new OracleParameter(Common.CMS_SP_INSERT_USER_MANAGER.E_AREA_CODE, UserMaster.TVSCS_AREACODE));
            param.Add(new OracleParameter(Common.CMS_SP_INSERT_USER_MANAGER.P_OUTTBL, OracleType.Cursor));
            param[Common.CMS_SP_INSERT_USER_MANAGER.P_OUTTBL].Direction = ParameterDirection.Output;
            OracleParameter[] Oraparam = new OracleParameter[param.Count];
            param.CopyTo(Oraparam, 0);
            param.Clear();
            var liZonalMaster = (List<UserMaster>)OracleHelper.FetchData<UserMaster>(Oraparam, Common.Queries.CMS_SP_INSERT_USER_MANAGER, EnumCommand.DataSource.list).DataSource.Data;
            return liZonalMaster;
        }

        #endregion
        #region BankMaster Methods

        public static List<BankMaster> FetchBankMaster(BankMaster objModel)
        {
            try
            {
                OracleParameterCollection param = new OracleParameterCollection();
                param.Add(new OracleParameter(Common.POS_SP_INS_BANK_MASTER.P_KEY, objModel.KEY));
                param.Add(new OracleParameter(Common.POS_SP_INS_BANK_MASTER.P_BANK_NAME, objModel.BANK_NAME));
                param.Add(new OracleParameter(Common.POS_SP_INS_BANK_MASTER.P_BANK_CODE, objModel.BANK_CODE));
                param.Add(new OracleParameter(Common.POS_SP_INS_BANK_MASTER.P_BANK_TYPE, objModel.BANK_TYPE));
                param.Add(new OracleParameter(Common.POS_SP_INS_BANK_MASTER.P_ACTIVE, objModel.BANK_ACTIVE));
                param.Add(new OracleParameter(Common.POS_SP_INS_BANK_MASTER.P_OUT, OracleType.Cursor));
                param[Common.POS_SP_INS_BANK_MASTER.P_OUT].Direction = ParameterDirection.Output;
                OracleParameter[] Oraparam = new OracleParameter[param.Count];
                param.CopyTo(Oraparam, 0);
                param.Clear();
                var liBankMaster = (List<BankMaster>)OracleHelper.FetchData<BankMaster>(Oraparam, Common.Queries.POS_SP_INS_BANK_MASTER, EnumCommand.DataSource.list).DataSource.Data;
                return liBankMaster;
            }
            catch (Exception ex)
            {
                List<BankMaster> liii = new List<BankMaster>();
                return liii;
            }
        }
        public static List<BankMaster> FetchBankMasterBankType(BankMaster objBankdet)
        {
            OracleParameterCollection param = new OracleParameterCollection();
            param.Add(new OracleParameter(Common.POS_SP_GET_GCM_DET.P_IN_CODE, objBankdet.KEY));
            param.Add(new OracleParameter(Common.POS_SP_GET_GCM_DET.P_OUTTBL, OracleType.Cursor));
            param[Common.POS_SP_GET_GCM_DET.P_OUTTBL].Direction = ParameterDirection.Output;
            OracleParameter[] Oraparam = new OracleParameter[param.Count];
            param.CopyTo(Oraparam, 0);
            param.Clear();
            var dafdafs = (List<BankMaster>)OracleHelper.FetchData<BankMaster>(Oraparam, Common.Queries.POS_SP_GET_GCM_DET, EnumCommand.DataSource.list).DataSource.Data;
            return dafdafs;
        }
        public static List<BankMaster> SaveBankMaster(BankMaster bankmaster)
        {
            OracleParameterCollection param = new OracleParameterCollection();
            param.Add(new OracleParameter(Common.POS_SP_INS_BANK_MASTER.P_KEY, bankmaster.KEY));
            param.Add(new OracleParameter(Common.POS_SP_INS_BANK_MASTER.P_BANK_NAME, bankmaster.BANK_DESC));
            param.Add(new OracleParameter(Common.POS_SP_INS_BANK_MASTER.P_BANK_CODE, bankmaster.BANK_CODE));
            param.Add(new OracleParameter(Common.POS_SP_INS_BANK_MASTER.P_BANK_TYPE, bankmaster.BANK_TYPE));
            param.Add(new OracleParameter(Common.POS_SP_INS_BANK_MASTER.P_ACTIVE, bankmaster.BANK_ACTIVE));
            param.Add(new OracleParameter(Common.POS_SP_INS_BANK_MASTER.P_OUT, OracleType.Cursor));
            param[Common.POS_SP_INS_BANK_MASTER.P_OUT].Direction = ParameterDirection.Output;
            OracleParameter[] Oraparam = new OracleParameter[param.Count];
            param.CopyTo(Oraparam, 0);
            param.Clear();
            var liBankMaster = (List<BankMaster>)OracleHelper.FetchData<BankMaster>(Oraparam, Common.Queries.POS_SP_INS_BANK_MASTER, EnumCommand.DataSource.list).DataSource.Data;
            return liBankMaster;
        }

        #endregion
        #region Region Master
        public static List<RegionMaster> FetchRegionMaster(RegionMaster objModel)
        {
            OracleParameterCollection param = new OracleParameterCollection();
            param.Add(new OracleParameter(Common.CMS_SP_REGZONCOLLECTION_LIST.E_KEY, objModel.KEY));
            param.Add(new OracleParameter(Common.CMS_SP_REGZONCOLLECTION_LIST.P_OUTTBL, OracleType.Cursor));
            param[Common.CMS_SP_REGZONCOLLECTION_LIST.P_OUTTBL].Direction = ParameterDirection.Output;
            OracleParameter[] Oraparam = new OracleParameter[param.Count];
            param.CopyTo(Oraparam, 0);
            param.Clear();
            var liRegionMaster = (List<RegionMaster>)OracleHelper.FetchData<RegionMaster>(Oraparam, Common.Queries.CMS_SP_REGZONCOLLECTION_LIST, EnumCommand.DataSource.list).DataSource.Data;
            return liRegionMaster;
        }
        public static List<RegionMaster> SaveRegionMaster(RegionMaster regionmaster)
        {
            OracleParameterCollection param1 = new OracleParameterCollection();
            param1.Add(new OracleParameter(Common.CMS_SP_REGZONCOLLECTION_MST.E_KEY, regionmaster.KEY));
            param1.Add(new OracleParameter(Common.CMS_SP_REGZONCOLLECTION_MST.E_CODE, regionmaster.REGION_CODE));
            param1.Add(new OracleParameter(Common.CMS_SP_REGZONCOLLECTION_MST.E_CODE_DESC, regionmaster.REGION_DESC));
            param1.Add(new OracleParameter(Common.CMS_SP_REGZONCOLLECTION_MST.E_ACTIVE, regionmaster.ACTIVE));
            param1.Add(new OracleParameter(Common.CMS_SP_REGZONCOLLECTION_MST.E_ZONE_CODE, regionmaster.ZONE_CODE));
            param1.Add(new OracleParameter(Common.CMS_SP_REGZONCOLLECTION_MST.E_CREATED_BY, regionmaster.CREATED_BY));
            param1.Add(new OracleParameter(Common.CMS_SP_REGZONCOLLECTION_MST.P_OUTTBL, OracleType.Cursor));
            param1[Common.CMS_SP_REGZONCOLLECTION_MST.P_OUTTBL].Direction = ParameterDirection.Output;
            OracleParameter[] Oraparam1 = new OracleParameter[param1.Count];
            param1.CopyTo(Oraparam1, 0);
            param1.Clear();
            var liRegionMaster1 = (List<RegionMaster>)OracleHelper.FetchData<RegionMaster>(Oraparam1, Common.Queries.CMS_SP_REGZONCOLLECTION_MST, EnumCommand.DataSource.list).DataSource.Data;
            return liRegionMaster1;
        }
        #endregion
        #region Yard Master
        public static List<YardMaster> FetchYardMaster(YardMaster objModel)
        {
            OracleParameterCollection param = new OracleParameterCollection();
            param.Add(new OracleParameter(Common.POS_SP_GET_YARD_CODE.P_OUTTBL, OracleType.Cursor));
            param[Common.POS_SP_GET_YARD_CODE.P_OUTTBL].Direction = ParameterDirection.Output;
            OracleParameter[] Oraparam = new OracleParameter[param.Count];
            param.CopyTo(Oraparam, 0);
            param.Clear();
            var liYardMaster = (List<YardMaster>)OracleHelper.FetchData<YardMaster>(Oraparam, Common.Queries.POS_SP_GET_YARD_CODE, EnumCommand.DataSource.list).DataSource.Data;
            return liYardMaster;
        }
        #endregion
        #region Bank Branch Master
        public static List<BankMaster> FetchBankBranchMasterBank(BankMaster objBankdet)
        {
            OracleParameterCollection param = new OracleParameterCollection();
            param.Add(new OracleParameter(Common.CMS_SP_GET_BANKZONEREG_MST.E_KEY, objBankdet.DROPDOWNKEY));
            param.Add(new OracleParameter(Common.CMS_SP_GET_BANKZONEREG_MST.P_OUTTBL, OracleType.Cursor));
            param[Common.CMS_SP_GET_BANKZONEREG_MST.P_OUTTBL].Direction = ParameterDirection.Output;
            OracleParameter[] Oraparam = new OracleParameter[param.Count];
            param.CopyTo(Oraparam, 0);
            param.Clear();
            var dafdafs = (List<BankMaster>)OracleHelper.FetchData<BankMaster>(Oraparam, Common.Queries.CMS_SP_GET_BANKZONEREG_MST, EnumCommand.DataSource.list).DataSource.Data;
            return dafdafs;
        }
        public static List<BankMaster> FetchBankBranchMasterRegionZoneStateBankType(BankMaster objBankdet)
        {
            OracleParameterCollection param = new OracleParameterCollection();
            param.Add(new OracleParameter(Common.CMS_SP_REGZONCOLLECTION_LIST.E_KEY, objBankdet.DROPDOWNKEY));
            param.Add(new OracleParameter(Common.CMS_SP_REGZONCOLLECTION_LIST.P_OUTTBL, OracleType.Cursor));
            param[Common.CMS_SP_REGZONCOLLECTION_LIST.P_OUTTBL].Direction = ParameterDirection.Output;
            OracleParameter[] Oraparam = new OracleParameter[param.Count];
            param.CopyTo(Oraparam, 0);
            param.Clear();
            var dafdafs = (List<BankMaster>)OracleHelper.FetchData<BankMaster>(Oraparam, Common.Queries.CMS_SP_REGZONCOLLECTION_LIST, EnumCommand.DataSource.list).DataSource.Data;
            return dafdafs;
        }

        public static List<BankMaster> FetchListBankBranchMasterSearch(BankMaster objModel)
        {
            try
            {
                OracleParameterCollection param = new OracleParameterCollection();
                param.Add(new OracleParameter(Common.POS_SP_GET_BANKMAPPING_SRCH.E_CODE, objModel.BRANCH_DESC_SEARCH));
                param.Add(new OracleParameter(Common.POS_SP_GET_BANKMAPPING_SRCH.E_BANK_CODE, objModel.BANK_CODE_SEARCH));
                param.Add(new OracleParameter(Common.POS_SP_GET_BANKMAPPING_SRCH.P_OUTTBL, OracleType.Cursor));
                param[Common.POS_SP_GET_BANKMAPPING_SRCH.P_OUTTBL].Direction = ParameterDirection.Output;
                OracleParameter[] Oraparam = new OracleParameter[param.Count];
                param.CopyTo(Oraparam, 0);
                param.Clear();
                var liBankMaster = (List<BankMaster>)OracleHelper.FetchData<BankMaster>(Oraparam, Common.Queries.POS_SP_GET_BANKMAPPING_SRCH, EnumCommand.DataSource.list).DataSource.Data;
                return liBankMaster;
            }
            catch (Exception ex)
            {
                List<BankMaster> liii = new List<BankMaster>();
                return liii;
            }
        }
        public static List<BankMaster> SaveBankBranchMaster(BankMaster bnkMaster)
        {
            OracleParameterCollection param1 = new OracleParameterCollection();
            param1.Add(new OracleParameter(Common.CMS_SP_INSERT_BANKBRANCH_MST.E_BRANCHID, bnkMaster.BRANCHID));
            param1.Add(new OracleParameter(Common.CMS_SP_INSERT_BANKBRANCH_MST.E_BRANCH_TYPE, bnkMaster.BRANCH_TYPE));
            param1.Add(new OracleParameter(Common.CMS_SP_INSERT_BANKBRANCH_MST.E_BANK_CODE, bnkMaster.BANK_CODE));
            param1.Add(new OracleParameter(Common.CMS_SP_INSERT_BANKBRANCH_MST.E_BRANCH_CODE, bnkMaster.BRANCH_CODE));
            param1.Add(new OracleParameter(Common.CMS_SP_INSERT_BANKBRANCH_MST.E_BRANCH_DESC, bnkMaster.BRANCH_DESC));
            param1.Add(new OracleParameter(Common.CMS_SP_INSERT_BANKBRANCH_MST.E_ZONE_CODE, bnkMaster.ZONE_CODE));
            param1.Add(new OracleParameter(Common.CMS_SP_INSERT_BANKBRANCH_MST.E_REGION_CODE, bnkMaster.REGION_CODE));
            param1.Add(new OracleParameter(Common.CMS_SP_INSERT_BANKBRANCH_MST.E_STATE_CODE, bnkMaster.STATE_CODE));
            param1.Add(new OracleParameter(Common.CMS_SP_INSERT_BANKBRANCH_MST.E_ACTIVE, bnkMaster.ACTIVE));
            param1.Add(new OracleParameter(Common.CMS_SP_INSERT_BANKBRANCH_MST.P_OUTTBL, OracleType.Cursor));
            param1[Common.CMS_SP_INSERT_BANKBRANCH_MST.P_OUTTBL].Direction = ParameterDirection.Output;
            OracleParameter[] Oraparam1 = new OracleParameter[param1.Count];
            param1.CopyTo(Oraparam1, 0);
            param1.Clear();
            var liRegionMaster1 = (List<BankMaster>)OracleHelper.FetchData<BankMaster>(Oraparam1, Common.Queries.CMS_SP_INSERT_BANKBRANCH_MST, EnumCommand.DataSource.list).DataSource.Data;
            return liRegionMaster1;
        }

        #endregion

        #region Employee Master
        public static List<EmployeeMaster> GetEmployeeList()
        {
            OracleParameterCollection param = new OracleParameterCollection();
            param.Add(new OracleParameter(Common.POS_SP_GET_EMP_MAST.P_KEY, Common.Keys.GENERAL));
            param.Add(new OracleParameter(Common.POS_SP_GET_EMP_MAST.P_OUTTBL, OracleType.Cursor));
            param[Common.POS_SP_GET_EMP_MAST.P_OUTTBL].Direction = ParameterDirection.Output;
            OracleParameter[] Oraparam = new OracleParameter[param.Count];
            param.CopyTo(Oraparam, 0);
            param.Clear();
            var liEmployeeList = (List<EmployeeMaster>)OracleHelper.FetchData<EmployeeMaster>(Oraparam, Common.Queries.POS_SP_GET_EMP_MAST, EnumCommand.DataSource.list).DataSource.Data;
            return liEmployeeList;
        }
        #endregion
    }
}
