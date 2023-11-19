using System.Drawing.Drawing2D;
using WebApp.Models;

namespace WebApp.Interfaces
{
    public interface IAuthService
    {
        public bool IsAuthenticated(AuthData authData);
        public void SaveRedirectUrl(string url);
        public string GetRedirectUrl();
        public AuthorizedUser GetAuthorizedUser();
        public bool IsAuthorized();
        public void Login(string userID);
        public void Logout();
        public bool IsDebugMode();
    }
}
