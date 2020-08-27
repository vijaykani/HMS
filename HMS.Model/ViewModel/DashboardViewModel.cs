using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Model.Model;
using System.Data.OracleClient;
using System.Data;
using HMS.UTILITY;
using HMS.DAO;
using System.Web;

namespace HMS.Model.ViewModel
{
    public class DashboardViewModel
    {
        public List<DashboardModel> liPOSMonthlyCount { get; set; }
        public List<DashboardModel> liPOSMonthlyPlan { get; set; }
        public List<DashboardModel> liPOSMonthlyActualReport { get; set; }
        public List<TimeLineModel> liTimeLineData { get; set; }

        #region Methods
        public static List<DashboardModel> FetchPOSMonthlyCount(DashboardModel DashboardModel)
        {
            OracleParameterCollection param = new OracleParameterCollection();
            param.Add(new OracleParameter(Common.POS_MONTHLY_COUNT.P_USER_ROLE, HttpContext.Current.Session[Common.SESSION_VARIABLES.ROLE_CODE].ToString()));
            param.Add(new OracleParameter(Common.POS_MONTHLY_COUNT.P_USER_ID, HttpContext.Current.Session[Common.SESSION_VARIABLES.USER_ID].ToString()));
            param.Add(new OracleParameter(Common.POS_MONTHLY_COUNT.P_MONTH, DashboardModel.MONTH_YEAR));
            param.Add(new OracleParameter(Common.POS_MONTHLY_COUNT.P_OUTTBL, OracleType.Cursor));
            param[Common.POS_MONTHLY_COUNT.P_OUTTBL].Direction = ParameterDirection.Output;
            OracleParameter[] Oraparam = new OracleParameter[param.Count];
            param.CopyTo(Oraparam, 0);
            param.Clear();
            var liCompanyMaster = (List<DashboardModel>)OracleHelper.FetchData<DashboardModel>(Oraparam, Common.Queries.POS_SP_MONTHLY_COUNT, EnumCommand.DataSource.list).DataSource.Data;
            return liCompanyMaster;
        }
        public static List<DashboardModel> FetchPOSMonthlyPlan()
        {
            OracleParameterCollection param = new OracleParameterCollection();
            param.Add(new OracleParameter(Common.POS_MONTHLY_COUNT.P_OUTTBL, OracleType.Cursor));
            param[Common.POS_MONTHLY_COUNT.P_OUTTBL].Direction = ParameterDirection.Output;
            OracleParameter[] Oraparam = new OracleParameter[param.Count];
            param.CopyTo(Oraparam, 0);
            param.Clear();
            var liPOSMonthlyPlan = (List<DashboardModel>)OracleHelper.FetchData<DashboardModel>(Oraparam, Common.Queries.POS_SP_MONTHLY_PLAN_REPORT, EnumCommand.DataSource.list).DataSource.Data;
            return liPOSMonthlyPlan;
        }
        public static List<DashboardModel> FetchPOSMonthlyActualReport()
        {
            OracleParameterCollection param = new OracleParameterCollection();
            param.Add(new OracleParameter(Common.POS_MONTHLY_COUNT.P_OUTTBL, OracleType.Cursor));
            param[Common.POS_MONTHLY_COUNT.P_OUTTBL].Direction = ParameterDirection.Output;
            OracleParameter[] Oraparam = new OracleParameter[param.Count];
            param.CopyTo(Oraparam, 0);
            param.Clear();
            var liPOSMonthlyPlan = (List<DashboardModel>)OracleHelper.FetchData<DashboardModel>(Oraparam, Common.Queries.POS_SP_MONTHLY_ACTUAL_REPORT, EnumCommand.DataSource.list).DataSource.Data;
            return liPOSMonthlyPlan;
        }
        #endregion

