using NetCafeWeb.Models;
using NetCafeWeb.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NetCafeWeb.CustomFilters;
using Microsoft.AspNet.Identity;
namespace NetCafeWeb.Controllers
{
    [AuthLog(Roles = "Admin,Supervisor")]
    public class PCController : Controller
    {
        
        public ActionResult Index()
        {
            var store = new Microsoft.AspNet.Identity.EntityFramework.UserStore<NetCafeWeb.Models.ApplicationUser>(new NetCafeWeb.Models.ApplicationDbContext());
            var manager = new Microsoft.AspNet.Identity.UserManager<NetCafeWeb.Models.ApplicationUser>(store);
            var a = manager.IsInRoleAsync(User.Identity.GetUserId(), "Admin");
            //var b = manager.IsInRoleAsync(User.Identity.GetUserId(), "Supervisor");
            bool isAdmin = a.Result;
            a = manager.IsInRoleAsync(User.Identity.GetUserId(), "Supervisor");
            bool isSupervisor = a.Result;

            List<PC> PCList = new List<PC>();
            List<NetCafe> NetList = new List<NetCafe>();
            PCService service = new PCService();
            
            if (isSupervisor)
            {
                string username = User.Identity.Name;
                NetList = service.GetManageNet(username);

                if (NetList != null && NetList.Count > 0)
                {
                    foreach (NetCafe netCafe in NetList)
                    {
                        PCList = service.FindByNetID(netCafe.NetCafeID);
                    }
                }
                var query = PCList.OrderBy(p => p.PCStatus).ThenBy(p => p.PCName).ThenBy(p => p.Price);
                ViewBag.PCList = query.ToList();
                ViewBag.NetList = NetList;
                ViewBag.Role = "Supervisor";
                return View();
            }
            else
            {
                PCList = service.GetPCList();
                var query = PCList.OrderBy(p => p.NetCafeID).ThenBy(p => p.PCStatus).ThenBy(p => p.PCName).ThenBy(p => p.Price);
                ViewBag.PCList = query.ToList();
                ViewBag.NetList = service.GetNetList();
                if (isAdmin)
                {
                    ViewBag.Role = "Admin";
                }
                else
                {
                    ViewBag.Role = "Member";
                }
                return View();
            }
        }
        
        [HttpPost]
        public Boolean Add()
        {
            PCService Service = new PCService();
            PC NewPC = new PC();
            NewPC.PCName = Request.Params["name"];
            NewPC.Price = float.Parse(Request.Params["price"]);
            NewPC.PCDescriptions = Request.Params["description"];
            NewPC.NetCafeID = int.Parse(Request.Params["netcafeAddress"]);
            NewPC.PCStatus = int.Parse(Request.Params["status"]);
            
            if (Service.AddPC(NewPC))
            {
                return true;
            }
            return false;
        }

        [HttpPost]
        public Boolean EditPC()
        {
            PCService Service = new PCService();
            PC EditedPC = new PC();
            EditedPC.PCID = int.Parse(Request.Params["id"]);
            EditedPC.PCName = Request.Params["name"];
            EditedPC.Price = float.Parse(Request.Params["price"]);
            EditedPC.PCDescriptions = Request.Params["description"];
            EditedPC.PCStatus = int.Parse(Request.Params["status"]);
            
            if (Service.EditPC(EditedPC))
            {
                return true;
            }
            return false;
        }

        [HttpPost]
        public Boolean Delete()
        {
            PCService Service = new PCService();
            int ID = int.Parse(Request.Params["id"]);
            
            if (Service.DeletePC(ID))
            {
                return true;
            }
            return false;
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "PC");
            }
            else
            {
                PCService service = new PCService();
                PC editPC = new PC();
                editPC = service.GetEditPCByID(id.Value);
                ViewBag.pc = editPC;
                ViewBag.netcafe = service.GetNetCafeByID(editPC.NetCafeID);
            }
            return View();
        }
    }
}