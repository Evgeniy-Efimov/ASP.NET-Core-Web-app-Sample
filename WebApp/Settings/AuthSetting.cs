namespace WebApp.Settings
{
    public class AuthSetting
    {
        public static string SectionName = "AuthSetting";
        public string AuthorizedUserSessionKey { get; set; }
        public string RedirectUrlSessionKey { get; set; }
        public string LoginUrl { get; set; }
        public string DefaultDomain { get; set; }
        public int SessionTimeoutInMinutes { get; set; }
    }
}
