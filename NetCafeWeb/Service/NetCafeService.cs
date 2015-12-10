using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NetCafeWeb.Models;

namespace NetCafeWeb.Service
{
    public class NetCafeService : INetCafeService
    {
        NetCafeRepository netcafeRepo = new NetCafeRepository();
        public List<NetCafe> getAllNetCafe()
        {
            IEnumerable<NetCafe> netcafes = netcafeRepo.List;
            return netcafes.Cast<NetCafe>().ToList();
        }
        public bool isExistWithName(string name)
        {
            var list = netcafeRepo.getByName(name);
            if (list != null & list.Count > 0)
            {
                return true;
            }

            return false;
        }

        public NetCafe findByID(int id)
        {
            var netCafe = netcafeRepo.findById(id);
            return netCafe;
        }

        public bool isExistWithSupervisor(int id)
        {
            if (id == 1)
            {
                return false;
            }
            else
            {
                var supervisor = netcafeRepo.findBySuID(id);
                if (supervisor.Count > 0)
                {
                    return true;
                }
            }
            return false;
        }

        // Kiem tra xem Name va Supervisor co bi trung voi Net khac hay ko
        public bool checkValidEdition(NetCafe checkNet)
        {
            var netList = netcafeRepo.NetCafeList();

            foreach (NetCafe net in netList)
            {
                if (net.NetCafeID != checkNet.NetCafeID &&
                    (net.NetCafeName == checkNet.NetCafeName || net.SupervisorID == checkNet.SupervisorID))
                {
                    return false;
                }
            }

            return true;

        }
    }
}