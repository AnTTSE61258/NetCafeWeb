using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NetCafeWeb.Models;

namespace NetCafeWeb.Service
{
    public class RoleService : IRoleService
    {
        public bool addRole(Role role)
        {
            RoleRepository repository = new RoleRepository();
            if(role != null)
            {
                repository.Add(role);
                return true;
            }
            return false;
        }

        public int getRoleIdByRoleName(string roleName)
        {
            RoleRepository repository = new RoleRepository();
            return repository.findIdRoleByName(roleName);
        }
    }
}