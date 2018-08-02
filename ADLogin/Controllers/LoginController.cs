using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADLogin.Controllers
{
    public class LoginController : Controller
    {
        // Validator class used for validating candidate user credentials.
        private ADLogin.Models.Validation.IUserValidator validator;

        // GET: /Login/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AuthorizeByUP(ADLogin.Models.user userModel)
        {
            validator = new ADLogin.Models.Validation.UPValidator(ref userModel);
            if (validator.Validate())
            {
                Session["username"] = userModel.username;
                return RedirectToAction("Welcome", "Home");
            }
            else
                return RedirectToAction("Index", "Login");
        }

	}
}