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

namespace HMS.Controllers
{
    public class MasterController : BaseController
    {

        private MasterViewModel objViewModel;

        public MasterController()
        {
            objViewModel = new MasterViewModel();
        }

        #region PhysicianMaster

        public ActionResult PhysicianMaster()
        {
            return View();
        }

        public JsonResult BindListphysicianMaster()
        {
            try
            {
                PhysicianMaster objModel = new PhysicianMaster();
                Statemaster obj = new Statemaster();
                Citymaster city = new Citymaster();
                Usermst user = new Usermst();
                objModel.P_KEY = "L";
                objModel.ORGID = Session[Common.SESSION_VARIABLES.COMPANYCODE].ToString();
                user.ORGID = Session[Common.SESSION_VARIABLES.COMPANYCODE].ToString();
                objViewModel.liphysicianMaster = MasterViewModel.SavePhysicianMaster(objModel);
                objViewModel.liStateMaster = MasterViewModel.ListState(obj);
                objViewModel.liUserMaster = MasterViewModel.ListUserdetails(user);
                //objViewModel.liCityMaster = Manage_InfoViewModel.ListCity(city);
                return Json(objViewModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        public JsonResult BindCity(PhysicianMaster obj)
        {
            objViewModel.liCityMaster = MasterViewModel.ListCity(obj);
            return Json(objViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Savephysicianmaster(PhysicianMaster PhysicianMaster)
        {
            try
            {
                PhysicianMaster.P_KEY = "S";
                PhysicianMaster.INSERTBY = Session[Common.SESSION_VARIABLES.USERNAME].ToString();
                //PhysicianMaster.ORGID = "1";
                PhysicianMaster.ORGID = Session[Common.SESSION_VARIABLES.COMPANYCODE].ToString();
                PhysicianMaster.ISACTIVE = (PhysicianMaster.ISACTIVE == Common.ActiveLog.Active) ? "Y" : "N";
                objViewModel.liphysicianMaster = MasterViewModel.SavePhysicianMaster(PhysicianMaster);
                return Json(objViewModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
        #endregion

        #region Drugmaster
        public ActionResult DrugMaster()
        {
            return View();
        }

        public JsonResult BindListdrugmaster()
        {
            try
            {
                Drugmaster objModel = new Drugmaster();
                objModel.P_KEY = "L";
                objModel.OrgID = Session[Common.SESSION_VARIABLES.COMPANYCODE].ToString();
                objViewModel.liDrugMaster = MasterViewModel.SaveDrugMaster(objModel);
                //objViewModel.liCityMaster = Manage_InfoViewModel.ListCity(city);
                return Json(objViewModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        public JsonResult Savedrugmaster(Drugmaster Drugmaster)
        {
            try
            {
                Drugmaster.P_KEY = "S";
                Drugmaster.CreatedBy = Session[Common.SESSION_VARIABLES.USERNAME].ToString();
                //PhysicianMaster.ORGID = "1";
                Drugmaster.OrgID = Session[Common.SESSION_VARIABLES.COMPANYCODE].ToString();
                Drugmaster.ISACTIVE = (Drugmaster.ISACTIVE == Common.ActiveLog.Active) ? "Y" : "N";
                objViewModel.liDrugMaster = MasterViewModel.SaveDrugMaster(Drugmaster);
                return Json(objViewModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
        #endregion

        #region InvestigationMatser
        public ActionResult InvestigationMaster()
        {
            return View();
        }

        public JsonResult BindListinvestigationmaster()
        {
            try
            {
                Investigationmaster objModel = new Investigationmaster();
                objModel.P_KEY = "L";
                objModel.Orgid= Session[Common.SESSION_VARIABLES.COMPANYCODE].ToString();
                objViewModel.liInvestigationMaster = MasterViewModel.SaveInvestigationMaster(objModel);
                return Json(objViewModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        public JsonResult SaveInvestigationmaster(Investigationmaster Investigationmaster)
        {
            try
            {
                Investigationmaster.P_KEY = "S";
                Investigationmaster.CreatedBy = Session[Common.SESSION_VARIABLES.USERNAME].ToString();
                Investigationmaster.ModifyBy = Session[Common.SESSION_VARIABLES.USERNAME].ToString();
                //PhysicianMaster.ORGID = "1";
                Investigationmaster.Orgid = Session[Common.SESSION_VARIABLES.COMPANYCODE].ToString();
                Investigationmaster.ISACTIVE = (Investigationmaster.ISACTIVE == Common.ActiveLog.Active) ? "Y" : "N";
                objViewModel.liInvestigationMaster = MasterViewModel.SaveInvestigationMaster(Investigationmaster);
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