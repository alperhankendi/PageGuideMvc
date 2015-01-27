namespace PageGuideMvc.Extension
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Web.Mvc;
    public static class StringExtensions
    {
        private static ConcurrentDictionary<string, IEnumerable<string>> fileListCache = new ConcurrentDictionary<string, IEnumerable<string>>();

        public static MvcHtmlString PageGuide(this HtmlHelper helper)
        {
            return helper.RenderGuideTemplates();
        }

        public static MvcHtmlString RenderGuideTemplates(this HtmlHelper helper,string languageCode="tr-TR")
        {
            var routeValueDictionary = helper.ViewContext.RequestContext.RouteData.Values;
            var rootUrl = helper.ViewContext.RequestContext.HttpContext.Server.MapPath("~/");

            var pathhh = string.Format("{0}/Views/{1}/", rootUrl, routeValueDictionary["controller"]);

            IEnumerable<string> fileList;

            if (!fileListCache.TryGetValue(pathhh + routeValueDictionary["action"], out fileList))
            {
                fileList = Directory.GetFiles(pathhh,
                    string.Format("{0}.{1}.guide", routeValueDictionary["action"] , languageCode)
                    );

                fileListCache.GetOrAdd(pathhh + routeValueDictionary["action"], fileList);
            }

            var idPrefix = helper.ViewContext.RouteData.Values["controller"] + "-";
            idPrefix = idPrefix.ToLower();

            var result = string.Join("\n",
                    fileList.Select(x => RenderTemplateToString(idPrefix +x.ToLower(), Path.Combine(pathhh, x))).ToArray()
                );

            return new MvcHtmlString(result);
        }

        private static string RenderTemplateToString(string templateId, string partialViewName)
        {
            string content = string.Empty;
            if (File.Exists(partialViewName))
                content =  File.ReadAllText(partialViewName);

            return !string.IsNullOrWhiteSpace(content) ? string.Format("<script language=\"javascript\" id=\"pageguide-{0}\">{1}</script>", Guid.NewGuid().ToString().ToLower(), content) : null;
        }
    }
}