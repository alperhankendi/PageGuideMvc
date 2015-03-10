namespace PageGuide.Component
{
    #region Using

    using System;
    using System.Web.Mvc;

    #endregion

    public class PageGuideBuilder
    {
        public PageGuideBuilder(PageGuide component)
        {
            Component = component;
        }

        protected internal PageGuide Component { get; set; }

        public virtual PageGuideBuilder AutoStart(bool autoStart)
        {
            Component.AutoStart = autoStart;

            return this;
        }

        public virtual PageGuideBuilder NewStep(Action<StepBuilder> step)
        {
            step(new StepBuilder(this));
            return this;
        }

        public virtual PageGuideBuilder SetName(string componentName)
        {
            Component.Name = componentName;

            return this;
        }

        public virtual PageGuideBuilder SetTitle(string title)
        {
            Component.Title = title;

            return this;
        }

        public virtual PageGuideBuilder UseCustomGuide()
        {
            Component.UseCustomPage = true;

            return this;
        }

        public virtual PageGuideBuilder SetLanguage(string language)
        {
            Component.Language = language;

            return this;
        }

        public PageGuide ToComponent()
        {
            return Component;
        }

        public override string ToString()
        {
            return ToComponent().ToHtmlString().ToString();
        }

    }
}