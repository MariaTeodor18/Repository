using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext dbContext;

        public UserRepository()
        {
            dbContext = new ApplicationDbContext();
        }

        public ApplicationUser GetUser(string userId)
        {
            return dbContext.Users.Find(userId);
        }
    }
}
