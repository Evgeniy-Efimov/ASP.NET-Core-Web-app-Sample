using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Helpers;
using WebApp.Interfaces;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            if (!_authService.IsAuthorized())
            {
                if (_authService.IsDebugMode())
                {
                    return View(new AuthDataViewModel() { Login = "WEBAPPDEV", Password = "4221:P" });
                }
                else
                {
                    return View();
                }
            }

            return Redirect(CommonHelper.EmptyUrl);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(AuthDataViewModel authDataViewModel)
        {
            try
            {
                if (!_authService.IsAuthorized())
                {
                    var authData = authDataViewModel.GetAuthData();

                    if (!_authService.IsAuthenticated(authData))
                    {
                        ModelState.AddModelError(string.Empty, "Invalid Login or Password");
                        ModelState.AddModelError("Login", string.Empty);
                        ModelState.AddModelError("Password", string.Empty);
                        return View(authDataViewModel);
                    }

                    _authService.Login(authData.Login);
                    return Redirect(_authService.GetRedirectUrl());
                }
            }
            catch
            {
                ModelState.AddModelError(string.Empty, $"An authentication error has occurred");
                return View(authDataViewModel);
            }

            return Redirect(CommonHelper.EmptyUrl);
        }

        [AllowAnonymous]
        public IActionResult Logout()
        {
            _authService.Logout();
            return Redirect(CommonHelper.EmptyUrl);
        }
    }
}
