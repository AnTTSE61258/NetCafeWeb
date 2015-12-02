using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetCafeWeb.Models
{
    public class UserRepository : IRepository<User>
    {
        NetCafeEntities1 _userContext;
        public UserRepository()
        {
            _userContext = new NetCafeEntities1();
        }
        public IEnumerable<User> List
        {
            get
            {
                return _userContext.Users;
            }
        }

        public List<User> supervisorList()
        {
            var query = (from r in _userContext.Users where r.RoleID == 2 || r.RoleID == 1 select r).ToList();
            return query;
        }

        public void Add(User entity)
        {
            _userContext.Users.Add(entity);
            _userContext.SaveChanges();
        }

        public void Delete(User entity)
        {
            _userContext.Users.Remove(entity);
            _userContext.SaveChanges();
        }

        public User findById(int Id)
        {
            var query = (from r in _userContext.Users where r.UserID == Id select r).FirstOrDefault();
            return query;
        }

        public Boolean findByName(string username)
        {
            var query = (from u in _userContext.Users where u.UserName == username select u).FirstOrDefault();
            if(query != null)
            {
                return true;
            }
            return false;
        }

        public void Update(User entity)
        {
            _userContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _userContext.SaveChanges();
        }
    }
}