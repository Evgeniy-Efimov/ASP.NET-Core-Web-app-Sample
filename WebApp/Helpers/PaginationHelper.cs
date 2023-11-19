using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using System;
using System.Linq;

namespace WebApp.Helpers
{
    public static class PaginationHelper
    {
        private static int LinksPerSegment { get { return SettingHelper.PaginationSetting.PageLinksPerSegment; } }
        private static string FirstPageLinkName { get { return SettingHelper.PaginationSetting.FirstPageLinkName; } }
        private static string SegmentLinkName { get { return SettingHelper.PaginationSetting.SegmentLinkName; } }

        public static HtmlString GetPaginator(this IHtmlHelper html, string action,
            object searchObject, string searchObjectEditView, int page, int totalPages)
        {
            if (totalPages <= 1)
            {
                return HtmlString.Empty;
            }

            var links = new List<KeyValuePair<int, string>>();
            var segmentNumber = CommonHelper.IntegerDivision(page, LinksPerSegment);

            //if pages segment isn't frist - create links to previous
            if (segmentNumber > 1)
            {
                links.Add(new KeyValuePair<int, string>(1, FirstPageLinkName));
                var previousSegmentPageNumber = (segmentNumber - 1) * LinksPerSegment;
                links.Add(new KeyValuePair<int, string>(previousSegmentPageNumber, SegmentLinkName));
            }

            //current segment links
            for (var i = (segmentNumber - 1) * LinksPerSegment + 1; i <= Math.Min(segmentNumber * LinksPerSegment, totalPages); i++)
            {
                links.Add(new KeyValuePair<int, string>(i, i.ToString()));
            }

            //if pages segment isn't last - create links to next
            if (segmentNumber < CommonHelper.IntegerDivision(totalPages, LinksPerSegment))
            {
                var nextSegmentPageNumber = segmentNumber * LinksPerSegment + 1;
                links.Add(new KeyValuePair<int, string>(nextSegmentPageNumber, SegmentLinkName));
                links.Add(new KeyValuePair<int, string>(totalPages, totalPages.ToString()));
            }

            var paginatorForm = new TagBuilder("form");
            paginatorForm.Attributes.Add("action", action);
            paginatorForm.Attributes.Add("method", "post");

            var paginatorContainer = new TagBuilder("div");
            paginatorContainer.AddCssClass("paginator");

            var editFormContainer = new TagBuilder("div");
            editFormContainer.AddCssClass("hidden");

            var modelEditForm = html.PartialAsync(searchObjectEditView, searchObject).Result;

            var linksContainer = new TagBuilder("div");
            linksContainer.AddCssClass("pages");

            var linksList = new TagBuilder("ul");
            foreach (var link in links.OrderBy(o => o.Key))
            {
                linksList.InnerHtml.AppendHtml(GetPageLink(link, page == link.Key));
            }

            linksContainer.InnerHtml.AppendHtml(linksList);
            paginatorContainer.InnerHtml.AppendHtml(linksContainer);
            editFormContainer.InnerHtml.AppendHtml(modelEditForm);
            paginatorContainer.InnerHtml.AppendHtml(editFormContainer);
            paginatorForm.InnerHtml.AppendHtml(paginatorContainer);

            var writer = new System.IO.StringWriter();
            paginatorForm.WriteTo(writer, HtmlEncoder.Default);
            return new HtmlString(writer.ToString());
        }

        private static HtmlString GetPageLink(KeyValuePair<int, string> pageLink, bool isCurrentPage = false)
        {
            var pageLiTag = new TagBuilder("li");
            pageLiTag.AddCssClass(isCurrentPage ? "page-current" : string.Empty);

            var pageButton = new TagBuilder("button");
            pageButton.Attributes.Add("name", "page");
            pageButton.Attributes.Add("value", pageLink.Key.ToString());
            pageButton.Attributes.Add("type", "submit");

            if (isCurrentPage)
                pageButton.Attributes.Add("disabled", "disabled");

            pageButton.InnerHtml.Append(pageLink.Value);
            pageLiTag.InnerHtml.AppendHtml(pageButton);

            var writer = new System.IO.StringWriter();
            pageLiTag.WriteTo(writer, HtmlEncoder.Default);
            return new HtmlString(writer.ToString());
        }
    }
}
