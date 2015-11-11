using IDeliverable.Widgets.Models;
using Orchard.Caching;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Handlers;
using Orchard.Core.Navigation.Models;
using Orchard.Environment.Extensions;

namespace IDeliverable.Widgets.Handlers
{
    [OrchardFeature("IDeliverable.Widgets.OutputCache")]
    public class MenuWidgetOutputCachePartHandler : ContentHandler
    {
        private readonly ISignals _signals;
        private readonly IContentManager _contentManager;

        public MenuWidgetOutputCachePartHandler(ISignals signals, IContentManager contentManager)
        {
            _signals = signals;
            _contentManager = contentManager;

            OnCreated<MenuPart>(EvictMenuWidgetCaches);
            OnUpdated<MenuPart>(EvictMenuWidgetCaches);
            OnRemoving<MenuPart>(EvictMenuWidgetCaches);
        }

        private void EvictMenuWidgetCaches(ContentContextBase context, MenuPart part)
        {
            if (context.Id == 0)
            {
                return;
            }

            // Get all the menu widgets who's menu contains this Menu Item, but only if the Output Cache Part has been bound to that Content Type
            var menuWidgetOutputCacheParts = _contentManager.Query<OutputCachePart>().ForType("MenuWidget").List();

            foreach (var outputCachePart in menuWidgetOutputCacheParts)
            {
                var menuWidgetPart = outputCachePart.ContentItem.As<MenuWidgetPart>();

                if (menuWidgetPart != null && menuWidgetPart.MenuContentItemId == part.Menu.Id)
                {
                    _signals.Trigger(OutputCachePart.ContentSignalName(menuWidgetPart.Id));
                }
            }
        }
    }
}