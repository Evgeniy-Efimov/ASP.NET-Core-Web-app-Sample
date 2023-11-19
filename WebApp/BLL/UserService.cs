using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApp.DAL;
using WebApp.Interfaces;
using WebApp.Models;

namespace WebApp.BLL
{
    public class UserService : IUserService
    {
        protected readonly DB1DataContext DataContext;
        private Dictionary<string, User> userCache = new Dictionary<string, User>();

        public UserService(DB1DataContext dataContext)
        {
            DataContext = dataContext;
        }

        public User GetUser(string userID)
        {
            if (userCache.ContainsKey(userID))
                return userCache[userID];

            var user = DataContext.Users.Where(x => !string.IsNullOrWhiteSpace(userID) && x.UserID == userID).Include(u => u.Roles).SingleOrDefault();

            if (user != null)
                userCache[userID] = user;

            return user;
        }
    }
}
