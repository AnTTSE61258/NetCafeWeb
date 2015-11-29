using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetCafeWeb.Controllers
{
    public class RoleController : Controller
    {
        //
        // GET: /Role/
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
        public Boolean editRole()
        {
            return true;
        }
        [HttpPost]
        public Boolean delete()
        {
            return true;
        }
        [HttpPost]
        public Role getRole()
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