using System.Web.Mvc;
using IDeliverable.Widgets.Models;
using Orchard.Caching;
using Orchard.ContentManagement;
using Orchard.DisplayManagement;
using Orchard.Environment.Extensions;

namespace IDeliverable.Widgets.Controllers {
    [OrchardFeature("IDeliverable.Widgets.Ajax")]
    public class AjaxController : Controller {

        private readonly IContentManager _contentManager;
        private readonly IShapeDisplay _shapeDisplay;
        private readonly ICacheManager _cacheManager;
        private readonly ISignals _signals;

        public AjaxController(IContentManager contentManager, IShapeDisplay shapeDisplay, ICacheManager cacheManager, ISignals signals) {
            _contentManager = contentManager;
            _shapeDisplay = shapeDisplay;
            _cacheManager = cacheManager;
            _signals = signals;
        }

        public ActionResult Display(int id, string displayType = null) {
            var contentItem = _contentManager.Get(id);

            if (contentItem == null)
                return HttpNotFound();

            var ajaxifyPart = contentItem.As<AjaxifyPart>();
            string output;
            
            if (ajaxifyPart.Cache) {
                output = _cacheManager.Get(SignalKeys.AjaxifiedContentItem(id), context => {
                    context.Monitor(_signals.When(SignalKeys.AjaxifiedContentItem(id)));
                    return RenderContentItem(contentItem, displayType);
                });
            }
            else {
                output = RenderContentItem(contentItem, displayType);
            }

            return Content(output, "text/html");
        }

        private string RenderContentItem(ContentItem contentItem, string displayType) {
            var shape = _contentManager.BuildDisplay(contentItem, displayType ?? "");
            shape.Ajaxified = true;
            return _shapeDisplay.Display(shape);
        }
    }
}