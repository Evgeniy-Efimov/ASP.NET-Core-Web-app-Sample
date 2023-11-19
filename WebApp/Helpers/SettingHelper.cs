using WebApp.Settings;

namespace WebApp.Helpers
{
    public static class SettingHelper
    {
        public static AuthSetting AuthSetting { get; private set; }
        public static PaginationSetting PaginationSetting { get; private set; }

        public static void Initialize(AuthSetting authSetting, PaginationSetting paginationSetting)
        {
            AuthSetting = authSetting;
            PaginationSetting = paginationSetting;
        }
    }
}
