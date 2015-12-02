using NetCafeWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NetCafeWeb.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        public ActionResult Index()
        {
            IRepository<User> repository = new UserRepository();
            IEnumerable<User> users = repository.List;
            ViewBag.users = users.Cast<User>().ToList();

            RoleRepository role_repo = new RoleRepository();
            IEnumerable<Role> roles = role_repo.List;
            ViewBag.roles = roles.Cast<Role>().ToList();

            return View();
        }
        [HttpPost]
        public Boolean Add()
        {
            return true;
        }
        [HttpPost]
        public Boolean editUser()
        {
            String idParam = Request.Params["userID"];
            double balance = Double.Parse(Request.Params["balance"]);
            int role = Int32.Parse(Request.Params["role"]);

            IRepository<User> repository = new UserRepository();
            int id = int.Parse(idParam);
            User user = repository.findById(id);
            user.Balance = balance;
            user.RoleID = role;
            repository.Update(user);
            return true;
        }
        [HttpPost]
        public Boolean delete()
        {
            return true;
        }
        [HttpPost]
        public User getUser()
        {
            return null;
        }
        [HttpPost]
        public ActionResult edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "User");
            }
            else
            {
                IRepository<User> repository = new UserRepository();
                User user = repository.findById(id.Value);
                ViewBag.user = user;
            
                RoleRepository role_repo = new RoleRepository();
                IEnumerable<Role> roles = role_repo.List;
                ViewBag.roles = roles.Cast<Role>().ToList(); ;

            }
            return View();
        }
	}
}