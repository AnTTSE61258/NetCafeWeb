using NetCafeWeb.Models;
using NetCafeWeb.Service;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NetCafeWeb.Controllers
{
    public class OrderController : Controller
    {
        //
        // GET: /Order/
        public ActionResult Index()
        {
            FormsAuthentication.SetAuthCookie("asd", false);
            return View();
        }
        public ActionResult Create(int? id)
        {
            if (id != null)
            {
                PCRepository repo = new PCRepository();
                List<PC> pcs = repo.findAvailable(id.Value);
                ViewBag.pcs = pcs;

            }
            IRepository<NetCafe> repository = new NetCafeRepository();
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
            OrderStatus orderStatus = orderService.isCanOrder(pcid, newDate, intDuration);
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
        public Boolean Add()
        {
            return true;
        }
        [HttpPost]
        public Boolean editOrder()
        {
            return true;
        }
        [HttpPost]
        public Boolean delete()
        {
            return true;
        }
        [HttpPost]
        public Order getOrder()
        {
            return null;
        }
        [HttpPost]
        public ActionResult edit(int? id)
        {
            return View();
        }
    }
}