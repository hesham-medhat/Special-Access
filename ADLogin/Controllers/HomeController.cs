using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADLogin.Controllers
{

    [ADLogin.Authorization.AuthorizeUser]
    public class HomeController : Controller
    {

        public ActionResult Welcome()
        {
            return View();
        }
	}
}