using EmptyASP.Models;
using EmptyASP.View_Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmptyASP.Controllers
{
    public class ItemController : Controller
    {
        MyContext myContext = new MyContext();

        // GET: Item
        public ActionResult Index()
        {
            var get = myContext.Items.ToList();
            return View(get);
        }

        // GET: Item/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Item/Create
        public ActionResult Create()
        {
            var get = myContext.Suppliers.OrderBy(x => x.Name).Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString(),
                Selected = false
            }).ToArray();  //mapping siapa textnya sm valuenya//
            ViewBag.Suppliers = get;
            return View();
        }

        // POST: Item/Create
        [HttpPost]
        public ActionResult Create( ItemView itemView)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var getSupplier = myContext.Suppliers.Find(itemView.Supplier_Id);
                    Item item = new Item()
                    {
                        Name = itemView.Name,
                        Price = itemView.Price,
                        Stock = itemView.Stock,
                        supplier = getSupplier
                    };
                    myContext.Items.Add(item);
                    myContext.SaveChanges();
                    TempData["message"] = "New Item Data added";
                    return RedirectToAction("Index");
                }  
            }
            catch
            {
                return View();
            }
            return View();
        }

        // GET: Item/Edit/5
        public ActionResult Edit(int Id)
        {
            var getitem = myContext.Items.Find(Id);
            ItemView itemView = new ItemView()
            {
                Name = getitem.Name,
                Price = getitem.Price,
                Stock = getitem.Stock,
                Supplier_Id = getitem.supplier.Id
            };
            //mapping siapa textnya sm valuenya//    
           ViewBag.Suppliers = new SelectList(myContext.Suppliers.Where(X=> X.IsDelete == false).ToList(),"Id","Name","0");
            return View(itemView);
        }

        // POST: Item/Edit/5
        [HttpPost]
        public ActionResult Edit(int Id, ItemView itemView)
        {

                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    var get = myContext.Items.Find(Id);
                    var getSupplier = myContext.Suppliers.Find(itemView.Supplier_Id);
                    get.Name = itemView.Name;
                    get.Price = itemView.Price;
                    get.Stock = itemView.Stock;
                    get.supplier = getSupplier;

                    myContext.Entry(get).State = EntityState.Modified;
                    myContext.SaveChanges();
                TempData["message"] = "New Item Data added";
                return RedirectToAction("Index");
                }
            return View();
          }

        // GET: Item/Delete/5
        public ActionResult Delete(int Id)
        {
            myContext.Items.Find(Id);
            return View();
        }

        // POST: Item/Delete/5
        [HttpPost]
        public ActionResult Delete(int Id, ItemView itemView)
        {
            try
            {
                // TODO: Add delete logic here
                var get = myContext.Items.Find(Id);
                myContext.Entry(get).State = EntityState.Deleted;
                myContext.SaveChanges();
                TempData["message"] = "Item " + Id + " has been updated";
                return RedirectToAction("Index");
            }
             catch
            {
                return View(myContext);
            } 
        }
    }
}
