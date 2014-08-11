using IDeliverable.Widgets.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Handlers;
using Orchard.Environment.Extensions;

namespace IDeliverable.Widgets.Handlers {
    [OrchardFeature("IDeliverable.Widgets.Ajax")]
    public class AjaxWidgetPartHandler : ContentHandler {

        private readonly IContentManager _contentManager;

        public AjaxWidgetPartHandler(IContentManager contentManager) {
            _contentManager = contentManager;
            OnActivated<AjaxWidgetPart>(SetupLazyFields);
        }

        private void SetupLazyFields(ActivatedContentContext context, AjaxWidgetPart part) {
            part._selectedContentItemField.Loader(() => part.SelectedContentItemId != null ? _contentManager.Get(part.SelectedContentItemId.Value) : null);
            part._selectedContentItemField.Setter(x => {
                part.SelectedContentItemId = x != null ? x.Id : default(int?);
                return x;
            });
        }
    }
}