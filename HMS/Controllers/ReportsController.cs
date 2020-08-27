using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HMS.DAO;
using HMS.UTILITY;
using System.Web.Security;
using HMS.Model.ViewModel;
using System.Web.Mvc;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using Newtonsoft.Json;
using HMS.Model.Model;
using System.Net.Http;
using System.IO;

namespace HMS.Controllers
{
    public class ReportsController : BaseController
    {
        private ReportsViewModel objViewModel;
        // GET: Reports
        public ReportsController()
        {
            objViewModel = new ReportsViewModel();
        }

        #region Patienthistory
        public ActionResult PatientHistory()
        {
            return View();
        }

        public JsonResult FetchPatienthistory(PatientHistory PatientHistory)
        {
            try
            {
                PatientHistory.P_KEY = "GV";
                PatientHistory.OrgID = Session[Common.SESSION_VARIABLES.COMPANYCODE].ToString();
                PatientHistory.CreatedBy = Session[Common.SESSION_VARIABLES.USERNAME].ToString();
                objViewModel.lipatienthistory = ReportsViewModel.Patienthistory(PatientHistory);
                return Json(objViewModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        #endregion
    }
}