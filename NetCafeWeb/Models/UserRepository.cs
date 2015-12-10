using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace NetCafeWeb.Models
{
    public class UserRepository : IRepository<User>
    {
        //protected readonly IDbSet<User> _dbSet;
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

        public int getIDByUsername(string username)
        {
            var query = (from u in _userContext.Users where u.UserName == username select u).FirstOrDefault();
            if(query != null)
            {
                return query.UserID;
            }
            return -1;
        }

        public Boolean findExistedName(string username)
        {
            var query = (from u in _userContext.Users where u.UserName == username select u).FirstOrDefault();
            if(query != null)
            {
                return true;
            }
            return false;
        }

        public User findByName(string username)
        {
            var query = (from u in _userContext.Users where u.UserName == username select u).FirstOrDefault();
            return query;
        }

        public void Update(User entity)
        {
            var user = _userContext.Users.Find(entity.UserID);
            user.Balance = entity.Balance;
            user.RoleID = entity.RoleID;
            //_dbSet.Attach(entity);
            _userContext.Entry(user).State = System.Data.Entity.EntityState.Modified;
            _userContext.SaveChanges();
        }

        public bool checkUser(string name, string pass)
        {
            var query = (from u in _userContext.Users where u.UserName == name & u.Password == pass select u).FirstOrDefault();
            if (query != null)
            {
                return true;
            }
            return false;
        }
    }
}