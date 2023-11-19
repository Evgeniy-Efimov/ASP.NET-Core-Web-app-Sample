using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.DirectoryServices.AccountManagement;
using System;
using WebApp.Interfaces;
using WebApp.Models;
using WebApp.Settings;
using WebApp.Helpers;
using System.Linq;

namespace WebApp.BLL
{
    /// <summary>
    /// Authentication service
    /// </summary>
    public class AuthService : IAuthService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AuthSetting _authSetting;
        private readonly IUserService _userService;

        public AuthService(IOptions<AuthSetting> authSetting, IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _authSetting = authSetting.Value;
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }

        private ISession Session { get { return _httpContextAccessor.HttpContext.Session; } }

        public bool IsDebugMode()
        {
#if DEBUG
            return true;
#endif
            return false;
        }

        public void SaveRedirectUrl(string url)
        {
            Session.SetValue(_authSetting.RedirectUrlSessionKey, url);
        }

        public string GetRedirectUrl() => Session.GetValue(_authSetting.RedirectUrlSessionKey) ?? CommonHelper.EmptyUrl;

        public AuthorizedUser GetAuthorizedUser() => Session.GetValue<AuthorizedUser>(_authSetting.AuthorizedUserSessionKey);

        public bool IsAuthorized() => GetAuthorizedUser() != null;

        public void Login(string userID)
        {
            var user = _userService.GetUser(userID);

            if (user == null)
                throw new ArgumentException($"User {userID} not found");

            var roleIds = user.Roles.Select(r => (short)r.Id).ToList();
            var authorizedUser = new AuthorizedUser
            {
                UserID = user.UserID,
                FirstName = user.FirstName,
                LastName = user.LastName,
                FullName = user.FullName,
                RoleIds = roleIds
            };
            Session.SetValue(_authSetting.AuthorizedUserSessionKey, authorizedUser);
        }

        public void Logout()
        {
            Session.Clear();
        }

        public bool IsAuthenticated(AuthData authData)
        {
            return IsDebugMode() ||
                (!string.IsNullOrWhiteSpace(authData.Login) &&
                !string.IsNullOrWhiteSpace(authData.Password) &&
                IsActiveUserExists(authData) &&
                IsDomainAuthenticated(authData));
        }

        private bool IsDomainAuthenticated(AuthData authData)
        {
            if (string.IsNullOrWhiteSpace(authData.Domain))
                authData.Domain = _authSetting.DefaultDomain;

            if (string.IsNullOrWhiteSpace(authData.Login))
                throw new ArgumentException("Login is empty");

            if (string.IsNullOrWhiteSpace(authData.Password))
                throw new ArgumentException("Password is empty");

            using (var context = new PrincipalContext(ContextType.Domain, authData.Domain))
            {
                return context.ValidateCredentials(authData.Login, authData.Password);
            }
        }

        private bool IsActiveUserExists(AuthData authData)
        {
            return _userService.GetUser(authData.Login)?.IsActive ?? false;
        }
    }
}
