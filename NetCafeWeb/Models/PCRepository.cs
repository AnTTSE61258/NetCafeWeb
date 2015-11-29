using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace NetCafeWeb.Models
{
    public class PCRepository : IRepository<PC>
    {
        NetCafeEntities1 _pcContext;
        public PCRepository()
        {
            _pcContext = new NetCafeEntities1();
        }
        public IEnumerable<PC> List
        {
            get
            {
                return _pcContext.PCs;
            }
        }

        public void Add(PC entity)
        {
            _pcContext.PCs.Add(entity);
            _pcContext.SaveChanges();
        }

        public void Delete(PC entity)
        {
            _pcContext.PCs.Remove(entity);
            _pcContext.SaveChanges();
        }

        public PC findById(int Id)
        {
            var query = (from r in _pcContext.PCs where r.PCID == Id select r).FirstOrDefault();
            return query;
        }

        public List<PC> findAvailable(int netCafeID)
        {
            var query = (from r in _pcContext.PCs where r.NetCafeID == netCafeID && r.PCStatus == 0 select r).ToList();

            return query;
        }

        public void Update(PC entity)
        {
            _pcContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _pcContext.SaveChanges();
        }
    }
}