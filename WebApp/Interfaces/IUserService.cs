using WebApp.Models;

namespace WebApp.Interfaces
{
    public interface IUserService
    {
        public User GetUser(string userID);
    }
}
