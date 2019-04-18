using EmptyASP.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SweetAlert.Controllers;

namespace SweetAlert.Controllers
{
    public class SweetController : Controller
    {
        // GET: Sweet
        public ActionResult Alert()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create ()
        {
            return View (new ItemView());
        }

        [HttpPost]
        public ActionResult Create (ItemView itemView)
        {
            if ( ModelState.IsValid)
            {

            } else
            {

            }
            return View(itemView);
        }
    }
}