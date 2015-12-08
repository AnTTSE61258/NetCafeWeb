using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NetCafeWeb.CustomFilters;

namespace NetCafeWeb.Controllers
{
    //[AuthLog(Roles = "Member,Admin,Supervisor")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            /* For testing
            IRepository<NetCafe> a = new NetCafeRepository();
            NetCafe netcafe = a.findById(5);
            a.Delete(netcafe);
            System.Diagnostics.Debug.WriteLine("asd");
            */
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}