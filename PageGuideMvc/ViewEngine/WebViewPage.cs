namespace PageGuideMvc.ViewEngine
{
    using System;
    using System.Configuration;
    using System.IO;
    using System.Web.Mvc;

    public abstract class WebViewPage<TModel> : System.Web.Mvc.WebViewPage<TModel>
    {
        public override string Layout
        {
            get
            {
                string layout = base.Layout;

                if (!string.IsNullOrEmpty(layout))
                {
                    string filename = Path.GetFileNameWithoutExtension(layout);
                    ViewEngineResult viewResult = ViewEngines.Engines.FindView(
                        ViewContext.Controller.ControllerContext, filename, "");

                    if (viewResult != null && (viewResult.View is RazorView))
                    {
                        layout = (viewResult.View as RazorView).ViewPath;
                    }
                }

                return layout;
            }
            set { base.Layout = value; }
        }

    }

    public abstract class WebViewPage : WebViewPage<dynamic>
    {
    }
}