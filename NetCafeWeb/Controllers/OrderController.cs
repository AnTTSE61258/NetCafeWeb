using NetCafeWeb.Models;
using NetCafeWeb.Service;
using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity.EntityFramework;
using NetCafeWeb.CustomFilters;
using System.Device.Location;

namespace NetCafeWeb.Controllers
{
    
    public class OrderController : Controller
    {
        //
        // GET: /Order/
        [AuthLog(Roles ="Admin, Supervisor")]
        public ActionResult Index()
        {
            var store = new Microsoft.AspNet.Identity.EntityFramework.UserStore<NetCafeWeb.Models.ApplicationUser>(new NetCafeWeb.Models.ApplicationDbContext());
            var manager = new Microsoft.AspNet.Identity.UserManager<NetCafeWeb.Models.ApplicationUser>(store);


            var a = manager.IsInRoleAsync(User.Identity.GetUserId(), "Admin");
            bool isAdmin = a.Result;

            IRepository<User> userRepository = new UserRepository();
            IEnumerable<User> users = userRepository.List;
            ViewBag.users = users.Cast<User>().ToList();

            IRepository<PC> pcRepository = new PCRepository();
            IEnumerable<PC> pcs = pcRepository.List;
            ViewBag.pcs = pcs.Cast<PC>().ToList();

            if (isAdmin)
            {
                //show het order
                IRepository<Order> repository = new OrderRepository();
                IEnumerable<Order> order = repository.List;
                ViewBag.orders = order.Cast<Order>().ToList();
                //FormsAuthentication.SetAuthCookie("asd", false);
                return View();
            }
            else //La supervisor
            {
                //Lay supervior user
                String supervisorName = User.Identity.Name;
                //Lay supervior id
                UserRepository repo = new UserRepository();
                NetCafeRepository netRepo = new NetCafeRepository();
                OrderRepository orderRepo = new OrderRepository();
                int supervisorId = repo.getIDByUsername(supervisorName);
                //Lay netcafe id
                int netID = netRepo.getNetCafeIDByName(supervisorId);
                //hien thi order cua netcafe id
                List<Order> orders = orderRepo.getOrderByNetCafe(netID);
                ViewBag.orders = orders;
            }

            
            return View();

           
        }
        [AuthLog(Roles = "Admin, Supervisor, Member")]
        public ActionResult Create(int? id)
        {
            //Lay login user name
            String username = User.Identity.GetUserName();
            UserRepository userRepo = new UserRepository();
            int userId = userRepo.getIDByUsername(username);
            ViewBag.userId = userId;

            //Lay user id
            IRepository<NetCafe> repository = new NetCafeRepository();
            if (id != null)
            {
                PCRepository repo = new PCRepository();
                List<PC> pcs = repo.findAvailable(id.Value);
                NetCafe selectedNetcafe = repository.findById(id.Value);
                ViewBag.selectedNetCafe = selectedNetcafe;
                ViewBag.pcs = pcs;

            }
           
            IEnumerable<NetCafe> iNetCafes = repository.List;
            List<NetCafe> netcafes = iNetCafes.Cast<NetCafe>().ToList();
            ViewBag.netcafes = netcafes;
            return View();
        }
        [HttpPost]
        public String AddBooking()
        {
            String idParam = Request.Params["pcid"];
            String useridParam = Request.Params["userid"];
            String date = Request.Params["date"];
            String time = Request.Params["time"];
            String duration = Request.Params["duration"];
            int pcid = int.Parse(idParam);
            int userid = int.Parse(useridParam);
           DateTime newDate = DateTime.ParseExact(date + " " + time, "dd/MM/yyyy HH:mm", null);
            int intDuration = int.Parse(duration);

            OrderService orderService = new OrderService();
            OrderStatus orderStatus = orderService.isCanOrder(pcid, newDate, intDuration, userid);
            if (orderStatus.status == OrderStatusCode.FAIL)
            {
                return orderStatus.message;
            }
            Order order = new Order();
            order.PCID = pcid;
            order.UserID = userid;
            order.StartTime = newDate;
            order.Duration = intDuration;
            order.OrderStatus = 0;
            // tru balance
            IRepository<Order> repository = new OrderRepository();
            repository.Add(order);
            return "true";
        }

        [HttpPost]
        public String getNearestNet()
        {
            double sLatitude = Double.Parse(Request.Params["latitude"]);
            double sLongitude = Double.Parse(Request.Params["longtitude"]);
            var sCoord = new GeoCoordinate(sLatitude, sLongitude);

            OrderService services = new OrderService();
            List<NetCafe> netcafes = services.getAllNetCafe();
            var firstCoord = new GeoCoordinate(netcafes[0].LocationX.Value, netcafes[0].LocationY.Value);
            string nearestNetName = netcafes[0].NetCafeName;
            double nearestDistance = sCoord.GetDistanceTo(firstCoord);


            foreach(NetCafe netCafe in netcafes)
            {
                var eCoord = new GeoCoordinate(netCafe.LocationX.Value, netCafe.LocationY.Value);
                double currentDistance = sCoord.GetDistanceTo(eCoord);
                if (nearestDistance > currentDistance)
                {
                    nearestDistance = currentDistance;
                    nearestNetName = netCafe.NetCafeName;
                }
            }

            return nearestNetName;
        }

        [HttpPost]
        public Boolean Add()
        {
            return true;
        }
        [HttpPost]
        public Boolean editOrder()
        {
            String idParam = Request.Params["id"];
            String pcid = Request.Params["pcid"];
            String useridParam = Request.Params["userid"];
            String startTime = Request.Params["startTime"];
            String duration = Request.Params["duration"];
            String status = Request.Params["orderStatus"];

            int intpcid = int.Parse(pcid);
            int userid = int.Parse(useridParam);
            DateTime newDate = DateTime.Parse(startTime);
            int intDuration = int.Parse(duration);
            int intstatus = int.Parse(status);

            IRepository<Order> repository = new OrderRepository();
            int id = int.Parse(idParam);
            Order order = repository.findById(id);

            order.PCID = intpcid;
            order.UserID = userid;
            order.StartTime = newDate;
            order.Duration = intDuration;
            order.OrderStatus = intstatus;

            repository.Update(order);

            return true;
        }



        [HttpPost]
        public Boolean delete()
        {
            String idParam = Request.Params["id"];
            int id = int.Parse(idParam);
            IRepository<Order> repository = new OrderRepository();
            Order deletedOrder = repository.findById(id);
            if (deletedOrder == null)
            {
                return false;
            }
            repository.Delete(deletedOrder);
            return true;
        }
        [HttpPost]
        public Order getOrder()
        {
            String idParam = Request.Params["id"];
            int id = int.Parse(idParam);
            IRepository<Order> repository = new OrderRepository();
            Order order = repository.findById(id);
            if (order == null)
            {
                return order;
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
                return RedirectToAction("Index", "Order");
            }
            else
            {
                IRepository<Order> repository = new OrderRepository();
                Order order = repository.findById(id.Value);
                ViewBag.orders = order;

            }
            return View();
        }
    }
}