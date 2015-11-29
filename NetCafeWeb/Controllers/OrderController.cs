using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetCafeWeb.Controllers
{
    public class OrderController : Controller
    {
        //
        // GET: /Order/
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public Boolean Add()
        {
            return true;
        }
        [HttpPost]
        public Boolean editOrder()
        {
            return true;
        }
        [HttpPost]
        public Boolean delete()
        {
            return true;
        }
        [HttpPost]
        public Order getOrder()
        {
            return null;
        }
        [HttpPost]
        public ActionResult edit(int? id)
        {
            return View();
        }
	}
}