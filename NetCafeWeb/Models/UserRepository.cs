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

        public void Update(User entity)
        {
            _userContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _userContext.SaveChanges();
        }
    }
}