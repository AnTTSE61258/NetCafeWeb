using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetCafeWeb.Models
{
    public class RoleRepository : IRepository<Role>
    {
        NetCafeEntities1 _netCafeContext;
        public RoleRepository()
        {
            _netCafeContext = new NetCafeEntities1();
        }
        public IEnumerable<Role> List
        {
            get
            {
                return _netCafeContext.Roles;
            }
        }

        public void Add(Role entity)
        {
            _netCafeContext.Roles.Add(entity);
            _netCafeContext.SaveChanges();
        }

        public void Delete(Role entity)
        {
            _netCafeContext.Roles.Remove(entity);
            _netCafeContext.SaveChanges();
        }

        public Role findById(int Id)
        {
            var query = (from r in _netCafeContext.Roles where r.RoleID == Id select r).FirstOrDefault();
            return query;
        }

        public void Update(Role entity)
        {
            _netCafeContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _netCafeContext.SaveChanges();
        }
    }
}