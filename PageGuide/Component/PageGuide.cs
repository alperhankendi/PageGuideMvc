namespace PageGuide.Component
{
    #region Using

    using System.Collections.Generic;
    using System.Text;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Models;
    using Newtonsoft.Json;

    #endregion

    public class PageGuide
    {
        public PageGuide(ViewContext viewContext)
        {
            HtmlAttributes = new RouteValueDictionary();
            ViewContext = viewContext;
            StepCollection = new StepCollection();
        }

        public bool AutoStart { get; set; }

        public string Content { get; set; }

        public Direction Direction { get; set; }

        public string GuidePath { set; get; }

        public IDictionary<string, object> HtmlAttributes { get; private set; }

        public string Id
        {
            get { return HtmlAttributes.ContainsKey("id") ? (string) HtmlAttributes["id"] : Name; }
        }

        public string Name { get; set; }

        public StepCollection StepCollection { get; set; }

        public string Title { get; set; }

        public ViewContext ViewContext { get; private set; }

        public MvcHtmlString ToHtmlString()
        {
            var scriptHtml = new StringBuilder();
            scriptHtml.Append("<script>");
            scriptHtml.Append(@"var {0} = {{
                        id: 'jQuery.PageGuide',
                        title: '{1}',
                        steps: {2}
                        }}
                       
                     $(document).ready(function () {{
                           $.pageguide({0});
                       }});");

            scriptHtml.Append("</script>");
            var output = string.Format(scriptHtml.ToString(), Id, Title, JsonConvert.SerializeObject(StepCollection));
            return MvcHtmlString.Create(output);

            #region old

            //var routeValueDictionary = ViewContext.RequestContext.RouteData.Values;
            //var rootUrl = ViewContext.RequestContext.HttpContext.Server.MapPath("~/");
            //var pathhh = string.Format("{0}/Views/{1}/", rootUrl, routeValueDictionary["controller"]);

            //var idPrefix = ViewContext.RouteData.Values["controller"] + "-";
            //idPrefix = idPrefix.ToLower();

            //var partialViewName = Path.Combine(pathhh, routeValueDictionary["action"].ToString());

            //partialViewName = string.Format("{0}{1}.{2}.guide", pathhh, routeValueDictionary["action"], "tr-TR");

            //var content = string.Empty;

            //var builder = new TagBuilder("script");
            //builder.Attributes.Add("type", "text/javascript");
            //builder.InnerHtml = File.ReadAllText(partialViewName);
            //return MvcHtmlString.Create(builder.ToString());

            // string[] arr = null;
            // if (File.Exists(partialViewName))
            //     arr = File.ReadAllLines(partialViewName);

            // if (arr != null)
            // {
            //     content = arr.Aggregate(content, (current, str) => current + str);
            // }

            // if (!string.IsNullOrWhiteSpace(content))
            // {
            //     var script = @"var test = {\n
            //             id: 'jQuery.PageGuide',\n
            //             title: 'Title',\n
            //             steps: [\n";
            //     script += content + @"
            //                 ]\n
            //             }\n\n
            //             
            //           $(document).ready(function () {\n
            //                 $.pageguide(test);\n
            //             });\n";

            //     return MvcHtmlString.Create(script);
            // }
            // return null;

            #endregion
        }
    }
}