using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetCafeWeb.Models
{
    public class PCRepository : IRepository<PC>
    {
        NetCafeEntities1 _netCafeContext;
        public PCRepository()
        {
            _netCafeContext = new NetCafeEntities1();
        }
        public IEnumerable<PC> List
        {
            get
            {
                return _netCafeContext.PCs;
            }
        }

        public void Add(PC entity)
        {
            _netCafeContext.PCs.Add(entity);
            _netCafeContext.SaveChanges();
        }

        public void Delete(PC entity)
        {
            _netCafeContext.PCs.Remove(entity);
            _netCafeContext.SaveChanges();
        }

        public PC findById(int Id)
        {
            var query = (from r in _netCafeContext.PCs where r.PCID == Id select r).FirstOrDefault();
            return query;
        }

        public void Update(PC entity)
        {
            _netCafeContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _netCafeContext.SaveChanges();
        }
    }
}