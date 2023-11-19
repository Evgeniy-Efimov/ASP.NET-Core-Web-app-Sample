using System;

namespace WebApp.Helpers
{
    public static class CommonHelper
    {
        public const string EmptyUrl = "~/";

        public static int IntegerDivision(int a, int b) => (int)Math.Ceiling((decimal)a / b);
    }
}
