using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.Helpers;

namespace WebApp.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet]
        [HttpPost]
        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Index(string statusCode)
        {
            var requestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
            return View(ErrorHelper.GetErrorViewModel(requestId, exception, statusCode));
        }
    }
}
