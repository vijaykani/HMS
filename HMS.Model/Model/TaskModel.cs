using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Model.Model
{
    public class TaskModel
    {
    }
    public class Patientreg
    {
        public string Patient_Id { get; set; }

        public string Patient_no { get; set; }

        public string Age { get; set; }
        public string Title_id { get; set; }
        public string critical_info { get; set; }
        public string Referred_by { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }

        public string Lastname { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }
        public string Mobileno { get; set; }
        public string Occupation { get; set; }
        public string Blood_Group { get; set; }
        public string Marital_Status { get; set; }
        public string Home_address { get; set; }
        public string Current_address { get; set; }
        public string ISACTIVE { get; set; }
        public string country { get; set; }
        public string state { get; set; }
        public string City { get; set; }
        public string Ethnicity { get; set; }
        public string Org_id { get; set; }
        public string Insertby { get; set; }
        public string Insert_Date { get; set; }
        public string Modify_date { get; set; }
        public string P_KEY { get; set; }
        public string MSG { get; set; }
    }

    public class Diagnosisdetail
    {
        public string Patient_Diagnosisid { get; set; }
        public string PatientVisitID { get; set; }
        public string Diagnosis_title { get; set; }

        public string Patient_Id { get; set; }
        public string Diagnosis_desc { get; set; }
        public string Orgid { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedAt { get; set; }
        public string ModifyBy { get; set; }
        public string ModiyDate { get; set; }
        public string P_KEY { get; set; }
        public string MSG { get; set; }


    }
    public class Drugdetails
    {
        public string PatientdrugDetailID { get; set; }
        public string PatientVisitID { get; set; }

        public string Patient_Id { get; set; }
        public string OrgID { get; set; }
        public string Drug_id { get; set; }
        public string DrugName { get; set; }
        public string strength { get; set; }
        public string Directionforuse { get; set; }
        public string Quantity { get; set; }
        public string Doses_id { get; set; }
        public string Dose_qty { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedAt { get; set; }
        public string ModifyBy { get; set; }
        public string ModiyDate { get; set; }
        public string P_KEY { get; set; }
        public string MSG { get; set; }



    }

    public class Testdetails
    {
        public string Patient_Testdetailid { get; set; }
        public string PatientVisitID { get; set; }
        public string Test_id { get; set; }
        public string Test_details { get; set; }
        public string Patient_Id { get; set; }
        public string InvName { get; set; }
        public string InvCode { get; set; }
        public string InvType { get; set; }
        public string Test_Uploadpath { get; set; }

        public string Test_Uploadfilename { get; set; }
        public string Test_Upload { get; set; }
        public string orgid { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedAt { get; set; }
        public string ModifyBy { get; set; }
        public string ModiyDate { get; set; }
        public string P_KEY { get; set; }
        public string MSG { get; set; }

    }
    public class VitalsDetails
    {
        public string Patient_Id { get; set; }
        public string Visit_Type { get; set; }
        public string PatientVisitID { get; set; }
        //   public string VisitDate { get; set; }
        //   public string VisitNumber { get; set; }
        public string Symtoms { get; set; }
        public string PhysicianID { get; set; }
        public string Doctorreport { get; set; }
        // public string NextVisitDate { get; set; }
        public string Patient_VitalsID { get; set; }
        public string BP_systolic { get; set; }
        public string BP_Diastolic { get; set; }
        public string Temperature { get; set; }
        public string Pulse { get; set; }
        public string Respiratory_rate { get; set; }
        public string Weight { get; set; }
        public string Height { get; set; }
        public string Orgid { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedAt { get; set; }
        public string ModifyBy { get; set; }
        public string ModiyDate { get; set; }
        public string P_KEY { get; set; }
        public string MSG { get; set; }

    }
    public class PrintDetails
    {

        public string FROMDATE { get; set; }
        public string TODATE { get; set; }
        public string DOCTORNAME { get; set; }
        public string SPECIALITY { get; set; }
        public string Doctorreport { get; set; }

        public string OrgDisplayAddress { get; set; }
        public string email_address { get; set; }
        public string DMOBILENO { get; set; }
        public string Current_address { get; set; }
        public string PMobileno { get; set; }
        public string PatientName { get; set; }
        public string Age { get; set; }
        public string Sex { get; set; }
        public string BP_systolic { get; set; }
        public string BP_Diastolic { get; set; }
        public string DrugName { get; set; }
        public string Dose_qty { get; set; }
        public string PatientVisitID { get; set; }
        public string OrgID { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedAt { get; set; }
        public string ModifyBy { get; set; }
        public string ModiyDate { get; set; }

        public string P_KEY { get; set; }
    }

    public class CardiologyDetails
    {

        public string Patient_Id { get; set; }
        public string DOCTORNAME { get; set; }
        public string SPECIALITY { get; set; }
        public string email_address { get; set; }
        public string DMOBILENO { get; set; }
        public string OrgDisplayAddress { get; set; }
        public string PatientName { get; set; }
        public string Age { get; set; }
        public string Sex { get; set; }
        public string Current_address { get; set; }
        public string PMobileno { get; set; }
        public string CardioID { get; set; }
        public string Echogencity { get; set; }
        public string PatientVisitID { get; set; }
        public string Orgid { get; set; }
        public string AO { get; set; }
        public string LA { get; set; }
        public string RVID { get; set; }
        public string LVID_one { get; set; }
        public string LVID_Two { get; set; }
        public string IVS { get; set; }
        public string LVPW { get; set; }
        public string EF { get; set; }
        public string FS { get; set; }
        public string MitralValue_AML { get; set; }
        public string MitralValue_PML { get; set; }
        public string IntratrialSeptom { get; set; }
        public string IntervendicularSeptom { get; set; }
        public string AorticValue { get; set; }
        public string PulmonaryArtory { get; set; }
        public string TricuspidValue { get; set; }
        public string Aortia { get; set; }
        public string PulmonaryValue { get; set; }
        public string RightAtrium { get; set; }
        public string LeftAtrium { get; set; }
        public string RightVendricle { get; set; }
        public string Pericardiam { get; set; }
        public string Dopplerstudies { get; set; }
        public string Impression { get; set; }
        public string RefferedBy { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedAt { get; set; }
        public string ModifyBy { get; set; }
        public string ModiyDate { get; set; }
        public string P_KEY { get; set; }
        public string MSG { get; set; }
    }


}
