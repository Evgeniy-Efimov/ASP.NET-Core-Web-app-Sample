namespace WebApp.Settings
{
    public class PaginationSetting
    {
        public static string SectionName = "PaginationSetting";
        public byte PageRowsCount { get; set; }
        public int PageLinksPerSegment { get; set; }
        public int DefaultPage { get; set; }
        public string SegmentLinkName { get; set; }
        public string FirstPageLinkName { get; set; }
    }
}
