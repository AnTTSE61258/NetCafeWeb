using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NetCafeWeb.Models;

namespace NetCafeWeb.Service
{
    public class MobileService
    {
        UserRepository userRepo = new UserRepository();
        NetCafeRepository netcafeRepo = new NetCafeRepository();
        PCRepository pcRepo = new PCRepository();
        
        public string checkUser(string username, string password)
        {
            if(userRepo.checkUser(username,password))
            {
                return "true";
            }
            return "false";
        }

        public List<PCJson> getPcList(string username, string password, int netCafeId)
        {
            if (userRepo.checkUser(username, password))
            {
                List<PCJson> pcjsons = new List<PCJson>();
                List<PC> pcs = pcRepo.findByNetcafeID(netCafeId);
                foreach (PC pc in pcs)
                {
                    pcjsons.Add(new PCJson(pc.PCID, pc.PCName, pc.PCDescriptions, pc.Price));

                }
                return pcjsons;
            }
            return null;
        }
    }
}