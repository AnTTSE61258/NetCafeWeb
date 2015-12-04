using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetCafeWeb.Service
{
    public class NetCafeService : INetCafeService
    {
        NetCafeRepository netcafeRepo = new NetCafeRepository();
        public bool isExistWithName(string name)
        {
            var list = netcafeRepo.getByName(name);
            if (list != null & list.Count > 0)
            {
                return true;
            }

            return false;
        }
    }
}