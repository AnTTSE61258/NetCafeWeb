using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NetCafeWeb.Models;
using NetCafeWeb.Service;

namespace NetCafeWeb.Controllers
{
    public class MobileController : Controller
    {
        NetCafeEntities1 _userContext;

        // GET: Mobile
        public ActionResult Index()
        {
            return View();
        }
        
        public string checkAccount(string username, string password)
        {
            MobileService service = new MobileService();
            return service.checkUser(username, password);
        }
    }
}