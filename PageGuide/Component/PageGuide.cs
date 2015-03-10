namespace PageGuide.Component
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
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
            get { return HtmlAttributes.ContainsKey("id") ? (string)HtmlAttributes["id"] : Name; }
        }

        public string Name { get; set; }

        public StepCollection StepCollection { get; set; }

        public string Title { get; set; }

        public string Language { get; set; }

        public ViewContext ViewContext { get; private set; }

        public bool UseCustomPage { get; set; }

        public MvcHtmlString ToHtmlString()
        {
            if (StepCollection.Any() && UseCustomPage == false)
            {
                var scriptBuilder = new TagBuilder("script");
                scriptBuilder.Attributes.Add("type", "text/javascript");
                scriptBuilder.InnerHtml = @"var {0} = {{
                        id: 'jQuery.PageGuide',
                        title: '{1}',
                        steps: {2}
                        }}
                       
                     $(document).ready(function () {{
                           $.pageguide({0});
                       }});";

                var output = string.Format(scriptBuilder.ToString(), Id, Title, JsonConvert.SerializeObject(StepCollection));
                return MvcHtmlString.Create(output);
            }

            if (UseCustomPage)
            {
                if (string.IsNullOrEmpty(Language))
                {
                    throw new Exception("Language was not set, If you are using custom guide, you must set langage.");
                }

                var routeValueDictionary = ViewContext.RequestContext.RouteData.Values;
                var rootUrl = ViewContext.RequestContext.HttpContext.Server.MapPath("~/");
                var path = string.Format("{0}/Views/{1}/", rootUrl, routeValueDictionary["controller"]);
                var partialViewName = string.Format("{0}{1}.{2}.guide", path, routeValueDictionary["action"], Language);

                if (!File.Exists(partialViewName))
                {
                    throw new Exception("Your custom guide was not able to find, please check the path or file.");
                }

                var builder = new TagBuilder("script");
                builder.Attributes.Add("type", "text/javascript");
                builder.InnerHtml = File.ReadAllText(partialViewName);
                return MvcHtmlString.Create(builder.ToString());
            }

            return new MvcHtmlString(string.Empty);
        }
    }
}