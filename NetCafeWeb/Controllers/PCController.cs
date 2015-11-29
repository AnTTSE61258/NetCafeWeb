using NetCafeWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetCafeWeb.Controllers
{
    public class PCController : Controller
    {
        //
        // GET: /PC/
        public ActionResult Index()
        {
            IRepository<PC> repository = new PCRepository();
            IEnumerable<PC> pcs = repository.List;
            ViewBag.pcs = pcs.Cast<PC>().ToList();
            NetCafeRepository repository2 = new NetCafeRepository();
            ViewBag.netcafes = repository2.NetCafeList();

            return View();
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
            String netcafeAddress = Request.Params["netcafeAddress"];
            String status = Request.Params["status"];

            IRepository<PC> repository = new PCRepository();
            int id = int.Parse(idParam);
            PC pc = repository.findById(id);
            pc.PCName = name;
            pc.Price = float.Parse(price);
            pc.PCDescriptions = description;
            pc.NetCafeID = int.Parse(netcafeAddress);
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
            repository.Delete(deletedPC);

            return true;
        }
        [HttpPost]
        public PC getPC()
        {
            String idParam = Request.Params["id"];
            int id = int.Parse(idParam);
            IRepository<PC> repository = new PCRepository();
            PC pc = repository.findById(id);
            if (pc == null)
            {
                return pc;
            }
            else
            {
                return null;
            }
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