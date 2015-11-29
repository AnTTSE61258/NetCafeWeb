using NetCafeWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetCafeWeb.Controllers
{
    public class NetCafeController : Controller
    {
        public ActionResult Test()
        {
            return View();
        }
        // GET: NetCafe
        public ActionResult Index()
        {
            IRepository<NetCafe> repository = new NetCafeRepository();
            IEnumerable<NetCafe> netCafes = repository.List;
            ViewBag.netcafes = netCafes.Cast<NetCafe>().ToList();
            UserRepository repository2 = new UserRepository();
            ViewBag.supervisors = repository2.supervisorList();

            return View();
        }
        [HttpPost]
        public Boolean add()
        {
            String name = Request.Params["name"];
            String address = Request.Params["address"];
            String supervisor = Request.Params["supervisor"];
            String status = Request.Params["status"];
            String phoneNumber = Request.Params["phoneNumber"];
            String description = Request.Params["description"];

            IRepository<NetCafe> repository = new NetCafeRepository();
            NetCafe netcafe = new NetCafe();
            netcafe.NetCafeName = name;
            netcafe.NetCafeAddress = address;
            netcafe.SupervisorID = int.Parse(supervisor);
            netcafe.NetCafeStatus = int.Parse(status);
           
            netcafe.NetCafePhoneNumber = phoneNumber;
            netcafe.NetCafeDescriptions = description;
            repository.Add(netcafe);
            return true;
        }

        [HttpPost]
        public Boolean editNetCafe()
        {
            String idParam = Request.Params["id"];
            String name = Request.Params["name"];
            String address = Request.Params["address"];
            String supervisor = Request.Params["supervisor"];
            String status = Request.Params["status"];
            String phoneNumber = Request.Params["phoneNumber"];
            String description = Request.Params["description"];

            IRepository<NetCafe> repository = new NetCafeRepository();
            int id = int.Parse(idParam);
            NetCafe netcafe = repository.findById(id);
            netcafe.NetCafeName = name;
            netcafe.NetCafeAddress = address;
            netcafe.SupervisorID = int.Parse(supervisor);
            netcafe.NetCafeStatus = int.Parse(status);

            netcafe.NetCafePhoneNumber = phoneNumber;
            netcafe.NetCafeDescriptions = description;
            repository.Update(netcafe);
            return true;

        }
        [HttpPost]
        public Boolean delete()
        {
            String idParam = Request.Params["id"];
            int id = int.Parse(idParam);
            IRepository<NetCafe> repository = new NetCafeRepository();
            NetCafe deletedNetCafe = repository.findById(id);
            if (deletedNetCafe == null)
            {
                return false;
            }
            repository.Delete(deletedNetCafe);
            return true;
            
        }
        [HttpPost]
        public NetCafe getNetCafe()
        {

            String idParam = Request.Params["id"];
            int id = int.Parse(idParam);
            IRepository<NetCafe> repository = new NetCafeRepository();
            NetCafe netCafe = repository.findById(id);
            if (netCafe == null)
            {
                return netCafe;
            }
            else
            {
                return null;
            }
        }
        public ActionResult edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "NetCafe");
            }
            else
            {
                IRepository<NetCafe> repository = new NetCafeRepository();
                NetCafe netcafe = repository.findById(id.Value);
                ViewBag.netcafe = netcafe;
                UserRepository repository2 = new UserRepository();
                ViewBag.supervisors = repository2.supervisorList();

            }



            return View();
        }
    }
}