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
    public class TaskViewModel
    {
        #region Properties
        public List<Statemaster> liStateMaster { get; set; }
        public List<Patientreg> liPatientreg { get; set; }
        public List<Citymaster> liCityMaster { get; set; }
        public List<Diagnosisdetail> liDiagnosisdetail { get; set; }
        public List<Drugdetails> liDrugdetails { get; set; }
        public List<Dosemst> lidosemst { get; set; }
        public List<Drugmst> lidrugmst { get; set; }

        public List<Testdetails> liTestdetails { get; set; }
        public List<Testmst> litestmst { get; set; }
        public List<VitalsDetails> liVitals { get; set; }

        public List<PrintDetails> liprintdetails { get; set; }

        public List<CardiologyDetails> liCardiologyDetails { get; set; }
        #endregion


        #region Patient reg
        public static List<Patientreg> SavePatientdetails(Patientreg objPatientreg)
        {
            DataValue dv = new DataValue();

            dv.Add("@Patient_Id", objPatientreg.Patient_Id, EnumCommand.DataType.Varchar);
            dv.Add("@Title_id", objPatientreg.Title_id, EnumCommand.DataType.Varchar);
            dv.Add("@critical_info", objPatientreg.critical_info, EnumCommand.DataType.Varchar);
            dv.Add("@Age", objPatientreg.Age, EnumCommand.DataType.Varchar);
            dv.Add("@Referred_by", objPatientreg.Referred_by, EnumCommand.DataType.Varchar);
            dv.Add("@Email", objPatientreg.Email, EnumCommand.DataType.Varchar);
            dv.Add("@FirstName", objPatientreg.FirstName, EnumCommand.DataType.Varchar);
            dv.Add("@Lastname", objPatientreg.Lastname, EnumCommand.DataType.Varchar);
            dv.Add("@Gender", objPatientreg.Gender, EnumCommand.DataType.Varchar);
            dv.Add("@DOB", objPatientreg.DOB, EnumCommand.DataType.Varchar);
            dv.Add("@Mobileno", objPatientreg.Mobileno, EnumCommand.DataType.Varchar);
            dv.Add("@Occupation", objPatientreg.Occupation, EnumCommand.DataType.Varchar);
            dv.Add("@Blood_Group", objPatientreg.Blood_Group, EnumCommand.DataType.Varchar);
            dv.Add("@Marital_Status", objPatientreg.Marital_Status, EnumCommand.DataType.Varchar);
            dv.Add("@Home_address", objPatientreg.Home_address, EnumCommand.DataType.Varchar);
            dv.Add("@Current_address", objPatientreg.Current_address, EnumCommand.DataType.Varchar);
            dv.Add("@ISACTIVE", objPatientreg.ISACTIVE, EnumCommand.DataType.Varchar);
            dv.Add("@country", objPatientreg.country, EnumCommand.DataType.Varchar);
            dv.Add("@state", objPatientreg.state, EnumCommand.DataType.Varchar);
            dv.Add("@City", objPatientreg.City, EnumCommand.DataType.Varchar);
            dv.Add("@Ethnicity", objPatientreg.Ethnicity, EnumCommand.DataType.Varchar);
            dv.Add("@Org_id", objPatientreg.Org_id, EnumCommand.DataType.Varchar);
            dv.Add("@Insertby", objPatientreg.Insertby, EnumCommand.DataType.Varchar);
            dv.Add("@Insert_Date", objPatientreg.Insert_Date, EnumCommand.DataType.Varchar);
            dv.Add("@Modify_date", objPatientreg.Modify_date, EnumCommand.DataType.Varchar);
            dv.Add("@P_KEY", objPatientreg.P_KEY, EnumCommand.DataType.Varchar);
            var Patientdetails = (List<Patientreg>)SQLHelper.FetchData<Patientreg>(Common.Queries.SP_PRG_ACTION, EnumCommand.DataSource.list, dv).DataSource.Data;
            return Patientdetails;
        }

        //Dropdown list State
        public static List<Statemaster> ListState(Statemaster Statemaster)
        {
            DataValue dv = new DataValue();
            var liststate = (List<Statemaster>)SQLHelper.FetchData<Statemaster>(Common.Queries.SP_GET_STATELIST, EnumCommand.DataSource.list, dv).DataSource.Data;
            return liststate;
        }

        //Dropdown list City
        public static List<Citymaster> ListCity(Patientreg obj)
        {
            DataValue dv = new DataValue();
            dv.Add("@STATE_CODE", obj.state, EnumCommand.DataType.Varchar);
            var listcity = (List<Citymaster>)SQLHelper.FetchData<Citymaster>(Common.Queries.SP_GET_CITYLIST, EnumCommand.DataSource.list, dv).DataSource.Data;
            return listcity;
        }
        #endregion

        #region Diagnosisdetails
        public static List<Diagnosisdetail> SaveDiagnosisdetails(Diagnosisdetail Diagnosisdetail)
        {
            DataValue dv = new DataValue();

            dv.Add("@Patient_Diagnosisid", Diagnosisdetail.Patient_Diagnosisid, EnumCommand.DataType.Varchar);
            dv.Add("@PatientVisitID", Diagnosisdetail.PatientVisitID, EnumCommand.DataType.Varchar);
            dv.Add("@Diagnosis_title", Diagnosisdetail.Diagnosis_title, EnumCommand.DataType.Varchar);
            dv.Add("@Diagnosis_desc", Diagnosisdetail.Diagnosis_desc, EnumCommand.DataType.Varchar);
            dv.Add("@Orgid", Diagnosisdetail.Orgid, EnumCommand.DataType.Varchar);
            dv.Add("@CreatedBy", Diagnosisdetail.CreatedBy, EnumCommand.DataType.Varchar);
            dv.Add("@CreatedAt", Diagnosisdetail.CreatedAt, EnumCommand.DataType.Varchar);
            dv.Add("@ModifyBy", Diagnosisdetail.ModifyBy, EnumCommand.DataType.Varchar);
            dv.Add("@ModiyDate", Diagnosisdetail.ModiyDate, EnumCommand.DataType.Varchar);
            dv.Add("@P_KEY", Diagnosisdetail.P_KEY, EnumCommand.DataType.Varchar);
            var Diagnosisdetails = (List<Diagnosisdetail>)SQLHelper.FetchData<Diagnosisdetail>(Common.Queries.SP_DIAGNOSIS_ACTION, EnumCommand.DataSource.list, dv).DataSource.Data;
            return Diagnosisdetails;
        }
        #endregion

        #region Drugdetails
        public static List<Drugdetails> SaveDrugdetails(Drugdetails Drugdetails)
        {
            DataValue dv = new DataValue();

            dv.Add("@PatientdrugDetailID", Drugdetails.PatientdrugDetailID, EnumCommand.DataType.Varchar);
            dv.Add("@PatientVisitID", Drugdetails.PatientVisitID, EnumCommand.DataType.Varchar);
            dv.Add("@Drug_id", Drugdetails.Drug_id, EnumCommand.DataType.Varchar);
            dv.Add("@strength", Drugdetails.strength, EnumCommand.DataType.Varchar);
            dv.Add("@OrgID", Drugdetails.OrgID, EnumCommand.DataType.Varchar);
            dv.Add("@Directionforuse", Drugdetails.Directionforuse, EnumCommand.DataType.Varchar);
            dv.Add("@Quantity", Drugdetails.Quantity, EnumCommand.DataType.Varchar);
            dv.Add("@Doses_id", Drugdetails.Doses_id, EnumCommand.DataType.Varchar);
            dv.Add("@CreatedBy", Drugdetails.CreatedBy, EnumCommand.DataType.Varchar);
            dv.Add("@CreatedAt", Drugdetails.CreatedAt, EnumCommand.DataType.Varchar);
            dv.Add("@ModifyBy", Drugdetails.ModifyBy, EnumCommand.DataType.Varchar);
            dv.Add("@ModiyDate", Drugdetails.ModiyDate, EnumCommand.DataType.Varchar);
            dv.Add("@P_KEY", Drugdetails.P_KEY, EnumCommand.DataType.Varchar);
            var Drugdetails_list = (List<Drugdetails>)SQLHelper.FetchData<Drugdetails>(Common.Queries.SP_DRUGDETAIL_ACTION, EnumCommand.DataSource.list, dv).DataSource.Data;
            return Drugdetails_list;
        }

        //Dropdown list Dosemst
        public static List<Dosemst> ListDosedetails(Dosemst Dosemst)
        {
            DataValue dv = new DataValue();
            var listdose = (List<Dosemst>)SQLHelper.FetchData<Dosemst>(Common.Queries.SP_GET_DOSELIST, EnumCommand.DataSource.list, dv).DataSource.Data;
            return listdose;
        }

        public static List<Drugmst> ListDrugdetails(Drugmst Drugmst)
        {
            DataValue dv = new DataValue();
            dv.Add("@OrgID", Drugmst.OrgID, EnumCommand.DataType.Varchar);
            var listdrug = (List<Drugmst>)SQLHelper.FetchData<Drugmst>(Common.Queries.SP_GET_DRUGLIST, EnumCommand.DataSource.list, dv).DataSource.Data;
            return listdrug;
        }

        #endregion

        #region Testdetails
        public static List<Testdetails> SaveTestdetails(Testdetails Testdetails)
        {
            DataValue dv = new DataValue();

            dv.Add("@Patient_Testdetailid", Testdetails.Patient_Testdetailid, EnumCommand.DataType.Varchar);
            dv.Add("@PatientVisitID", Testdetails.PatientVisitID, EnumCommand.DataType.Varchar);
            dv.Add("@Test_id", Testdetails.Test_id, EnumCommand.DataType.Varchar);
            dv.Add("@Test_Uploadpath", Testdetails.Test_Uploadpath, EnumCommand.DataType.Varchar);
            dv.Add("@Test_Uploadfilename", Testdetails.Test_Uploadfilename, EnumCommand.DataType.Varchar);
            dv.Add("@Test_details", Testdetails.Test_details, EnumCommand.DataType.Varchar);
            dv.Add("@OrgID", Testdetails.orgid, EnumCommand.DataType.Varchar);
            dv.Add("@CreatedBy", Testdetails.CreatedBy, EnumCommand.DataType.Varchar);
            dv.Add("@CreatedAt", Testdetails.CreatedAt, EnumCommand.DataType.Varchar);
            dv.Add("@ModifyBy", Testdetails.ModifyBy, EnumCommand.DataType.Varchar);
            dv.Add("@ModiyDate", Testdetails.ModiyDate, EnumCommand.DataType.Varchar);
            dv.Add("@P_KEY", Testdetails.P_KEY, EnumCommand.DataType.Varchar);
            var Testdetails_list = (List<Testdetails>)SQLHelper.FetchData<Testdetails>(Common.Queries.SP_TESTDETAIL_ACTION, EnumCommand.DataSource.list, dv).DataSource.Data;
            return Testdetails_list;
        }

        //Dropdown list Testmst
        public static List<Testmst> ListTestdetails(Testmst Testmst)
        {
            DataValue dv = new DataValue();
            var listTest = (List<Testmst>)SQLHelper.FetchData<Testmst>(Common.Queries.SP_GET_TESTLIST, EnumCommand.DataSource.list, dv).DataSource.Data;
            return listTest;
        }
        #endregion


        #region SaveVitals
        public static List<VitalsDetails> SaveVitalsdetails(VitalsDetails VitalsDetails)
        {
            DataValue dv = new DataValue();

            dv.Add("@Patient_Id", VitalsDetails.Patient_Id, EnumCommand.DataType.Varchar);
            dv.Add("@Symtoms", VitalsDetails.Symtoms, EnumCommand.DataType.Varchar);
            dv.Add("@PatientVisitID", VitalsDetails.PatientVisitID, EnumCommand.DataType.Varchar);
            dv.Add("@DoctorReport", VitalsDetails.Doctorreport, EnumCommand.DataType.Varchar);
            dv.Add("@Visit_Type", VitalsDetails.Visit_Type, EnumCommand.DataType.Varchar);
            dv.Add("@Orgid", VitalsDetails.Orgid, EnumCommand.DataType.Varchar);
            dv.Add("@PhysicianID", VitalsDetails.PhysicianID, EnumCommand.DataType.Varchar);
            dv.Add("@BP_systolic", VitalsDetails.BP_systolic, EnumCommand.DataType.Varchar);
            dv.Add("@BP_Diastolic", VitalsDetails.BP_Diastolic, EnumCommand.DataType.Varchar);
            dv.Add("@Temperature", VitalsDetails.Temperature, EnumCommand.DataType.Varchar);
            dv.Add("@Pulse", VitalsDetails.Pulse, EnumCommand.DataType.Varchar);
            dv.Add("@Respiratory_rate", VitalsDetails.Respiratory_rate, EnumCommand.DataType.Varchar);
            dv.Add("@Weight", VitalsDetails.Weight, EnumCommand.DataType.Varchar);
            dv.Add("@Height", VitalsDetails.Height, EnumCommand.DataType.Varchar);
            dv.Add("@CreatedBy", VitalsDetails.CreatedBy, EnumCommand.DataType.Varchar);
            dv.Add("@P_KEY", VitalsDetails.P_KEY, EnumCommand.DataType.Varchar);
            var Vitaldetails = (List<VitalsDetails>)SQLHelper.FetchData<VitalsDetails>(Common.Queries.SP_SAVEVITALS, EnumCommand.DataSource.list, dv).DataSource.Data;
            return Vitaldetails;
        }
        #endregion

        #region Printdetails
        public static List<PrintDetails> Printdetails(PrintDetails PrintDetails)
        {
            DataValue dv = new DataValue();

            dv.Add("@PatientVisitID", PrintDetails.PatientVisitID, EnumCommand.DataType.Varchar);
            dv.Add("@OrgID", PrintDetails.OrgID, EnumCommand.DataType.Varchar);
            dv.Add("@CreatedBy", PrintDetails.CreatedBy, EnumCommand.DataType.Varchar);
            dv.Add("@CreatedAt", PrintDetails.CreatedAt, EnumCommand.DataType.Varchar);
            dv.Add("@ModifyBy", PrintDetails.ModifyBy, EnumCommand.DataType.Varchar);
            dv.Add("@ModiyDate", PrintDetails.ModiyDate, EnumCommand.DataType.Varchar);
            dv.Add("@P_KEY", PrintDetails.P_KEY, EnumCommand.DataType.Varchar);
            var Printdetails = (List<PrintDetails>)SQLHelper.FetchData<PrintDetails>(Common.Queries.SP_PRINT_PRESCRIPTIONDETAIL, EnumCommand.DataSource.list, dv).DataSource.Data;
            return Printdetails;
        }
        #endregion

        #region Cardiologydetails
        public static List<CardiologyDetails> SaveCardiologydetails(CardiologyDetails CardiologyDetails)
        {
            DataValue dv = new DataValue();
            dv.Add("@Patient_Id", CardiologyDetails.Patient_Id, EnumCommand.DataType.Varchar);      
            dv.Add("@PatientVisitID", CardiologyDetails.PatientVisitID, EnumCommand.DataType.Varchar);
            dv.Add("@Echogencity", CardiologyDetails.Echogencity, EnumCommand.DataType.Varchar);
            dv.Add("@Orgid", CardiologyDetails.Orgid, EnumCommand.DataType.Varchar);
            dv.Add("@AO", CardiologyDetails.AO, EnumCommand.DataType.Varchar);
            dv.Add("@LA", CardiologyDetails.LA, EnumCommand.DataType.Varchar);
            dv.Add("@RVID", CardiologyDetails.RVID, EnumCommand.DataType.Varchar);
            dv.Add("@LVID_one", CardiologyDetails.LVID_one, EnumCommand.DataType.Varchar);
            dv.Add("@LVID_Two", CardiologyDetails.LVID_Two, EnumCommand.DataType.Varchar);
            dv.Add("@IVS", CardiologyDetails.IVS, EnumCommand.DataType.Varchar);
            dv.Add("@LVPW", CardiologyDetails.LVPW, EnumCommand.DataType.Varchar);
            dv.Add("@EF", CardiologyDetails.EF, EnumCommand.DataType.Varchar);
            dv.Add("@FS", CardiologyDetails.FS, EnumCommand.DataType.Varchar);
            dv.Add("@MitralValue_AML", CardiologyDetails.MitralValue_AML, EnumCommand.DataType.Varchar);
            dv.Add("@MitralValue_PML", CardiologyDetails.MitralValue_PML, EnumCommand.DataType.Varchar);
            dv.Add("@IntratrialSeptom", CardiologyDetails.IntratrialSeptom, EnumCommand.DataType.Varchar);
            dv.Add("@IntervendicularSeptom", CardiologyDetails.IntervendicularSeptom, EnumCommand.DataType.Varchar);
            dv.Add("@AorticValue", CardiologyDetails.AorticValue, EnumCommand.DataType.Varchar);
            dv.Add("@PulmonaryArtory", CardiologyDetails.PulmonaryArtory, EnumCommand.DataType.Varchar);
            dv.Add("@TricuspidValue", CardiologyDetails.TricuspidValue, EnumCommand.DataType.Varchar);
            dv.Add("@Aortia", CardiologyDetails.Aortia, EnumCommand.DataType.Varchar);
            dv.Add("@PulmonaryValue", CardiologyDetails.PulmonaryValue, EnumCommand.DataType.Varchar);
            dv.Add("@RightAtrium", CardiologyDetails.RightAtrium, EnumCommand.DataType.Varchar);
            dv.Add("@LeftAtrium", CardiologyDetails.LeftAtrium, EnumCommand.DataType.Varchar);
            dv.Add("@RightVendricle", CardiologyDetails.RightVendricle, EnumCommand.DataType.Varchar);
            dv.Add("@Pericardiam", CardiologyDetails.Pericardiam, EnumCommand.DataType.Varchar);
            dv.Add("@Dopplerstudies", CardiologyDetails.Dopplerstudies, EnumCommand.DataType.Varchar);
            dv.Add("@Impression", CardiologyDetails.Impression, EnumCommand.DataType.Varchar);
            dv.Add("@RefferedBy", CardiologyDetails.RefferedBy, EnumCommand.DataType.Varchar);
            dv.Add("@CreatedBy", CardiologyDetails.CreatedBy, EnumCommand.DataType.Varchar);
            dv.Add("@CreatedAt", CardiologyDetails.CreatedAt, EnumCommand.DataType.Varchar);
            dv.Add("@P_KEY", CardiologyDetails.P_KEY, EnumCommand.DataType.Varchar);
            var Cardiologydetails = (List<CardiologyDetails>)SQLHelper.FetchData<CardiologyDetails>(Common.Queries.SP_SAVE_CARDIOLOGYDETAILS, EnumCommand.DataSource.list, dv).DataSource.Data;
            return Cardiologydetails;
        }
        #endregion

        
    }


}
