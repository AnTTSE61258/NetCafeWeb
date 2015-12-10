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

        public List<PC> PCList()
        {
            var list = (from r in _pcContext.PCs where r.NetCafe.NetCafeStatus==1 select r).ToList();
            return list;
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

        public Boolean findByName(string name)
        {
            var query = (from r in _pcContext.PCs where r.PCName == name select r).FirstOrDefault();
            if (query == null)
            {
                return false;
            }
            return true;
        }

        public List<PC> sortBy(string columnName)
        {
            List<PC> pcList = new List<PC>();
            switch(columnName)
            {
                case "PCName": pcList = (from r in _pcContext.PCs orderby r.PCName ascending select r).ToList(); break;
                case "Price": pcList = (from r in _pcContext.PCs orderby r.Price ascending select r).ToList(); break;
                case "NetCafeID": pcList = (from r in _pcContext.PCs orderby r.NetCafeID ascending select r).ToList(); break;
                case "PCStatus": pcList = (from r in _pcContext.PCs orderby r.PCStatus ascending select r).ToList(); break;
            }
            return pcList;
        }

        public List<PC> findByNetcafeID(int Id)
        {
            List<PC> lstPC = (from r in _pcContext.PCs where r.NetCafeID == Id && r.NetCafe.NetCafeStatus == 1 select r).ToList();
            return lstPC;
        }

        public List<PC> findAvailable(int netCafeID)
        {
            var query = (from r in _pcContext.PCs where r.NetCafeID == netCafeID && r.PCStatus == 1 select r).ToList();

            return query;

        }
        
        public void Update(PC entity)
        {
            _pcContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _pcContext.SaveChanges();
        }
    }
}