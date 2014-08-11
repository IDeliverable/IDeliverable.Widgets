using System.Web.Mvc;
using Orchard.ContentManagement;
using Orchard.Environment.Extensions;
using Orchard.Mvc;

namespace IDeliverable.Widgets.Controllers {
    [OrchardFeature("IDeliverable.Widgets.Ajax")]
    public class AjaxController : Controller {

        private readonly IContentManager _contentManager;

        public AjaxController(IContentManager contentManager) {
            _contentManager = contentManager;
        }

        public ActionResult Display(int id, string displayType = null) {
            var contentItem = _contentManager.Get(id);

            if (contentItem == null)
                return HttpNotFound();

            var shape = _contentManager.BuildDisplay(contentItem, displayType ?? "");
            shape.Ajaxified = true;

            return new ShapePartialResult(this, shape);
        }
    }
}