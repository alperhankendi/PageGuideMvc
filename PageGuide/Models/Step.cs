namespace PageGuide.Models
{
    #region Using

    using System.Collections.Generic;

    #endregion

    public class Step
    {
        public string target { get; set; }

        public string content { get; set; }

        public string direction { get; set; }
    }

    public class StepCollection : List<Step>
    {
        public StepCollection()
        {
        }

        public StepCollection(int capacity)
            : base(capacity)
        {
        }

        public StepCollection(IEnumerable<Step> list)
            : base(list)
        {
        }
    }
}