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
using System.Net.Mail;

namespace HMS.Controllers
{
    public class TaskController : BaseController
    {
        private TaskViewModel objViewModel;

        public TaskController()
        {
            objViewModel = new TaskViewModel();
        }

        #region Patient

        public ActionResult Patientreg()
        {
            return View();
        }

        public JsonResult BindListpatientreg()
        {
            try
            {
                Patientreg objModel = new Patientreg();
                Statemaster obj = new Statemaster();
                Citymaster city = new Citymaster();
                objModel.P_KEY = "L";
                objModel.Org_id = Session[Common.SESSION_VARIABLES.COMPANYCODE].ToString();
                objViewModel.liPatientreg = TaskViewModel.SavePatientdetails(objModel);
                objViewModel.liStateMaster = TaskViewModel.ListState(obj);
                //objViewModel.liCityMaster = Manage_InfoViewModel.ListCity(city);
                return Json(objViewModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        public JsonResult BindCity(Patientreg obj)
        {
            objViewModel.liCityMaster = TaskViewModel.ListCity(obj);
            return Json(objViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Savepatientreg(Patientreg Patientreg)
        {
            try
            {
                Patientreg.P_KEY = "S";
                Patientreg.Insertby = Session[Common.SESSION_VARIABLES.USERNAME].ToString();
                //PhysicianMaster.ORGID = "1";
                Patientreg.Org_id = Session[Common.SESSION_VARIABLES.COMPANYCODE].ToString();
                Patientreg.ISACTIVE = (Patientreg.ISACTIVE == Common.ActiveLog.Active) ? "Y" : "N";
                objViewModel.liPatientreg = TaskViewModel.SavePatientdetails(Patientreg);
                return Json(objViewModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
        #endregion

        #region Consultation

        public ActionResult Consultation()
        {
            return View();
        }

        public JsonResult BindListconsultation()
        {
            try
            {
                Patientreg objModel = new Patientreg();
                objModel.P_KEY = "L";
                objModel.Org_id = Session[Common.SESSION_VARIABLES.COMPANYCODE].ToString();
                objViewModel.liPatientreg = TaskViewModel.SavePatientdetails(objModel);
                //objViewModel.liCityMaster = Manage_InfoViewModel.ListCity(city);
                return Json(objViewModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        //public JsonResult BindListDiagnosisdetail()
        //{
        //    try
        //    {
        //        Diagnosisdetail objModel = new Diagnosisdetail();
        //        objModel.P_KEY = "L";
        //        objModel.Orgid = Session[Common.SESSION_VARIABLES.COMPANYCODE].ToString();
        //        objViewModel.liDiagnosisdetail = TaskViewModel.SaveDiagnosisdetails(objModel);
        //        //objViewModel.liCityMaster = Manage_InfoViewModel.ListCity(city);
        //        return Json(objViewModel, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(ex);
        //    }
        //}

        public JsonResult BindListDiagnosisdetail(Diagnosisdetail Diagnosisdetail)
        {
            try
            {
                Diagnosisdetail.P_KEY = "L";
                // Diagnosisdetail.CreatedBy = Session[Common.SESSION_VARIABLES.USERNAME].ToString();
                //PhysicianMaster.ORGID = "1";
                Diagnosisdetail.Orgid = Session[Common.SESSION_VARIABLES.COMPANYCODE].ToString();
                objViewModel.liDiagnosisdetail = TaskViewModel.SaveDiagnosisdetails(Diagnosisdetail);
                return Json(objViewModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        public JsonResult SaveDiagnosismaster(Diagnosisdetail Diagnosisdetail)
        {
            try
            {
                Diagnosisdetail.P_KEY = "S";
                Diagnosisdetail.CreatedBy = Session[Common.SESSION_VARIABLES.USERNAME].ToString();
                //PhysicianMaster.ORGID = "1";
                Diagnosisdetail.Orgid = Session[Common.SESSION_VARIABLES.COMPANYCODE].ToString();
                objViewModel.liDiagnosisdetail = TaskViewModel.SaveDiagnosisdetails(Diagnosisdetail);
                return Json(objViewModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        public JsonResult DeleteDiagnosisMaster(Diagnosisdetail Diagnosisdetail)
        {
            try
            {

                //CategoryMaster objModel = new CategoryMaster();
                Diagnosisdetail.P_KEY = "D";
                Diagnosisdetail.Orgid = Session[Common.SESSION_VARIABLES.COMPANYCODE].ToString();
                objViewModel.liDiagnosisdetail = TaskViewModel.SaveDiagnosisdetails(Diagnosisdetail);
                return Json(objViewModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        //public JsonResult BindListDrugdetail()
        //{
        //    try
        //    {
        //        Drugdetails objModel = new Drugdetails();
        //        Dosemst obj = new Dosemst();
        //        Drugmst objdrug = new Drugmst();
        //        objModel.P_KEY = "L";
        //        objModel.OrgID = Session[Common.SESSION_VARIABLES.COMPANYCODE].ToString();
        //        objViewModel.liDrugdetails = TaskViewModel.SaveDrugdetails(objModel);
        //        objViewModel.lidosemst = TaskViewModel.ListDosedetails(obj);
        //        objViewModel.lidrugmst = TaskViewModel.ListDrugdetails(objdrug);
        //        return Json(objViewModel, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(ex);
        //    }
        //}

        public JsonResult BindListDrugdetail(Drugdetails Drugdetails)
        {
            try
            {
                Dosemst obj = new Dosemst();
                Drugmst objdrug = new Drugmst();
                Drugdetails.P_KEY = "L";
                Drugdetails.OrgID = Session[Common.SESSION_VARIABLES.COMPANYCODE].ToString();
                objViewModel.liDrugdetails = TaskViewModel.SaveDrugdetails(Drugdetails);
                objdrug.OrgID = Session[Common.SESSION_VARIABLES.COMPANYCODE].ToString();
                objViewModel.lidosemst = TaskViewModel.ListDosedetails(obj);
                objViewModel.lidrugmst = TaskViewModel.ListDrugdetails(objdrug);
                return Json(objViewModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        public JsonResult SavePrecriptionmaster(Drugdetails Drugdetails)
        {
            try
            {
                Drugdetails.P_KEY = "S";
                Drugdetails.CreatedBy = Session[Common.SESSION_VARIABLES.USERNAME].ToString();
                //PhysicianMaster.ORGID = "1";
                Drugdetails.OrgID = Session[Common.SESSION_VARIABLES.COMPANYCODE].ToString();
                objViewModel.liDrugdetails = TaskViewModel.SaveDrugdetails(Drugdetails);
                return Json(objViewModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        public JsonResult DeletePrecriptionMaster(Drugdetails Drugdetails)
        {
            try
            {

                //CategoryMaster objModel = new CategoryMaster();
                Drugdetails.P_KEY = "D";
                Drugdetails.OrgID = Session[Common.SESSION_VARIABLES.COMPANYCODE].ToString();
                objViewModel.liDrugdetails = TaskViewModel.SaveDrugdetails(Drugdetails);
                return Json(objViewModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        //public JsonResult BindListTestdetail()
        //{
        //    try
        //    {
        //        Testmst obj = new Testmst();
        //        Testdetails objModel = new Testdetails();
        //        objModel.P_KEY = "L";
        //        objModel.orgid = Session[Common.SESSION_VARIABLES.COMPANYCODE].ToString();
        //        objViewModel.liTestdetails = TaskViewModel.SaveTestdetails(objModel);
        //        objViewModel.litestmst = TaskViewModel.ListTestdetails(obj);
        //        return Json(objViewModel, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(ex);
        //    }
        //}

        public JsonResult BindListTestdetail(Testdetails Testdetails)
        {
            try
            {
                Testmst obj = new Testmst();
                Testdetails.P_KEY = "L";
                Testdetails.orgid = Session[Common.SESSION_VARIABLES.COMPANYCODE].ToString();
                objViewModel.liTestdetails = TaskViewModel.SaveTestdetails(Testdetails);
                objViewModel.litestmst = TaskViewModel.ListTestdetails(obj);
                return Json(objViewModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        public JsonResult SaveTestmaster(Testdetails Testdetails)
        {
            try
            {

                Testdetails.P_KEY = "S";
                Testdetails.CreatedBy = Session[Common.SESSION_VARIABLES.USERNAME].ToString();
                //PhysicianMaster.ORGID = "1";
                Testdetails.orgid = Session[Common.SESSION_VARIABLES.COMPANYCODE].ToString();
                objViewModel.liTestdetails = TaskViewModel.SaveTestdetails(Testdetails);

                return Json(objViewModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }


        [HttpPost]
        public virtual string AttachFile(object obj)
        {

            var length = Request.ContentLength;
            var bytes = new byte[length];
            Request.InputStream.Read(bytes, 0, length);

            var fileName = Request.Headers["X-File-Name"];
            var fileSize = Request.Headers["X-File-Size"];
            var fileType = Request.Headers["X-File-Type"];
            var uploadurl = Request.Headers["X-File-UploadURL"];

            if (!Directory.Exists(uploadurl))
                Directory.CreateDirectory(uploadurl);

            var saveToFileLoc = uploadurl + fileName;
            var fileStream = new FileStream(saveToFileLoc, FileMode.Create, FileAccess.ReadWrite);
            fileStream.Write(bytes, 0, length);
            fileStream.Close();

            return string.Format("{0} bytes uploaded", bytes.Length);
        }

        public virtual ActionResult Download(string fileName, string downloadurl)
        {


            byte[] data = System.IO.File.ReadAllBytes(downloadurl + fileName);
            TempData["Data"] = data;
            // new JsonResult() { Data = new { FileName = fileName.Split('/')[fileName.Split('/').Length - 1] } };

            if (TempData["Data"] != null)
            {
                ///byte[] data = TempData["Data"] as byte[];
                return File(data, "application/octet-stream", fileName);
            }
            else
            {
                return new EmptyResult();
            }
        }

        public JsonResult DeleteTestMaster(Testdetails Testdetails)
        {
            try
            {

                //CategoryMaster objModel = new CategoryMaster();
                Testdetails.P_KEY = "D";
                Testdetails.orgid = Session[Common.SESSION_VARIABLES.COMPANYCODE].ToString();
                objViewModel.liTestdetails = TaskViewModel.SaveTestdetails(Testdetails);
                return Json(objViewModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }


        public JsonResult SaveVitalsmaster(VitalsDetails VitalsDetails)
        {
            try
            {
                VitalsDetails.P_KEY = "S";
                VitalsDetails.CreatedBy = Session[Common.SESSION_VARIABLES.USERNAME].ToString();
                VitalsDetails.Orgid = Session[Common.SESSION_VARIABLES.COMPANYCODE].ToString();
                objViewModel.liVitals = TaskViewModel.SaveVitalsdetails(VitalsDetails);
                return Json(objViewModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        public JsonResult SavePrescript(VitalsDetails VitalsDetails)
        {
            try
            {
                VitalsDetails.P_KEY = "F";
                VitalsDetails.CreatedBy = Session[Common.SESSION_VARIABLES.USERNAME].ToString();
                VitalsDetails.Orgid = Session[Common.SESSION_VARIABLES.COMPANYCODE].ToString();
                objViewModel.liVitals = TaskViewModel.SaveVitalsdetails(VitalsDetails);
                return Json(objViewModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        //public JsonResult BindListVitalsdetail()
        //{
        //    try
        //    {
        //        VitalsDetails objModel = new VitalsDetails();
        //        objModel.P_KEY = "L";
        //        objModel.Orgid = Session[Common.SESSION_VARIABLES.COMPANYCODE].ToString();

        //        objViewModel.liVitals = TaskViewModel.SaveVitalsdetails(objModel);
        //        return Json(objViewModel, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(ex);
        //    }
        //}

        public JsonResult BindListVitalsdetail(VitalsDetails VitalsDetails)
        {
            try
            {
                VitalsDetails.P_KEY = "L";
                VitalsDetails.Orgid = Session[Common.SESSION_VARIABLES.COMPANYCODE].ToString();

                objViewModel.liVitals = TaskViewModel.SaveVitalsdetails(VitalsDetails);
                return Json(objViewModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }




        public JsonResult sendmail(PrintDetails PrintDetails)
        {
            try
            {
                string objMsg = string.Empty;
                PrintDetails.P_KEY = "V";
                PrintDetails.OrgID = Session[Common.SESSION_VARIABLES.COMPANYCODE].ToString();
                PrintDetails.CreatedBy = Session[Common.SESSION_VARIABLES.USERNAME].ToString();
                objViewModel.liprintdetails = TaskViewModel.Printdetails(PrintDetails);
                string objTotal = "<tr style='background-color:#FFA500;' ><td>" + objViewModel.liprintdetails[0].DOCTORNAME + "</td></tr>" ;

                objMsg = "<!DOCTYPE><html><head><style type='text/css'> table ,th,td {border: 1px solid black;border-collapse: collapse;font-family: Calibri;font-size: 12px;} th, td {padding: 3px;}";
                objMsg = objMsg + "</style></head> <body style='font-family:Calibri;font-size:13px;'> Dear All,\r\n\r\n <br/> <br/> ";
                objMsg = objMsg + "<p style='font-family:Calibri;font-size:13px;'>Precription Details </p>";
                objMsg = objMsg + "<p style='font-family:Calibri; font-size: 13px;font-weight:bold;'><br/> "+ objViewModel.liprintdetails[0].OrgDisplayAddress+ "( <a href=> Internal </a> / <a href='" + "> External </a> )</p>";
                objMsg = objMsg + "<table align='center' border='1'  style='border: 1px solid black;border-collapse: collapse;font-family: Calibri;font-size: 12px;width: 70%;'>" +

                "<colgroup span='3'></colgroup>" +
                "<colgroup span='3'></colgroup>" +
                "<tr border='1' style='background-color: #99ccff;'>" +
                "<th colspan='11'>TVSCS - Branch wise pending RC ageing details as on ( Business done 1st May 10 to )</th>" +
                "</tr>" +
                "<tr  style='background-color: #99ccff; font-size:11px;'>" +
                "<th bgcolor='#99ccff'>Region Name</th>" +
                "<th bgcolor='#99ccff'>Area Name</th>" +
                 "<th bgcolor='#99ccff'>Branch Name</th>" +
                //"<th bgcolor='#99ccff'>Area Code</th>" +
                //"<th bgcolor='#99ccff'>Region Name</th>" +
                "<th bgcolor='#99ccff'>Business done (01-May-10 to )</th>" +
                //"<th bgcolor='#99ccff'>Contract Closed</th>" +
                // "<th bgcolor='#99ccff'>RC Recd</th>" +
                "<th bgcolor='#99ccff'>RC Not Recd</th>" +
                "<th bgcolor='#99ccff'>< 30 days</th>" +
                "<th bgcolor='#99ccff'>> 30 days</th>" +
                "<th bgcolor='#99ccff'>> 45 days</th>" +
                "<th bgcolor='#99ccff'>> 60 days</th>" +
                "<th bgcolor='#99ccff'>> 90 days</th>" +
                "<th bgcolor='#99ccff'>GRAND TOTAL</th>" +


                "</tr>" +
                objTotal + 
               "</table>";

                objMsg = objMsg + "<br/>\r\n\r\n Thanking You. <br/>\r\n Please do not reply to this mail-id, It is an automated mail." +
               "<br/>" + " ___________________________________________________________________________________ " +
               "<br/> " + "</body></html>\r\n\r\n";
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("info@everlastinginfotech.com");
                msg.To.Add("madasamy.kcet@gmail.com");
                //msg.To.Add(objViewModel.liprintdetails[0].email_address);
                msg.Subject = "This is test email from madasamynagarajan";
                msg.Body = objMsg;
                msg.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("smtpout.secureserver.net", 587);
                smtp.Credentials = new System.Net.NetworkCredential("info@everlastinginfotech.com", "magath@1911");
                smtp.EnableSsl = false;
                smtp.Send(msg);
                msg.Dispose();
                return Json(objViewModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }



        public JsonResult Printdetail(PrintDetails PrintDetails)
        {
            try
            {
                PrintDetails.P_KEY = "V";
                PrintDetails.OrgID = Session[Common.SESSION_VARIABLES.COMPANYCODE].ToString();
                PrintDetails.CreatedBy = Session[Common.SESSION_VARIABLES.USERNAME].ToString();
                objViewModel.liprintdetails = TaskViewModel.Printdetails(PrintDetails);
                return Json(objViewModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        public JsonResult Printdetaildrug(PrintDetails PrintDetails)
        {
            try
            {
                PrintDetails.P_KEY = "D";
                PrintDetails.OrgID = Session[Common.SESSION_VARIABLES.COMPANYCODE].ToString();
                PrintDetails.CreatedBy = Session[Common.SESSION_VARIABLES.USERNAME].ToString();
                objViewModel.liprintdetails = TaskViewModel.Printdetails(PrintDetails);
                return Json(objViewModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }


        public JsonResult DeleteVitalsMaster(VitalsDetails VitalsDetails)
        {
            try
            {

                //CategoryMaster objModel = new CategoryMaster();
                VitalsDetails.P_KEY = "D";
                VitalsDetails.Orgid = Session[Common.SESSION_VARIABLES.COMPANYCODE].ToString();
                objViewModel.liVitals = TaskViewModel.SaveVitalsdetails(VitalsDetails);
                return Json(objViewModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }



        #endregion

        #region Cardiology

        public ActionResult Cardiology()
        {
            return View();
        }

        public JsonResult Savecardiology(CardiologyDetails CardiologyDetails)
        {
            try
            {
                CardiologyDetails.P_KEY = "S";
                CardiologyDetails.CreatedBy = Session[Common.SESSION_VARIABLES.USERNAME].ToString();
                CardiologyDetails.Orgid = Session[Common.SESSION_VARIABLES.COMPANYCODE].ToString();
                objViewModel.liCardiologyDetails = TaskViewModel.SaveCardiologydetails(CardiologyDetails);
                return Json(objViewModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }


        public JsonResult BindListCardiology(CardiologyDetails CardiologyDetails)
        {
            try
            {
                CardiologyDetails.P_KEY = "L";
                CardiologyDetails.Orgid = Session[Common.SESSION_VARIABLES.COMPANYCODE].ToString();

                objViewModel.liCardiologyDetails = TaskViewModel.SaveCardiologydetails(CardiologyDetails);
                return Json(objViewModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
        public JsonResult DeleteCardiology(CardiologyDetails CardiologyDetails)
        {
            try
            {

                //CategoryMaster objModel = new CategoryMaster();
                CardiologyDetails.P_KEY = "D";
                CardiologyDetails.Orgid = Session[Common.SESSION_VARIABLES.COMPANYCODE].ToString();
                objViewModel.liCardiologyDetails = TaskViewModel.SaveCardiologydetails(CardiologyDetails);
                return Json(objViewModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        public JsonResult PrintCordiology(CardiologyDetails CardiologyDetails)
        {
            try
            {
                CardiologyDetails.P_KEY = "P";
                CardiologyDetails.Orgid = Session[Common.SESSION_VARIABLES.COMPANYCODE].ToString();
                CardiologyDetails.CreatedBy = Session[Common.SESSION_VARIABLES.USERNAME].ToString();
                objViewModel.liCardiologyDetails = TaskViewModel.SaveCardiologydetails(CardiologyDetails);
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