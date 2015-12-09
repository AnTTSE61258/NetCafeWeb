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
        PCService PCService = new PCService();
        public ActionResult Index(int? id)
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

            
            if (isSupervisor)
            {
                string username = User.Identity.Name;
                NetList = PCService.GetManageNet(username);
                int selectedNetID = 0;

                if (NetList != null && NetList.Count > 0)
                {
                    foreach (NetCafe netCafe in NetList)
                    {
                        PCList = PCService.FindByNetID(netCafe.NetCafeID);
                        selectedNetID = netCafe.NetCafeID;
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
                if (id != null)
                {
                    PCList = PCService.FindByNetID(id.Value);
                    ViewBag.pcList = PCList;
                    ViewBag.SelectedNetcafe = PCService.GetNetCafeByID(id.Value);
                }
                else
                {
                    PCList = PCService.GetPCList();
                    ViewBag.pcList = PCList;
                }

                var query = PCList.OrderBy(p => p.NetCafeID).ThenBy(p => p.PCStatus).ThenBy(p => p.PCName).ThenBy(p => p.Price);
                ViewBag.PCList = query.ToList();
                ViewBag.NetList = PCService.GetNetList();
                ViewBag.Role = "Admin";
                
                return View();
            }
        }

        public JsonResult GetJsonPCList()
        {

            var PCList = PCService.GetPCList();
            return Json(PCList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetJsonNetList()
        {
            var NetList = PCService.GetNetList();
            return Json(NetList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Filter (int? id)
        {
            if (id != null)
            {
                List<PC> PCList = PCService.FindByNetID(id.Value);
                ViewBag.pcList = PCList;
            }
            else
            {
                List<PC> PCList = PCService.GetPCList();
                ViewBag.pcList = PCList;
            }
            return View();
        }
        
        [HttpPost]
        public Boolean Add()
        {
            PC NewPC = new PC();
            NewPC.PCName = Request.Params["name"];
            NewPC.Price = float.Parse(Request.Params["price"]);
            NewPC.PCDescriptions = Request.Params["description"];
            NewPC.NetCafeID = int.Parse(Request.Params["netcafeAddress"]);
            NewPC.PCStatus = int.Parse(Request.Params["status"]);
            
            if (PCService.AddPC(NewPC))
            {
                return true;
            }
            return false;
        }

        [HttpPost]
        public Boolean EditPC()
        {
            PC EditedPC = new PC();
            EditedPC.PCID = int.Parse(Request.Params["id"]);
            EditedPC.PCName = Request.Params["name"];
            EditedPC.Price = float.Parse(Request.Params["price"]);
            EditedPC.PCDescriptions = Request.Params["description"];
            EditedPC.PCStatus = int.Parse(Request.Params["status"]);
            
            if (PCService.EditPC(EditedPC))
            {
                return true;
            }
            return false;
        }

        [HttpPost]
        public Boolean Delete()
        {
            int ID = int.Parse(Request.Params["id"]);
            
            if (PCService.DeletePC(ID))
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
                PC editPC = new PC();
                editPC = PCService.GetEditPCByID(id.Value);
                ViewBag.pc = editPC;
                ViewBag.netcafe = PCService.GetNetCafeByID(editPC.NetCafeID);
            }
            return View();
        }
    }
}