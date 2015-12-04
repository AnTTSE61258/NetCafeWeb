using NetCafeWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NetCafeWeb.CustomFilters;

namespace NetCafeWeb.Controllers
{
    [AuthLog(Roles = "Admin,Supervisor")]
    public class PCController : Controller
    {
        //
        // GET: /PC/
        private int role = 2;
        public ActionResult Index()
        {
            PCRepository PCRepo = new PCRepository();
            NetCafeRepository NetRepo = new NetCafeRepository();
            List<PC> PCList = new List<PC>();

            if (role == 1)
            {
                IEnumerable<PC> pcs = PCRepo.List;
                PCList = pcs.Cast<PC>().ToList();
                var query = PCList.OrderBy(p => p.NetCafeID).ThenBy(p => p.PCStatus).ThenBy(p => p.PCName).ThenBy(p => p.Price);
                ViewBag.PCList = query.ToList();
                ViewBag.NetList = NetRepo.NetCafeList();
                ViewBag.isAdmin = "Admin";
                return View();
            }
            else
            {
                string username = User.Identity.Name;
                UserRepository repo = new UserRepository();
                int suID = repo.getIDByUsername(username);

                int superID = suID;
                //Lay danh sach nhung quan thang nay dang quan ly
                NetCafeRepository net = new NetCafeRepository();
                List<NetCafe> NetList = net.findBySuID(superID);

                //lay danh sach nhung may co trong nhung quan ma no quan ly
                foreach (NetCafe netCafe in NetList)
                {
                    PCList = PCRepo.findByNetcafeID(netCafe.NetCafeID);
                }
                var query = PCList.OrderBy(p => p.PCStatus).ThenBy(p => p.PCName).ThenBy(p => p.Price);
                ViewBag.PCList = query.ToList();
                ViewBag.NetList = NetList;
                return View();
            }
        }
        
        [HttpPost]
        public Boolean Add()
        {
            String name = Request.Params["name"];
            String price = Request.Params["price"];
            String description = Request.Params["description"];
            String netcafeAddress = Request.Params["netcafeAddress"];
            String status = Request.Params["status"];

            IRepository<PC> repository = new PCRepository();
            PC pc = new PC();
            pc.PCName = name;
            pc.Price = float.Parse(price);
            pc.PCDescriptions = description;
            pc.NetCafeID = int.Parse(netcafeAddress);
            pc.PCStatus = int.Parse(status);
            repository.Add(pc);
            return true;
        }
        [HttpPost]
        public Boolean editPC()
        {
            String idParam = Request.Params["id"];
            String name = Request.Params["name"];
            String price = Request.Params["price"];
            String description = Request.Params["description"];
            String status = Request.Params["status"];

            IRepository<PC> repository = new PCRepository();
            int id = int.Parse(idParam);
            PC pc = repository.findById(id);
            pc.PCName = name;
            pc.Price = float.Parse(price);
            pc.PCDescriptions = description;
            pc.PCStatus = int.Parse(status);
            repository.Update(pc);
            return true;
        }
        [HttpPost]
        public Boolean delete()
        {

            String idParam = Request.Params["id"];
            int id = int.Parse(idParam);
            IRepository<PC> repository = new PCRepository();
            PC deletedPC = repository.findById(id);
            if (deletedPC == null)
            {
                return false;
            }
            try
            {
                repository.Delete(deletedPC);
            }
            catch (Exception e)
            {
                e.GetHashCode();
                return false;
            }
            return true;
        }
        [HttpGet]
        public ActionResult edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "PC");
            }
            else
            {
                IRepository<PC> repository = new PCRepository();
                PC pc = repository.findById(id.Value);
                ViewBag.pc = pc;
                NetCafeRepository repository2 = new NetCafeRepository();
                ViewBag.netcafes = repository2.NetCafeList();

            }

            return View();
        }
    }
}