﻿using NetCafeWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using NetCafeWeb.CustomFilters;
using NetCafeWeb.Service;

namespace NetCafeWeb.Controllers
{
    [AuthLog(Roles = "Admin")]
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
        public String add()
        {
            String name = Request.Params["name"];
            String address = Request.Params["address"];
            String supervisor = Request.Params["supervisor"];
            String status = Request.Params["status"];
            String phoneNumber = Request.Params["phoneNumber"];
            String description = Request.Params["description"];
            double locationX = Double.Parse(Request.Params["locationX"]);
            double locationY = Double.Parse(Request.Params["locationY"]);



            //valid du lieu

            NetCafeService netcafeService = new NetCafeService();
            if (netcafeService.isExistWithName(name))
            {
                return "Net cafe with this name is existed!";
            }
            // Check supervisor da quan ly net nao hay chua
            else if (netcafeService.isExistWithSupervisor(int.Parse(supervisor)))
            {
                return "This supervisor has been managed a Netcafe already!";
            }
            IRepository<NetCafe> repository = new NetCafeRepository();
            NetCafe netcafe = new NetCafe();
            netcafe.NetCafeName = name;
            netcafe.NetCafeAddress = address;
            netcafe.SupervisorID = int.Parse(supervisor);
            netcafe.NetCafeStatus = int.Parse(status);

            netcafe.NetCafePhoneNumber = phoneNumber;
            netcafe.NetCafeDescriptions = description;
            netcafe.LocationX = locationX;
            netcafe.LocationY = locationY;
            repository.Add(netcafe);
            return "true";
        }

        [HttpPost]
        public String editNetCafe()
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

            // kiem tra xem noi dung edit co hop le hay khong
            NetCafeService netcafeService = new NetCafeService();
            if (!netcafeService.checkValidEdition(netcafe))
            {
                return "false";
            }

            repository.Update(netcafe);
            return "true";

        }
        [HttpPost]
        public String deactivate()
        {
            String idParam = Request.Params["id"];
            int id = int.Parse(idParam);
            IRepository<NetCafe> repository = new NetCafeRepository();
            NetCafe deactivateNet = repository.findById(id);
            if (deactivateNet == null)
            {
                return "false";
            }
            if (deactivateNet.NetCafeStatus == SLIM_CONFIG.NETCAFE_ACTIVE)
            {
                deactivateNet.NetCafeStatus = SLIM_CONFIG.NETCAFE_DEACTIVE;
            }
            repository.Update(deactivateNet);

            return "true";

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