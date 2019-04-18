using EmptyASP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmptyASP.Controllers
{
    public class SupplierController : Controller
    {
        MyContext myContext = new MyContext();
        // GET: Supplier
        public ActionResult Index()
        {
            var get = myContext.Suppliers.ToList();
            return View(get);
        }

        // GET: Supplier/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Supplier/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Supplier/Create
        [HttpPost]
        public ActionResult Create(Supplier supplier)
        {
            try
            {
                // TODO: Add insert logic here
                myContext.Suppliers.Add(supplier);
                var result = myContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Supplier/Edit/5
        public ActionResult Edit(int Id)
        {
            var get = myContext.Suppliers.Find(Id);
            return View();
        }

        // POST: Supplier/Edit/5
        [HttpPost]
        public ActionResult Edit(int Id, Supplier supplier)
        {
            try
            {
                var get = myContext.Suppliers.Find(Id);
                if (get != null)
                {
                    get.Name = supplier.Name;
                    myContext.Entry(get).State = EntityState.Modified;
                    var result = myContext.SaveChanges();
                    // TODO: Add update logic here
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Supplier/Delete/5
        public ActionResult Delete(int Id)
        {
            var get = myContext.Suppliers.Find(Id);
            return View(get);
        }

        // POST: Supplier/Delete/5
        [HttpPost]
        public ActionResult Delete(int Id, Supplier supplier)
        {
            try
            {
                // TODO: Add delete logic here
                var get = myContext.Suppliers.Find(Id);
                if (get != null)
                {
                    get.IsDelete = true;
                    myContext.Entry(get).State = EntityState.Modified;
                    var result = myContext.SaveChanges();
                }
                    
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
