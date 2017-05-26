using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UsersRepository:ConnectionClass
    {
        public UsersRepository():base()
        {
        }

        public IQueryable<User> GetUsers()
        {
            return Entity.Users;
        }

        public IQueryable<User> GetUsers(string keyword)
        {
            return Entity.Users.Where(x => x.FirstName.Contains(keyword));
        }

        public IQueryable<Role> GetUserRoles(string username)
        {
            return Entity.Users.SingleOrDefault(x => x.Username == username).Roles.AsQueryable();
        }

        public bool DoesUsernameExist(string username)
        {
            return Entity.Users.SingleOrDefault(x => x.Username == username) == null ? false : true;
        }
    }
}
