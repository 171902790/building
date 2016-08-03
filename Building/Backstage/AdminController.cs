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
        [HttpGet,Route("admin")]
//        [AuthenticationFilter]
        public ActionResult Index()
        {
            using (var ctx=new DB())
            {
                ViewBag.Modules = ctx.Modules.ToList();
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

        [HttpGet,Route("list/{id=0}")]
        public ActionResult List(int id)
        {
            using (var ctx = new DB())
            {
                if (id == 0)
                {
                    ViewBag.Modules = ctx.Modules.Where(x => x.Superior == null).ToList();
                    ViewBag.IsModuleManagement = true;
                    ViewBag.Title = "模块管理";
                }
                else
                {
                    ViewBag.IsModuleManagement = false;
                    var module = ctx.Modules.SingleOrDefault(x => x.Id == id);
                    ViewBag.Title = module.Name;
                    ViewBag.SubModule = ctx.Modules.Where(x => x.Superior.Id == module.Id).ToList();

                }
            }
            return View("~/backstage/admin_list.cshtml");
        }
    }
}