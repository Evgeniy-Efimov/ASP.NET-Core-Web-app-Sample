using System.Collections.Generic;
using System;
using WebApp.ViewModels;

namespace WebApp.Helpers
{
    public static class ErrorHelper
    {
        private static Dictionary<string, string> statusCodeDescription = new Dictionary<string, string>()
        {
            { "401", "You do not have acccess to this page" },
            { "403", "Action is forbidden" },
            { "404", "Page could not be found" },
            { "405", "Method is not allowed" },
            { "500", "Internal server error" },
            { "503", "Service is unavailable" },
            { "504", "Gateway timeout" }
        };

        public static ErrorViewModel GetErrorViewModel(string requestId, Exception exception, string statusCode)
        {
            return new ErrorViewModel()
            {
                Message = statusCodeDescription.GetValueOrDefault(statusCode ?? string.Empty, string.Empty),
                Details = exception?.Message ?? string.Empty,
                RequestId = requestId
            };
        }
    }
}
