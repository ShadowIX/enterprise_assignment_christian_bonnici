using Common;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class UsersBL
    {
        UsersRepository ur = new UsersRepository();

        public IQueryable<User> GetUsers()
        {
            return ur.GetUsers();
        }

        public IQueryable<User> GetUsers(string keyword)
        {
            return ur.GetUsers(keyword);
        }

        public IQueryable<Role> GetUserRoles(string username)
        {
            if (ur.DoesUsernameExist(username))
                return ur.GetUserRoles(username);
            else return null;
        }
    }
}
