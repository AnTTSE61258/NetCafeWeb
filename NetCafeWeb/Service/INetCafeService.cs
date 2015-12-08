using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeWeb.Service
{
    interface INetCafeService
    {
        bool isExistWithName(String name);
        NetCafe findByID(int id);
    }
}
