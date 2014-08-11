using IDeliverable.Widgets.Models;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Orchard.Environment.Extensions;

namespace IDeliverable.Widgets.Handlers {
    [OrchardFeature("IDeliverable.Widgets.Ajax")]
    public class AjaxifyPartHandler : ContentHandler {
        public AjaxifyPartHandler(IRepository<AjaxifyPartRecord> repository) {
            Filters.Add(StorageFilter.For(repository));
        }
    }
}