using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Orchard.Widgets.Models;

namespace IDeliverable.Widgets.ViewModels {
    public class AjaxWidgetPartEditViewModel {
        [Required]
        public int? SelectedWidgetId { get; set; }
        public string DisplayType { get; set; }
        public IList<WidgetPart> AvailableWidgets { get; set; }
    }
}