using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Building.Models;

namespace Building.Admin
{
    public class AdminController : Controller
    {
        [Route("admin")]
        [AuthenticationFilter]
        public ActionResult Index()
        {
            using (var ctx=new DB())
            {
                var list=ctx.Modules.ToList();
            }
            return View("~/backstage/admin_index.cshtml");
        }

        [HttpGet,Route("login")]
        public ActionResult Login()

        {
            return View("~/backstage/admin_login.cshtml");
        }

        [HttpPost, Route("login")]
        public ActionResult Logon(string username, string password, string rememberMe)
        {
            if (username == "zws" && password == "123")
            {
                FormsAuthentication.SetAuthCookie(username, rememberMe!=null);
                return new HttpStatusCodeResult(200);

            }
            return new HttpStatusCodeResult(500);
        }
    }
}