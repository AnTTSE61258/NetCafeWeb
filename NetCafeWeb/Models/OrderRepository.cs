using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetCafeWeb.Models
{
    public class OrderRepository : IRepository<Order>
    {
        NetCafeEntities1 _orderContext;
        public OrderRepository()
        {
            _orderContext = new NetCafeEntities1();
        }
        public IEnumerable<Order> List
        {
            get
            {
                return _orderContext.Orders;
            }
        }
        public List<Order> OrderList()
        {
            var query = (from r in _orderContext.Orders select r).ToList();
            return query;
        }
        public void Add(Order entity)
        {
            _orderContext.Orders.Add(entity);
            _orderContext.SaveChanges();
        }

        public void Delete(Order entity)
        {
            _orderContext.Orders.Remove(entity);
            _orderContext.SaveChanges();
        }

        public Order findById(int Id)
        {
            var query = (from r in _orderContext.Orders where r.OrderID == Id select r).FirstOrDefault();
            return query;
        }

        public void Update(Order entity)
        {
            _orderContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _orderContext.SaveChanges();
        }

        public List<Order> getOrderByNetCafe(int netID)
        {
            var query = (from o in _orderContext.Orders where o.PC.NetCafeID == netID select o).ToList();
            return query;
        }

        public List<Order> getOrderByPCID(int pcID)
        {
            var query = (from o in _orderContext.Orders where o.PC.PCID == pcID select o).ToList();
            return query;
        }
    }
}