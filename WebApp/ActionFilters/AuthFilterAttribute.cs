using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using System.Linq;
using WebApp.Interfaces;
using WebApp.Settings;

namespace WebApp.ActionFilters
{
    public class AuthFilterAttribute : ActionFilterAttribute
    {
        private readonly IAuthService _authService;
        private readonly AuthSetting _authSetting;

        public AuthFilterAttribute(IOptions<AuthSetting> authSetting, IAuthService authService)
        {
            _authService = authService;
            _authSetting = authSetting.Value;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (IsAllowAnonymous(filterContext))
                return;

            var user = _authService.GetAuthorizedUser();

            if (user == null)
            {
                if (filterContext.HttpContext.Request.Method == HttpMethods.Get)
                {
                    var url = UriHelper.GetDisplayUrl(filterContext.HttpContext.Request);
                    _authService.SaveRedirectUrl(url);
                }

                filterContext.Result = new RedirectResult(_authSetting.LoginUrl);
                return;
            }

            if (filterContext.Controller is Controller controller)
            {
                controller.ViewBag.AuthorizedUser = user;
            }
        }

        private bool IsAllowAnonymous(ActionExecutingContext context) =>
            context.ActionDescriptor.EndpointMetadata.Any(x => x.GetType() == typeof(AllowAnonymousAttribute));
    }
}
