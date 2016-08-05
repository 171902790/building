using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using Building.Backstage;
using Building.Models;

namespace Building.Admin
{
    public class AdminController : Controller
    {
        [HttpGet, Route("admin")]
        //        [AuthenticationFilter]
        public ActionResult Index()
        {
            using (var ctx = new DB())
            {
                ViewBag.Modules = ctx.Modules.ToList();
            }
            return View("~/backstage/admin_index.cshtml");
        }

        [HttpGet, Route("login")]
        public ActionResult Login()

        {
            return View("~/backstage/admin_login.cshtml");
        }

        [HttpPost, Route("login")]
        public ActionResult Logon(string username, string password, string rememberMe)
        {
            if (username == "zws" && password == "123")
            {
                FormsAuthentication.SetAuthCookie(username, rememberMe != null);
                return new HttpStatusCodeResult(200);

            }
            return new HttpStatusCodeResult(500);
        }

        [HttpGet, Route("list/{id=0}")]
        public ActionResult List(int id)
        {
            var vm = new AdminListViewModel();
            using (var ctx = new DB())
            {
                if (id == 0)
                {
                    vm.IsModuleManagement = true;
                    vm.Title = "模块管理";
                    vm.Modules =
                        ctx.Modules.Where(x => x.Superior == null).ToList().Select(
                            x => new AdminListViewModel.Item() { Id = x.Id, Name = x.Name, Category = "模块", Creator = x.Creator.Name, Time = x.CreateTime, Belong = "-" }
                            ).ToList();
                }
                else
                {
                    vm.IsModuleManagement = false;
                    var module = ctx.Modules.SingleOrDefault(x => x.Id == id);
                    vm.Title = module.Name;
                    vm.Modules = ctx.Modules.Where(x => x.Superior.Id == id).Select(
                            x => new AdminListViewModel.Item() { Id = x.Id, Name = x.Name, Category = "子模块", Creator = x.Creator.Name, Time = x.CreateTime, Belong = module.Name }).ToList();
                    vm.Articles = ctx.Articles.Where(x => x.Belong.Id == id).Select(
                            x => new AdminListViewModel.Item() { Id = x.Id, Name = x.Name, Category = "文章", Creator = x.Author.Name, Time = x.CreateTime, Belong = module.Name }).ToList();
                    vm.Ads = ctx.Ads.Where(x => x.Belong.Id == id).Select(
                            x => new AdminListViewModel.Item() { Id = x.Id, Name = x.Name, Category = "广告", Creator = x.Creator.Name, Time = x.CreateTime, Belong = module.Name }).ToList();
                }
            }
            return View("~/backstage/admin_list.cshtml",vm);
        }

        [HttpGet, Route("module/{id?}")]
        public ActionResult AddOrUpdateModulePage(int? id)
        {
            return View("~/backstage/add_or_update_module.cshtml");
        }

        [HttpPost, Route("module")]
        public ActionResult AddOrUpdateModule(ModuleViewModel vm)
        {
            if (ModelState.IsValid)
            {
                return new HttpStatusCodeResult(200);
            }
            return new HttpStatusCodeResult(500);
        }
    }

    public class AdminListViewModel
    {
        public List<Item> Modules { get; set; }
        public List<Item> Articles { get; set; }
        public List<Item> Ads { get; set; }
        public string Title { get; set; }
        public bool IsModuleManagement { get; set; }

        public class Item
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Category { get; set; }
            public string Creator { get; set; }
            public DateTime Time { get; set; }
            public string Belong { get; set; }
        }
    }
}