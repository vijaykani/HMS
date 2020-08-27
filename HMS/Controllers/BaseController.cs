using System;
using HMS.UTILITY;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using HMS.Model.Model;
using HMS.Model.ViewModel;
namespace HMS.Controllers
{
    public class BaseController : Controller
    {
        string UserId = AccountController.UserId;
        string UserName = AccountController.UserName;
        string Companycode = AccountController.Companycode;
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (Session.Count > 0 && Session[Common.SESSION_VARIABLES.USERNAME] != null && Session[Common.SESSION_VARIABLES.COMPANYCODE] != null)
            {

            }
            else
            {
                UpdateLastLogin();
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Error",
                    action = "ErrorMessage",
                    id = "Session has been Expired"
                }));

            }
            base.OnActionExecuting(filterContext);
        }
        public void UpdateLastLogin()
        {
            User objUser = new User();
            objUser.USER_ID = AccountController.UserId;
            var UpdateLastLogin = AccountViewModel.UpdateLastLogin(objUser);
        }

        public JsonResult ReturnJsonData<T>(T obj)
        {
            var data = Json(obj, JsonRequestBehavior.AllowGet);
            data.MaxJsonLength = int.MaxValue;
            return data;
        }


    }
}
