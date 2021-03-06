using TssCodingAssignment.Models;
using TssCodingAssignment.Services.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TssCodingAssignment.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View("Login");
        }

        public ActionResult Login(UserModel userModel)
        {
            SecurityService securityService = new SecurityService();
            Boolean success = securityService.Authenticate(userModel);

            if (success)
            {
                if (userModel.Username == "Admin")
                {
                    Session["user"] = "Admin";
                    return RedirectToAction("Modify", "Product");
                }
            }
            return RedirectToAction("Index", "Home");

        }

        
    }
}