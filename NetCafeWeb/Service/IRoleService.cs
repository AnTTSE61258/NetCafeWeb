using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeWeb.Service
{
    public interface IRoleService
    {
        int getRoleIdByRoleName(string roleName);
        bool addRole(Role role);
    }
}
