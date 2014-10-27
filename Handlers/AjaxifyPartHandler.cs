using IDeliverable.Widgets.Models;
using Orchard.Caching;
using Orchard.ContentManagement.Handlers;
using Orchard.Environment.Extensions;

namespace IDeliverable.Widgets.Handlers {
    [OrchardFeature("IDeliverable.Widgets.Ajax")]
    public class AjaxifyPartHandler : ContentHandler {
        private readonly ISignals _signals;

        public AjaxifyPartHandler(ISignals signals) {
            _signals = signals;
            OnPublished<AjaxifyPart>(EvictCache);
        }

        private void EvictCache(PublishContentContext context, AjaxifyPart part) {
            _signals.Trigger(SignalKeys.AjaxifiedContentItem(part.Id));
        }
    }
}