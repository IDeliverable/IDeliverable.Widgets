using System.Collections.Generic;

namespace IDeliverable.Widgets.Models
{
    public class OutputCachedWidgetModel
    {
        public OutputCachedWidgetModel()
        {
            RequiredResources = new List<ResourceRequiredModel>();
            IncludedResources = new List<ResourceIncludedModel>();
            FootScripts = new List<string>();
            HeadScripts = new List<string>();
        }

        public string Html { get; set; }
        public IEnumerable<ResourceRequiredModel> RequiredResources { get; set; }
        public IEnumerable<ResourceIncludedModel> IncludedResources { get; set; }
        public IList<string> FootScripts { get; set; }
        public IList<string> HeadScripts { get; set; }
    }
}