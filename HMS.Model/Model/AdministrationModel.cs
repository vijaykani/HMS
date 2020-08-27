using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Model.Model
{
    public class AdministrationModel
    {
    }
    public class CompanyMaster
    {
        public string KEY { get; set; }
        public string ROWNO { get; set; }
        public string COMPANY_CODE { get; set; }
        public string COMPANY_NAME { get; set; }
        public string UPDATED_BY { get; set; }
        public string CREATED_BY { get; set; }
        public string COMP_ACTIVE { get; set; }
        public string CREATED_ON { get; set; }
        public string MSG { get; set; }
        public string RESULT { get; set; }
    }
    public class ActionMaster
    {
        public string KEY { get; set; }
        public string ACTION_ID { get; set; }
        public string ROWNO { get; set; }
        public string ACTION_CODE { get; set; }
        public string ACTION_DESC { get; set; }
        public string USER_ACTIVE { get; set; }
        public string DTCREATION { get; set; }
        public string MSG { get; set; }
        public string RESULT { get; set; }
        public string ACTION_DESCR { get; set; }
    }
    public class ResultMaster
    {
        public string KEY { get; set; }
        public string RESULT_ID { get; set; }
        public string ROWNO { get; set; }
        public string ACTION_ID { get; set; }
        public string ACTION_CODE_DESC { get; set; }
        public string RESULT_CODE { get; set; }
        public string RESULT_DESC { get; set; }
        public string USER_ACTIVE { get; set; }
        public string DTCREATION { get; set; }
        public string MSG { get; set; }
        public string RESULT { get; set; }
    }
    public class AreaMaster
    {
        public string TVS_AREACODE { get; set; }
        public string AREA { get; set; }
        public string REGIONCODE { get; set; }
        public string IS_ACTIVE { get; set; }
        public string AREA_NAME { get; set; }
        public string MSG { get; set; }
        public string RESULT { get; set; }
    }

    public class ModuleMaster
    {
        public string KEY { get; set; }
        public string MODULE_ID { get; set; }
        public string MODULE_NAME { get; set; }
        public string ROLE_ID { get; set; }
        public string ROLE_CODE { get; set; }
        public string ROLE_DESC { get; set; }
        public string IS_ACTIVE { get; set; }
        public List<RoleMaster> Roles { get; set; }
    }

    public class RoleMaster
    {
        public string ROLE_ID { get; set; }
        public string ROLE_CODE { get; set; }
        public string ROLE_DESC { get; set; }
        public string IS_ACTIVE { get; set; }
        public string HAS_SUB { get; set; }
        public string MENU_ID { get; set; }
        public string MENU_NAME { get; set; }
        public string MSG { get; set; }
        public string RESULT { get; set; }
        public string USER_ACTIVE { get; set; }
        public string CREATED_BY { get; set; }
        public string MODULE_ID { get; set; }
        public string MODULE_NAME { get; set; }
        public string KEY { get; set; }


    }
    public class BankMaster
    {
        public string KEY { get; set; }
        public string DROPDOWNKEY { get; set; }
        public string BANK_CODE { get; set; }
        public string BANK_NAME { get; set; }
        public string UPDATED_BY { get; set; }
        public string CREATED_BY { get; set; }
        public string BANK_ACTIVE { get; set; }
        public string CREATED_ON { get; set; }
        public string BANK_TYPE { get; set; }
        public string BANK_TYPE_VALUEFIELD { get; set; }
        public string BANK_TYPE_TEXTFIELD { get; set; }
        public string BANK_DESC { get; set; }
        public string ACTIVE { get; set; }
        public string VALUE_FIELD { get; set; }
        public string TEXT_FIELD { get; set; }

        public string BANK_CODE_SEARCH { get; set; }//SEARCH
        public string BRANCH_DESC_SEARCH { get; set; }//SEARCH

        public string P_KEY { get; set; }
        public string P_BANK_CODE { get; set; }
        public string P_BANK_NAME { get; set; }
        public string P_ACTIVE { get; set; }
        public string P_BANK_TYPE { get; set; }
        public string MSG { get; set; }
        public string STATUS { get; set; }
        public string CODE { get; set; }

        public string ZONE_CODE { get; set; }
        public string ZONECODE { get; set; }
        public string ZONE_DESC { get; set; }

        public string ROWNO { get; set; }
        public string DIR_ID { get; set; }
        public string REGION_CODE { get; set; }
        public string REGION_DESC { get; set; }
        public string USER_ACTIVE { get; set; }

        public string STATE_CODE { get; set; }
        public string STATE_NAME { get; set; }

        public string BRANCH_DESC { get; set; }
        public string BRANCH_CODE { get; set; }
        public string BRANCHID { get; set; }
        public string BRANCH_TYPE { get; set; }
        public string BTYPE_DESC { get; set; }
        public string ZONE_NAME { get; set; }
        public string REGION_NAME { get; set; }
        public string STATE_DESC { get; set; }
        public string OPTION_CODE { get; set; }
        public string BRANCH_NAME { get; set; }
        public string ACCOUNT_NO { get; set; }
    }
    public class ProductMaster
    {
        public string KEY { get; set; }
        public string PRODUCT_ID { get; set; }
        public string ROWNO { get; set; }
        public string PRODUCT_CODE { get; set; }
        public string PRODUCT_DESC { get; set; }
        public string PRODUCT_DETAILS { get; set; }
        public string PRODUCT_ACTIVE { get; set; }
        public string DTCREATION { get; set; }
        public string UPDATED_BY { get; set; }
        public string CREATED_BY { get; set; }
        public string MSG { get; set; }
        public string RESULT { get; set; }
    }
    public class BillingMaster
    {
        public string KEY { get; set; }
        public string HDRID { get; set; }
        public string REFNO { get; set; }
        public string BANK_ID { get; set; }
        public string BANK_DESC { get; set; }
        public string PRODUCT_ID { get; set; }
        public string PRODUCT_DESC { get; set; }
        public string CHARGE_TYPE { get; set; }
        public string PRODUCT_CODE { get; set; }
        public string CHARGE_PATTERN_ID { get; set; }
        public string CHARGE_PATTERN { get; set; }
        public string CHARGE_VALUE { get; set; }
        public string RANGE_TYPE { get; set; }
        public string EFFECTIVE_FROM { get; set; }
        public string EFFECTIVE_TO { get; set; }
        public string IS_ACTIVE { get; set; }
        public string BAT_ACTIVE { get; set; }
        public string IS_BILL_GENERATED { get; set; }
        public string CREATED_BY { get; set; }
        public string CREATED_ON { get; set; }
    }
    public class ZonalMaster
    {
        public string KEY { get; set; }
        public string DIR_ID { get; set; }
        public string ROWNO { get; set; }
        public string ZONE_CODE { get; set; }
        public string ZONE_DESC { get; set; }
        public string USER_ACTIVE { get; set; }
        public string CREATED_BY { get; set; }
    }
    public class UserMaster
    {
        public string KEY { get; set; }
        public string USER_ID { get; set; }
        public string ROWNO { get; set; }
        public string USER_NAME { get; set; }
        public string USER_TYPE { get; set; }
        public string EMAIL { get; set; }
        public string MOBILE { get; set; }
        public string DESIGNATION { get; set; }
        public string ROLE_CODE { get; set; }
        public string USER_LEVEL { get; set; }
        public string USER_ACTIVE { get; set; }
        public string CREATED_BY { get; set; }
        public string CREATION_DATE { get; set; }
        public string TVSCS_AREACODE { get; set; }
        public string AREA_CODE { get; set; }
        public string SZBRANCHNAME { get; set; }
        public string AREA_DESC { get; set; }
        public string ROLEID { get; set; }
        public string ROLE_DESCR { get; set; }
        public string Internal { get; set; }
        public string External { get; set; }

    }
    public class RegionMaster
    {
        public string ROWNO { get; set; }
        public string KEY { get; set; }
        public string REGION_CODE { get; set; }
        public string REGION_DESC { get; set; }
        public string ZONE_CODE { get; set; }
        public string ZONE_DESC { get; set; }
        public string USER_ACTIVE { get; set; }
        public string DIR_ID { get; set; }
        public string ACTIVE { get; set; }

        public string E_KEY { get; set; }
        public string E_CODE { get; set; }
        public string E_CODE_DESC { get; set; }
        public string E_ACTIVE { get; set; }
        public string E_ZONE_CODE { get; set; }

        public string D_DIRID { get; set; }
        public string D_ROW_COUNT { get; set; }
        public string D_KEY_CODE { get; set; }
        public string CREATED_BY { get; set; }
        public string STATUS { get; set; }
        public string MSG { get; set; }
        //public string P_OUTTBL { get; set; }
    }
    public class YardMaster
    {
        public string YARD_NAME { get; set; }
        public string ADDRESS_1 { get; set; }
        public string ADDRESS_2 { get; set; }
        public string ADDRESS_3 { get; set; }
        public string ADDRESS_4 { get; set; }
        public string REGION { get; set; }
        public string LAND_MARK { get; set; }
        public string CITY { get; set; }
        public string ZIP_CODE { get; set; }
        public string PHONE_1 { get; set; }
        public string STATE { get; set; }
        public string FAX_NUMBER { get; set; }
        public string PHONE_2 { get; set; }
        public string PHONE_3 { get; set; }
        public string PHONE_EXTN { get; set; }
        public string ISACTIVE { get; set; }
        public string OWNERSHIP_TYPE { get; set; }
    }

    public class EmployeeMaster
    {
        public string EMP_SEQ_ID { get; set; }
        public string EMP_ID { get; set; }
        public string EMP_NAME { get; set; }
        public string EMP_REP_COMPANY { get; set; }
        public string EMP_DESIGNATION { get; set; }
        public string EMP_EMAIL_ID { get; set; }
        public string EMP_MOBILE_NO { get; set; }
        public string EMP_BRANCH { get; set; }

    }
}
