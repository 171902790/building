using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Building.Controllers
{
    public class TupianController : Controller
    {
        // GET: Tupian
        public ActionResult tupian()
        {
            return View();
        }

        // GET: Tupian/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Tupian/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tupian/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tupian/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Tupian/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tupian/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Tupian/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
