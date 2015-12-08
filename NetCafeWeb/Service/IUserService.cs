using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeWeb.Service
{
    public interface IUserService
    {
        /// <summary>
        /// get all the users that has been registerd
        /// </summary>
        /// <returns>List<User></User></user></returns>
        List<User> getUsers();
        /// <summary>
        /// get all the role in this project
        /// </summary>
        /// <returns>List<Role></Role></returns>
        List<Role> getRoles();
        /// <summary>
        /// find an user in the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>User</returns>
        User findAnUser(int id);
        /// <summary>
        /// update the selected user in the database
        /// </summary>
        /// <param name=""></param>
        /// <returns>a user</returns>
        bool updateUser(User selectedUser);
        /// <summary>
        /// check whether the username is existed or not
        /// </summary>
        /// <param name="username"></param>
        /// <returns>true if existed</returns>
        bool checkExistedUsername(string username);
        /// <summary>
        /// add an user into the database
        /// </summary>
        /// <param name="user"></param>
        /// <returns>true if success</returns>
        bool addUser(User user);
    }
}
