using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NetCafeWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using NetCafeWeb.CustomFilters;
using NetCafeWeb.Service;

namespace NetCafeWeb.Controllers
{
    [AuthLog(Roles ="Admin")]
    public class UserController : Controller
    {
        //
        // GET: /User/
        public ActionResult Index()
        {
            UserService services = new UserService();
            //list users
            //IRepository<User> repository = new UserRepository();
            //IEnumerable<User> users = repository.List;
            List<User> users = services.getUsers();
            ViewBag.users = users;

            //list role
            //RoleRepository role_repo = new RoleRepository();
            //IEnumerable<Role> roles = role_repo.List;
            List<Role> roles = services.getRoles();
            ViewBag.roles = roles;

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
            //get data from request
            int selectedUserID = Int32.Parse(Request.Params["userID"]);
            double newBalance = Double.Parse(Request.Params["balance"]);
            int newRoleID = Int32.Parse(Request.Params["role"]);
            string selectedRoleName = Request.Params["roleName"];


            UserService services = new UserService();

            User selectedUser = services.findAnUser(selectedUserID);
            selectedUser.Balance = newBalance;
            selectedUser.RoleID = newRoleID;

            return services.updateUser(selectedUser);

            /*
            //get the old info of the account
            IRepository<User> repository = new UserRepository();
            int n_selectedUserID = int.Parse(selectedUserID);
            User selectedUser = repository.findById(n_selectedUserID);
            int oldRoleID = selectedUser.RoleID;
            string selectedUserName = selectedUser.UserName;

            IRepository<Role> role_repo = new RoleRepository();
            Role roleInfo = new Role();
            //get old roleName
            roleInfo = role_repo.findById(oldRoleID);
            string oldRoleName = roleInfo.RoleName;
            //get new roleName
            roleInfo = role_repo.findById(newRoleID);
            string newRoleName = roleInfo.RoleName;

            //update user in User table
            selectedUser.Balance = newBalance;
            selectedUser.RoleID = newRoleID;
            repository.Update(selectedUser);

            var context = new NetCafeWeb.Models.ApplicationDbContext();
            var UserManager = new UserManager<NetCafeWeb.Models.ApplicationUser>(new UserStore<NetCafeWeb.Models.ApplicationUser>(context));
            //var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            //var result = RoleManager.

            //var store = new Microsoft.AspNet.Identity.EntityFramework.UserStore<NetCafeWeb.Models.ApplicationUser>(new NetCafeWeb.Models.ApplicationDbContext());
            //var manager = new Microsoft.AspNet.Identity.UserManager<NetCafeWeb.Models.ApplicationUser>(store);

            //update the user in asp user
            //var context = new NetCafeWeb.Models.ApplicationDbContext();
            //var account = new AccountController();
            //delete old role for the current user
            ApplicationUser aspSelectedUser = context.Users.Where(u => u.UserName.Equals((selectedUserName), StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            //ApplicationUser aspSelectedUser = UserManager.Users.FirstOrDefault(u => u.UserName == selectedUserName);

            //account.UserManager.RemoveFromRoleAsync(aspSelectedUser.Id, oldRoleName);
            UserManager.RemoveFromRole(aspSelectedUser.Id, oldRoleName);

            //add new role for the current user
            //account.UserManager.AddToRoleAsync(aspSelectedUser.Id, newRoleName);
            UserManager.AddToRole(aspSelectedUser.Id, newRoleName);

            return true;
            */
        }
        [HttpPost]
        public Boolean delete()
        {
            //delete from user table
            String deleteUserID = Request.Params["id"];
            int id = int.Parse(deleteUserID);
            IRepository<User> repository = new UserRepository();
            User deletedUser = repository.findById(id);
            if (deletedUser == null)
            {
                return false;
            }
            repository.Delete(deletedUser);

            //delete from asp.netUser table
            var context = new NetCafeWeb.Models.ApplicationDbContext();
            var UserManager = new UserManager<NetCafeWeb.Models.ApplicationUser>(new UserStore<NetCafeWeb.Models.ApplicationUser>(context));
            ApplicationUser aspSelectedUser = context.Users.Where(u => u.UserName.Equals((deletedUser.UserName), StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            UserManager.DeleteAsync(aspSelectedUser);

            return true;
        }
        [HttpPost]
        public User getUser()
        {
            return null;
        }
        
        public ActionResult edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "User");
            }
            else
            {
                IUserService services = new UserService();
                User user = services.findAnUser(id.Value);
                ViewBag.user = user;
                //IRepository<User> repository = new UserRepository();
                //User user = repository.findById(id.Value);
                //ViewBag.user = user;

                List<Role> roles = services.getRoles();
                //RoleRepository role_repo = new RoleRepository();
                //IEnumerable<Role> roles = role_repo.List;
                ViewBag.roles = roles;

            }
            return View();
        }
	}
}