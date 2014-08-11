using System.Linq;
using IDeliverable.Widgets.Models;
using IDeliverable.Widgets.ViewModels;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.Environment.Extensions;
using Orchard.Widgets.Models;

namespace IDeliverable.Widgets.Drivers {
    [OrchardFeature("IDeliverable.Widgets.Ajax")]
    public class AjaxWidgetPartDriver : ContentPartDriver<AjaxWidgetPart> {

        private readonly IContentManager _contentManager;
        
        public AjaxWidgetPartDriver(IContentManager contentManager) {
            _contentManager = contentManager;
        }

        protected override DriverResult Display(AjaxWidgetPart part, string displayType, dynamic shapeHelper) {
            return ContentShape("Parts_AjaxWidget", () => shapeHelper.Parts_AjaxWidget());
        }

        protected override DriverResult Editor(AjaxWidgetPart part, dynamic shapeHelper) {
            return Editor(part, null, shapeHelper);
        }

        protected override DriverResult Editor(AjaxWidgetPart part, IUpdateModel updater, dynamic shapeHelper) {
            return ContentShape("Parts_AjaxWidget_Edit", () => {
                var viewModel = new AjaxWidgetPartEditViewModel {
                    SelectedWidgetId = part.SelectedContentItemId,
                    AvailableWidgets = _contentManager.Query(VersionOptions.Published).Join<WidgetPartRecord>().List<WidgetPart>().ToArray()
                };

                if (updater != null) {
                    if (updater.TryUpdateModel(viewModel, Prefix, null, new[] {"AvailableWidgets"})) {
                        part.SelectedContentItemId = viewModel.SelectedWidgetId.Value;
                        part.DisplayType = viewModel.DisplayType;
                    }
                }

                return shapeHelper.EditorTemplate(TemplateName: "Parts.AjaxWidget", Model: viewModel, Prefix: Prefix);
            });
        }
    }
}