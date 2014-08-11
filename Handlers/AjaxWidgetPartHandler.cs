using IDeliverable.Widgets.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Orchard.Environment.Extensions;

namespace IDeliverable.Widgets.Handlers {
    [OrchardFeature("IDeliverable.Widgets.Ajax")]
    public class AjaxWidgetPartHandler : ContentHandler {

        private readonly IContentManager _contentManager;

        public AjaxWidgetPartHandler(IRepository<AjaxWidgetPartRecord> repository, IContentManager contentManager) {
            _contentManager = contentManager;
            Filters.Add(StorageFilter.For(repository));
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