        #region STATIC DATA
        public static List<TimeLineModel> FetchTimeLineData()
        {
            //List<TimeLineModel> liTimeLineData = new List<TimeLineModel>();
            #region sample data
            //liTimeLineData.Add(new TimeLineModel
            //{
            //    DUPLICATECNT = 0,
            //    ACCOUNTNUMBER = "NMZ207154741",
            //    ACCOUNTTYPE = "Allocated Account",
            //    ACCOUNTCOMMENT = "A privileged user is a user who has been allocated powers within the computer system which are significantly greater than those available to the majority of users.",
            //    ACCOUNTDATE = "16/01/2014",
            //    ACCOUNTEXTENDEDDATE = "January 16th, 2014",
            //    ACCOUNTDAYMON = "16 Jan",
            //    ACCOUNTYEAR = "2014"
            //});
            //liTimeLineData.Add(new TimeLineModel
            //{
            //    DUPLICATECNT = 0,
            //    ACCOUNTNUMBER = "TEJQ07154741",
            //    ACCOUNTTYPE = "UnAllocated Account",
            //    ACCOUNTCOMMENT = "Payment is still unknown / unidentified, the unknown receipt as posted in the Unallocated Revenue Account will be journalised.",
            //    ACCOUNTDATE = "16/01/2014",
            //    ACCOUNTEXTENDEDDATE = "January 16th, 2014",
            //    ACCOUNTDAYMON = "16 Jan",
            //    ACCOUNTYEAR = "2014"
            //});
            //liTimeLineData.Add(new TimeLineModel
            //{
            //    DUPLICATECNT = 0,
            //    ACCOUNTNUMBER = "TESTGET7154741",
            //    ACCOUNTTYPE = "Allocated Account",
            //    ACCOUNTCOMMENT = "A privileged user is a user who has been allocated powers within the computer system which are significantly greater than those available to the majority of users.",
            //    ACCOUNTDATE = "16/01/2014",
            //    ACCOUNTEXTENDEDDATE = "January 16th, 2014",
            //    ACCOUNTDAYMON = "16 Jan",
            //    ACCOUNTYEAR = "2014"
            //});
            //liTimeLineData.Add(new TimeLineModel
            //{
            //    DUPLICATECNT = 0,
            //    ACCOUNTNUMBER = "ACM123154741",
            //    ACCOUNTTYPE = "UnAllocated Account",
            //    ACCOUNTCOMMENT = "Payment is still unknown / unidentified, the unknown receipt as posted in the Unallocated Revenue Account will be journalised.",
            //    ACCOUNTDATE = "28/02/2014",
            //    ACCOUNTEXTENDEDDATE = "February 28th, 2014",
            //    ACCOUNTDAYMON = "28 Feb",
            //    ACCOUNTYEAR = "2014"
            //});
            //liTimeLineData.Add(new TimeLineModel
            //{
            //    DUPLICATECNT = 0,
            //    ACCOUNTNUMBER = "NM52407154741",
            //    ACCOUNTTYPE = "Seizure Account",
            //    ACCOUNTCOMMENT = "Seizures of bank accounts and bank assets may be attempted by creditors in instances where the borrower can’t keep up with the monthly debt payments.",
            //    ACCOUNTDATE = "20/03/2014",
            //    ACCOUNTEXTENDEDDATE = "March 20th, 2014",
            //    ACCOUNTDAYMON = "20 Mar",
            //    ACCOUNTYEAR = "2014"
            //});
            //liTimeLineData.Add(new TimeLineModel
            //{
            //    DUPLICATECNT = 0,
            //    ACCOUNTNUMBER = "APP07154741",
            //    ACCOUNTTYPE = "UnAllocated Account",
            //    ACCOUNTCOMMENT = "Payment is still unknown / unidentified, the unknown receipt as posted in the Unallocated Revenue Account will be journalised.",
            //    ACCOUNTDATE = "20/05/2014",
            //    ACCOUNTEXTENDEDDATE = "May 20th, 2014",
            //    ACCOUNTDAYMON = "20 May",
            //    ACCOUNTYEAR = "2014"
            //});
            //liTimeLineData.Add(new TimeLineModel
            //{
            //    DUPLICATECNT = 0,
            //    ACCOUNTNUMBER = "ZRP07154741",
            //    ACCOUNTTYPE = "UnAllocated Account",
            //    ACCOUNTCOMMENT = "Payment is still unknown / unidentified, the unknown receipt as posted in the Unallocated Revenue Account will be journalised.",
            //    ACCOUNTDATE = "09/07/2014",
            //    ACCOUNTEXTENDEDDATE = "July 09th, 2014",
            //    ACCOUNTDAYMON = "20 Jul",
            //    ACCOUNTYEAR = "2014"
            //});
            //liTimeLineData.Add(new TimeLineModel
            //{
            //    DUPLICATECNT = 0,
            //    ACCOUNTNUMBER = "UKLP07154741",
            //    ACCOUNTTYPE = "Allocated Account",
            //    ACCOUNTCOMMENT = "A privileged user is a user who has been allocated powers within the computer system which are significantly greater than those available to the majority of users.",
            //    ACCOUNTDATE = "30/08/2014",
            //    ACCOUNTEXTENDEDDATE = "August 30th, 2014",
            //    ACCOUNTDAYMON = "30 Aug",
            //    ACCOUNTYEAR = "2014"
            //});
            //liTimeLineData.Add(new TimeLineModel
            //{
            //    DUPLICATECNT = 0,
            //    ACCOUNTNUMBER = "1237154741",
            //    ACCOUNTTYPE = "UnAllocated Account",
            //    ACCOUNTCOMMENT = "Payment is still unknown / unidentified, the unknown receipt as posted in the Unallocated Revenue Account will be journalised.",
            //    ACCOUNTDATE = "15/09/2014",
            //    ACCOUNTEXTENDEDDATE = "September 15th, 2014",
            //    ACCOUNTDAYMON = "15 Sep",
            //    ACCOUNTYEAR = "2014"
            //});
            //liTimeLineData.Add(new TimeLineModel
            //{
            //    DUPLICATECNT = 0,
            //    ACCOUNTNUMBER = "DAT87554741",
            //    ACCOUNTTYPE = "Seizure Account",
            //    ACCOUNTCOMMENT = "Seizures of bank accounts and bank assets may be attempted by creditors in instances where the borrower can’t keep up with the monthly debt payments.",
            //    ACCOUNTDATE = "01/11/2014",
            //    ACCOUNTEXTENDEDDATE = "November 01th, 2014",
            //    ACCOUNTDAYMON = "01 Nov",
            //    ACCOUNTYEAR = "2014"
            //});
            //liTimeLineData.Add(new TimeLineModel
            //{
            //    DUPLICATECNT = 0,
            //    ACCOUNTNUMBER = "TMM07154741",
            //    ACCOUNTTYPE = "Seizure Account",
            //    ACCOUNTCOMMENT = "Seizures of bank accounts and bank assets may be attempted by creditors in instances where the borrower can’t keep up with the monthly debt payments.",
            //    ACCOUNTDATE = "10/12/2014",
            //    ACCOUNTEXTENDEDDATE = "December 10th, 2014",
            //    ACCOUNTDAYMON = "10 Dec",
            //    ACCOUNTYEAR = "2014"
            //});
            //liTimeLineData.Add(new TimeLineModel
            //{
            //    DUPLICATECNT = 0,
            //    ACCOUNTNUMBER = "7777154741",
            //    ACCOUNTTYPE = "Allocated Account",
            //    ACCOUNTCOMMENT = "A privileged user is a user who has been allocated powers within the computer system which are significantly greater than those available to the majority of users.",
            //    ACCOUNTDATE = "19/01/2015",
            //    ACCOUNTEXTENDEDDATE = "January 19th, 2015",
            //    ACCOUNTDAYMON = "19 Jan",
            //    ACCOUNTYEAR = "2015"
            //});
            //liTimeLineData.Add(new TimeLineModel
            //{
            //    DUPLICATECNT = 0,
            //    ACCOUNTNUMBER = "DAT87554741",
            //    ACCOUNTTYPE = "UnAllocated Account",
            //    ACCOUNTCOMMENT = "Payment is still unknown / unidentified, the unknown receipt as posted in the Unallocated Revenue Account will be journalised.",
            //    ACCOUNTDATE = "03/03/2015",
            //    ACCOUNTEXTENDEDDATE = "March 03th, 2014",
            //    ACCOUNTDAYMON = "03 Mar",
            //    ACCOUNTYEAR = "2014"
            //});
            //liTimeLineData.Add(new TimeLineModel
            //{
            //    DUPLICATECNT = 0,
            //    ACCOUNTNUMBER = "TESTDAT87554741",
            //    ACCOUNTTYPE = "Allocated Account",
            //    ACCOUNTCOMMENT = "A privileged user is a user who has been allocated powers within the computer system which are significantly greater than those available to the majority of users.",
            //    ACCOUNTDATE = "03/03/2015",
            //    ACCOUNTEXTENDEDDATE = "March 03th, 2014",
            //    ACCOUNTDAYMON = "03 Mar",
            //    ACCOUNTYEAR = "2014"
            //});
            //liTimeLineData.Add(new TimeLineModel
            //{
            //    DUPLICATECNT = 0,
            //    ACCOUNTNUMBER = "NMEE52407154741",
            //    ACCOUNTTYPE = "Seizure Account",
            //    ACCOUNTCOMMENT = "Seizures of bank accounts and bank assets may be attempted by creditors in instances where the borrower can’t keep up with the monthly debt payments.",
            //    ACCOUNTDATE = "20/04/2015",
            //    ACCOUNTEXTENDEDDATE = "April 20th, 2015",
            //    ACCOUNTDAYMON = "20 Apr",
            //    ACCOUNTYEAR = "2015"
            //});
            //liTimeLineData.Add(new TimeLineModel
            //{
            //    DUPLICATECNT = 0,
            //    ACCOUNTNUMBER = "RET77154741",
            //    ACCOUNTTYPE = "Allocated Account",
            //    ACCOUNTCOMMENT = "A privileged user is a user who has been allocated powers within the computer system which are significantly greater than those available to the majority of users.",
            //    ACCOUNTDATE = "19/08/2015",
            //    ACCOUNTEXTENDEDDATE = "August 19th, 2015",
            //    ACCOUNTDAYMON = "19 Aug",
            //    ACCOUNTYEAR = "2015"
            //});
            //liTimeLineData.Add(new TimeLineModel
            //{
            //    DUPLICATECNT = 0,
            //    ACCOUNTNUMBER = "ALL77154741",
            //    ACCOUNTTYPE = "Allocated Account",
            //    ACCOUNTCOMMENT = "A privileged user is a user who has been allocated powers within the computer system which are significantly greater than those available to the majority of users.",
            //    ACCOUNTDATE = "19/12/2015",
            //    ACCOUNTEXTENDEDDATE = "December 19th, 2015",
            //    ACCOUNTDAYMON = "19 Dec",
            //    ACCOUNTYEAR = "2015"
            //});
            //liTimeLineData.Add(new TimeLineModel
            //{
            //    DUPLICATECNT = 0,
            //    ACCOUNTNUMBER = "UNALL87554741",
            //    ACCOUNTTYPE = "UnAllocated Account",
            //    ACCOUNTCOMMENT = "Payment is still unknown / unidentified, the unknown receipt as posted in the Unallocated Revenue Account will be journalised.",
            //    ACCOUNTDATE = "03/01/2016",
            //    ACCOUNTEXTENDEDDATE = "January 03th, 2016",
            //    ACCOUNTDAYMON = "03 Jan",
            //    ACCOUNTYEAR = "2016"
            //});
            //liTimeLineData.Add(new TimeLineModel
            //{
            //    DUPLICATECNT = 0,
            //    ACCOUNTNUMBER = "UNALL8712554741",
            //    ACCOUNTTYPE = "UnAllocated Account",
            //    ACCOUNTCOMMENT = "Payment is still unknown / unidentified, the unknown receipt as posted in the Unallocated Revenue Account will be journalised.",
            //    ACCOUNTDATE = "03/03/2016",
            //    ACCOUNTEXTENDEDDATE = "March 03th, 2016",
            //    ACCOUNTDAYMON = "03 Mar",
            //    ACCOUNTYEAR = "2016"
            //});
            //return liTimeLineData;
            #endregion

            //    DUPLICATECNT = 0,
            //    ACCOUNTTYPE = "Allocated Account",
            //    ACCOUNTCOMMENT = "A privileged user is a user who has been allocated powers within the computer system which are significantly greater than those available to the majority of users.",
            //    ACCOUNTEXTENDEDDATE = "January 16th, 2014",
            //    ACCOUNTDAYMON = "16 Jan",
            //    ACCOUNTYEAR = "2014"

            OracleParameterCollection param = new OracleParameterCollection();
            param.Add(new OracleParameter(Common.POS_MONTHLY_COUNT_FOR_NEW_UI.P_KEY, ""));
            param.Add(new OracleParameter(Common.POS_MONTHLY_COUNT_FOR_NEW_UI.P_USER_ROLE, HttpContext.Current.Session[Common.SESSION_VARIABLES.ROLE_CODE].ToString()));
            param.Add(new OracleParameter(Common.POS_MONTHLY_COUNT_FOR_NEW_UI.P_USER_ID, HttpContext.Current.Session[Common.SESSION_VARIABLES.USER_ID].ToString()));
            param.Add(new OracleParameter(Common.POS_MONTHLY_COUNT_FOR_NEW_UI.P_OUTTBL, OracleType.Cursor));
            param[Common.POS_MONTHLY_COUNT_FOR_NEW_UI.P_OUTTBL].Direction = ParameterDirection.Output;
            OracleParameter[] Oraparam = new OracleParameter[param.Count];
            param.CopyTo(Oraparam, 0);
            param.Clear();
            var liTimeLineData = (List<TimeLineModel>)OracleHelper.FetchData<TimeLineModel>(Oraparam, Common.Queries.POS_MONTHLY_COUNT_FOR_NEW_UI, EnumCommand.DataSource.list).DataSource.Data;

            //List<Console_Control> ListOfInvoiceNumbers = new List<Console_Control>();

            //Parallel.ForEach(liTimeLineData.AsEnumerable(), aaa =>
            //{
            //    liTimeLineData.Add(new TimeLineModel { ACCOUNTYEAR = Convert.ToDateTime(aaa.ACCOUNTDATE.ToString()).Year });
            //});

            return liTimeLineData;

        }
        #endregion
    }
}
