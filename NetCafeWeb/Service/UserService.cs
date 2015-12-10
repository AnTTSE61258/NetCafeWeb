using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NetCafeWeb.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace NetCafeWeb.Service
{
    public class UserService : IUserService
    {

        private static RoleRepository role_repo = new RoleRepository();
        IEnumerable<Role> roles = role_repo.List;

        public bool checkIsManage(int id)
        {
            User user = findAnUser(id);
            if(user.RoleID == 2)
            {
                NetCafeService net_services = new NetCafeService();
                List<NetCafe> netcafes = net_services.getAllNetCafe();
                foreach(NetCafe net in netcafes)
                {
                    if (net.SupervisorID == user.UserID)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool addUser(User user)
        {
            if (user != null)
            {
                UserRepository repository = new UserRepository();
                repository.Add(user);
                return true;
            }
            return false;
        }

        public bool checkExistedUsername(string username)
        {
            UserRepository repository = new UserRepository();
            if (repository.findExistedName(username))
            {
                return true;
            }
            return false;
        }

        public User findAnUser(int id)
        {
            IRepository<User> repository = new UserRepository();
            User user = repository.findById(id);
            return user;
        }

        public User findAnUserByName(string username)
        {
            UserRepository repository = new UserRepository();
            User user = repository.findByName(username);
            return user;
        }

        public List<Role> getRoles()
        {
            return roles.Cast<Role>().ToList();
        }

        public List<User> getUsers()
        {
            IRepository<User> repository = new UserRepository();
            IEnumerable<User> users = repository.List;
            return users.Cast<User>().ToList();
        }

        public bool updateUser(User selectedUser)
        {
            //Danger: selected user with new role inside
            if(selectedUser != null)
            {
                IRepository<User> repository = new UserRepository();

                //update in aspUser
                User orginUser = repository.findById(selectedUser.UserID);
                //find old role
                Role oldRole = role_repo.findById(orginUser.RoleID);
                string oldRoleName = oldRole.RoleName;
                Role newRole = role_repo.findById(selectedUser.RoleID);
                string newRoleName = newRole.RoleName;
                var context = new NetCafeWeb.Models.ApplicationDbContext();
                var UserManager = new UserManager<NetCafeWeb.Models.ApplicationUser>(new UserStore<NetCafeWeb.Models.ApplicationUser>(context));
                ApplicationUser aspSelectedUser = context.Users.Where(u => u.UserName.Equals((selectedUser.UserName), StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

                var r1 = UserManager.RemoveFromRole(aspSelectedUser.Id, oldRoleName);
                var r2 = UserManager.AddToRole(aspSelectedUser.Id, newRoleName);

                if (r1.Succeeded && r2.Succeeded)
                {
                    //update in user table
                    repository.Update(selectedUser);
                    return true;
                }
                else return false;
            }
            

            return false;
        }
    }
}