using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Model.Model
{
    public class MasterModel
    {
    }

    public class PhysicianMaster
    {
        public string PHYID { get; set; }
        public string DOCTORNAME { get; set; }
        public string SPECIALITY { get; set; }
        public string MOBILENO { get; set; }
        public string U_ID { get; set; }
        public string ADDRESS_DETAIL { get; set; }
        public string email_address { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }
        public string ISACTIVE { get; set; }
        public string ORGID { get; set; }
        public string INSERTBY { get; set; }
        public string INSERTDATE { get; set; }
        public string MODIFYDATE { get; set; }
        public string P_KEY { get; set; }
        public string MSG { get; set; }
    }

    public class Statemaster
    {
        public string STATE_CODE { get; set; }
        public string STATE_NAME { get; set; }
        public string COUNTRY_CODE { get; set; }
    }

    public class Usermst
    {
        public string U_ID { get; set; }
        public string USERNAME { get; set; }
        public string ORGID { get; set; }
        public string IS_ACTIVE { get; set; }
    }

    public class Dosemst
    {
        public string DOSE_ID { get; set; }
        public string DOSE_QTY { get; set; }

    }

    public class Testmst
    {
        public string INVESTICATIONID { get; set; }
        public string INVNAME { get; set; }

    }
    public class Drugmst
    {
        public string DRUGID { get; set; }

        public string DRUGNAME { get; set; }
        public string OrgID { get; set; }

    }

    public class Citymaster
    {
        public string CITY_CODE { get; set; }
        public string CITY_NAME { get; set; }
        public string STATE_CODE { get; set; }
    }

    public class Drugmaster
    {
        public string DrugID { get; set; }
        public string DrugName { get; set; }
        public string OrgID { get; set; }
        public string DrugType { get; set; }
        public string CreatedBy { get; set; }

        public string ISACTIVE { get; set; }
        public string CreatedAt { get; set; }
        public string ModifyBy { get; set; }
        public string ModiyDate { get; set; }
        public string P_KEY { get; set; }
        public string MSG { get; set; }
    }

    public class Investigationmaster
    {
        public string InvesticationID { get; set; }
        public string InvName { get; set; }
        public string InvCode { get; set; }
        public string InvType { get; set; }
        public string Orgid { get; set; }

        public string ISACTIVE { get; set; }
        public string CreatedAt { get; set; }
        public string CreatedBy { get; set; }   
        public string ModifyBy { get; set; }
        public string ModiyDate { get; set; }
        public string P_KEY { get; set; }
        public string MSG { get; set; }
    }
}
