namespace PageGuide.Component
{
    #region Using

    using System.Web.Mvc;
    using Models;

    #endregion

    public class StepBuilder : BuilderBase
    {
        public StepBuilder(PageGuideBuilder pageGuideBuilder)
        {
            PageGuideBuilder = pageGuideBuilder;
            GuideStep = new Step();
        }

        private Step GuideStep { get; set; }

        private PageGuideBuilder PageGuideBuilder { get; set; }

        public virtual StepBuilder Content(string content)
        {
            GuideStep.content = content;
            return this;
        }

        public virtual void CreateStep()
        {
            PageGuideBuilder.Component.StepCollection.Add(GuideStep);
        }

        public virtual StepBuilder Direction(Direction direction)
        {
            GuideStep.direction = direction.ToString().ToLower();
            return this;
        }

        public virtual StepBuilder Target(string target)
        {
            GuideStep.target = target;
            return this;
        }
    }
}