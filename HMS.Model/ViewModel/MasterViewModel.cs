using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Model.Model;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Data;
using HMS.DAO;
using HMS.UTILITY;
using System.Web;

namespace HMS.Model.ViewModel
{
    public class MasterViewModel
    {
        #region Properties
        public List<Statemaster> liStateMaster { get; set; }
        public List<PhysicianMaster> liphysicianMaster { get; set; }
        public List<Citymaster> liCityMaster { get; set; }
        public List<Drugmaster> liDrugMaster { get; set; }
        public List<Usermst> liUserMaster { get; set; }

        public List<Investigationmaster> liInvestigationMaster { get; set; }
        #endregion
        #region Customer Master
        public static List<PhysicianMaster> SavePhysicianMaster(PhysicianMaster PhysicianMaster)
        {
            DataValue dv = new DataValue();

            dv.Add("@PHYID", PhysicianMaster.PHYID, EnumCommand.DataType.Varchar);
            dv.Add("@ISACTIVE", PhysicianMaster.ISACTIVE, EnumCommand.DataType.Varchar);
            dv.Add("@U_ID", PhysicianMaster.U_ID, EnumCommand.DataType.Varchar);
            dv.Add("@DOCTORNAME", PhysicianMaster.DOCTORNAME, EnumCommand.DataType.Varchar);
            dv.Add("@SPECIALITY", PhysicianMaster.SPECIALITY, EnumCommand.DataType.Varchar);
            dv.Add("@MOBILENO", PhysicianMaster.MOBILENO, EnumCommand.DataType.Varchar);
            dv.Add("@ADDRESS_DETAIL", PhysicianMaster.ADDRESS_DETAIL, EnumCommand.DataType.Varchar);
            dv.Add("@ORGID", PhysicianMaster.ORGID, EnumCommand.DataType.Varchar);
            dv.Add("@INSERTBY", PhysicianMaster.INSERTBY, EnumCommand.DataType.Varchar);
            dv.Add("@INSERTDATE", PhysicianMaster.INSERTDATE, EnumCommand.DataType.Varchar);
            dv.Add("@MODIFYDATE", PhysicianMaster.MODIFYDATE, EnumCommand.DataType.Varchar);
            dv.Add("@email_address", PhysicianMaster.email_address, EnumCommand.DataType.Varchar);
            dv.Add("@state", PhysicianMaster.state, EnumCommand.DataType.Varchar);
            dv.Add("@city", PhysicianMaster.city, EnumCommand.DataType.Varchar);
            dv.Add("@zipcode", PhysicianMaster.zipcode, EnumCommand.DataType.Varchar);
            dv.Add("@P_KEY", PhysicianMaster.P_KEY, EnumCommand.DataType.Varchar);
            var Physicianmasterinsert = (List<PhysicianMaster>)SQLHelper.FetchData<PhysicianMaster>(Common.Queries.SP_PHYMST_ACTION, EnumCommand.DataSource.list, dv).DataSource.Data;
            return Physicianmasterinsert;
        }

        //Dropdown list State
        public static List<Statemaster> ListState(Statemaster Statemaster)
        {
            DataValue dv = new DataValue();
            var liststate = (List<Statemaster>)SQLHelper.FetchData<Statemaster>(Common.Queries.SP_GET_STATELIST, EnumCommand.DataSource.list, dv).DataSource.Data;
            return liststate;
        }

          public static List<Usermst> ListUserdetails(Usermst Usermst)
        {
            DataValue dv = new DataValue();
            dv.Add("@ORGID", Usermst.ORGID, EnumCommand.DataType.Varchar);
            var listuserdetails = (List<Usermst>)SQLHelper.FetchData<Usermst>(Common.Queries.SP_GET_LOGIN_USER, EnumCommand.DataSource.list, dv).DataSource.Data;
            return listuserdetails;
        }

        //Dropdown list City
        public static List<Citymaster> ListCity(PhysicianMaster obj)
        {
            DataValue dv = new DataValue();
            dv.Add("@STATE_CODE", obj.state, EnumCommand.DataType.Varchar);
            var listcity = (List<Citymaster>)SQLHelper.FetchData<Citymaster>(Common.Queries.SP_GET_CITYLIST, EnumCommand.DataSource.list, dv).DataSource.Data;
            return listcity;
        }
        #endregion

        #region Drugmaster
        public static List<Drugmaster> SaveDrugMaster(Drugmaster Drugmaster)
        {
            DataValue dv = new DataValue();

            dv.Add("@DrugID", Drugmaster.DrugID, EnumCommand.DataType.Varchar);
            dv.Add("@ISACTIVE", Drugmaster.ISACTIVE, EnumCommand.DataType.Varchar);
            dv.Add("@DrugName", Drugmaster.DrugName, EnumCommand.DataType.Varchar);
            dv.Add("@OrgID", Drugmaster.OrgID, EnumCommand.DataType.Varchar);
            dv.Add("@CreatedBy", Drugmaster.CreatedBy, EnumCommand.DataType.Varchar);
            dv.Add("@CreatedAt", Drugmaster.CreatedAt, EnumCommand.DataType.Varchar);
            dv.Add("@ModifyBy", Drugmaster.ModifyBy, EnumCommand.DataType.Varchar);
            dv.Add("@ModiyDate", Drugmaster.ModiyDate, EnumCommand.DataType.Varchar);
            dv.Add("@DrugType", Drugmaster.DrugType, EnumCommand.DataType.Varchar);
            dv.Add("@P_KEY", Drugmaster.P_KEY, EnumCommand.DataType.Varchar);
            var Drugmasterinsert = (List<Drugmaster>)SQLHelper.FetchData<Drugmaster>(Common.Queries.SP_DRUGMST_ACTION, EnumCommand.DataSource.list, dv).DataSource.Data;
            return Drugmasterinsert;
        }
        #endregion

        #region Investigationmaster
        public static List<Investigationmaster> SaveInvestigationMaster(Investigationmaster Investigationmaster)
        {
            DataValue dv = new DataValue();

            dv.Add("@InvesticationID", Investigationmaster.InvesticationID, EnumCommand.DataType.Varchar);
            dv.Add("@InvName", Investigationmaster.InvName, EnumCommand.DataType.Varchar);
            dv.Add("@InvCode", Investigationmaster.InvCode, EnumCommand.DataType.Varchar);
            dv.Add("@InvType", Investigationmaster.InvType, EnumCommand.DataType.Varchar);
            dv.Add("@ISACTIVE", Investigationmaster.ISACTIVE, EnumCommand.DataType.Varchar);
            dv.Add("@CreatedAt", Investigationmaster.CreatedAt, EnumCommand.DataType.Varchar);
            dv.Add("@CreatedBy", Investigationmaster.CreatedBy, EnumCommand.DataType.Varchar);
            dv.Add("@ModifyBy", Investigationmaster.ModifyBy, EnumCommand.DataType.Varchar);
            dv.Add("@ModiyDate", Investigationmaster.ModiyDate, EnumCommand.DataType.Varchar);
            dv.Add("@Orgid", Investigationmaster.Orgid, EnumCommand.DataType.Varchar);
            dv.Add("@P_KEY", Investigationmaster.P_KEY, EnumCommand.DataType.Varchar);
            var Investigationmasterinsert = (List<Investigationmaster>)SQLHelper.FetchData<Investigationmaster>(Common.Queries.SP_INVESTIGATIONMST_ACTION, EnumCommand.DataSource.list, dv).DataSource.Data;
            return Investigationmasterinsert;
        }

        #endregion
    }
}
