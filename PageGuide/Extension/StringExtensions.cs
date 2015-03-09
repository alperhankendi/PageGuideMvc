namespace System.Web.Mvc
{
    #region Using

    using ComponentModel;
    using PageGuide.Component;

    #endregion

    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IHideObjectMembers
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool Equals(object value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        int GetHashCode();

        [EditorBrowsable(EditorBrowsableState.Never)]
        Type GetType();

        [EditorBrowsable(EditorBrowsableState.Never)]
        string ToString();
    }

    public static class HtmlHelperExtension
    {
        public static ComponentFactory PayFlex(this HtmlHelper helper)
        {
            return new ComponentFactory(helper);
        }

        public static IHtmlString Raw(this object value)
        {
            return new HtmlString(value == null ? null : value.ToString());
        }
    }

    public class ComponentFactory : IHideObjectMembers
    {
        private readonly HtmlHelper helper;

        public ComponentFactory(HtmlHelper helper)
        {
            this.helper = helper;
        }

        private ViewContext ViewContext
        {
            get { return helper.ViewContext; }
        }

        public virtual PageGuideBuilder PageGuide()
        {
            return new PageGuideBuilder(new PageGuide(ViewContext));
        }
    }

    //    public static class StringExtensions
    //    {

    //        private static ConcurrentDictionary<string, IEnumerable<string>> fileListCache = new ConcurrentDictionary<string, IEnumerable<string>>();


    //        //public static MvcHtmlString PageGuide(this HtmlHelper helper,string title ="Page guide")
    //        //{
    //        //    return RenderGuideTemplates(helper,title);
    //        //}

    //        private static MvcHtmlString RenderGuideTemplates(HtmlHelper helper,string title,string languageCode="tr-TR")
    //        {
    //            var routeValueDictionary = helper.ViewContext.RequestContext.RouteData.Values;
    //            var rootUrl = helper.ViewContext.RequestContext.HttpContext.Server.MapPath("~/");

    //            var pathhh = string.Format("{0}/Views/{1}/", rootUrl, routeValueDictionary["controller"]);

    //            IEnumerable<string> fileList;

    //            if (!fileListCache.TryGetValue(pathhh + routeValueDictionary["action"], out fileList))
    //            {
    //                fileList = Directory.GetFiles(pathhh,
    //                    string.Format("{0}.{1}.guide", routeValueDictionary["action"] , languageCode)
    //                    );

    //                fileListCache.GetOrAdd(pathhh + routeValueDictionary["action"], fileList);
    //            }

    //            var idPrefix = helper.ViewContext.RouteData.Values["controller"] + "-";
    //            idPrefix = idPrefix.ToLower();

    //            var result = string.Join("\n",
    //                    fileList.Select(x => RenderTemplateToString(idPrefix +x.ToLower(), Path.Combine(pathhh, x))).ToArray()
    //                );

    //            return new MvcHtmlString(result);
    //        }

    //        private static string RenderTemplateToString(string templateId, string partialViewName)
    //        {
    //            string content = string.Empty;

    //            string[] arr = null;
    //            if (File.Exists(partialViewName))
    //                arr =  File.ReadAllLines(partialViewName);

    //            if (arr != null)
    //            {
    //                content = arr.Aggregate(content, (current, str) => current + str);
    //            }

    //            if (string.IsNullOrWhiteSpace(content))
    //            {
    //                var script = @"var {0} = {\n
    //                        id: 'jQuery.PageGuide',\n
    //                        title: '{1}',\n
    //                        steps: [\n
    //                            {1}\n
    //                            ]\n
    //                        }\n\n
    //                        
    //                      $(document).ready(function () {\n
    //                            $.pageguide({0});\n
    //                        });\n";

    //                return string.Format(script, templateId,partialViewName);
    //            }
    //            else
    //            {
    //                return null;
    //            }


    //            //return !string.IsNullOrWhiteSpace(content) ? string.Format("<script language=\"javascript\" id=\"pageguide-{0}\">\n{1}\n{2}</script>", Guid.NewGuid().ToString().ToLower(), content,
    //            //    "$(document).ready(function () {$.pageguide(guide);});") : null;
    //        }

    //    }
}