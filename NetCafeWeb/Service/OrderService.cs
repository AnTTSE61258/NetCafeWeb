using NetCafeWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetCafeWeb.Service
{
    public static class OrderStatusCode
    {
        public static int OK = 0;
        public static int FAIL = 1;
    }
    public class OrderStatus
    {
        public String message { get; set; }
        public int status { get; set; }
    }

    public class OrderService : IOrderInterface
    {
        private OrderRepository orderRepository = new OrderRepository();

        public List<NetCafe> getAllNetCafe()
        {
            IRepository<NetCafe> repository = new NetCafeRepository();
            IEnumerable<NetCafe> netcafes = repository.List;
            return netcafes.Cast<NetCafe>().ToList();
        }

        public OrderStatus isCanOrder(int pcid, DateTime startTime, int duration)
        {
            OrderStatus orderstatus = new OrderStatus();
            List<Order> orders = orderRepository.List.Cast<Order>().ToList();
            foreach(Order order in orders){
               if (startTime < order.StartTime && startTime.AddHours(duration) > order.StartTime)
                {
                    orderstatus.status = OrderStatusCode.FAIL;
                    orderstatus.message = "Sorry, this PC have been ordered from "+order.StartTime + " to " + order.StartTime.AddHours(order.Duration);

                    return orderstatus ;
                }
               if (startTime >= order.StartTime && startTime <= order.StartTime.AddHours(duration))
                {
                    orderstatus.status = OrderStatusCode.FAIL;
                    orderstatus.message = "Sorry, this PC have been ordered from " + order.StartTime + " to " + order.StartTime.AddHours(order.Duration);

                    return orderstatus;
                }
            }

            orderstatus.status = OrderStatusCode.OK;
            orderstatus.message = "True";
            return orderstatus;

        }
    }
}