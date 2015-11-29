using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetCafeWeb.Controllers
{
    public class PCController : Controller
    {
        //
        // GET: /PC/
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
        public Boolean editPC()
        {
            return true;
        }
        [HttpPost]
        public Boolean delete()
        {
            return true;
        }
        [HttpPost]
        public PC getPC()
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