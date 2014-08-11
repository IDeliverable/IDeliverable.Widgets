using IDeliverable.Widgets.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.Environment.Extensions;

namespace IDeliverable.Widgets.Drivers {
    [OrchardFeature("IDeliverable.Widgets.Ajax")]
    public class AjaxifyPartDriver : ContentPartDriver<AjaxifyPart> {
        
        protected override DriverResult Editor(AjaxifyPart part, dynamic shapeHelper) {
            return Editor(part, null, shapeHelper);
        }

        protected override DriverResult Editor(AjaxifyPart part, IUpdateModel updater, dynamic shapeHelper) {
            return ContentShape("Parts_Ajaxify_Edit", () => {
                if (updater != null) {
                    updater.TryUpdateModel(part, Prefix, null, null);
                }

                return shapeHelper.EditorTemplate(TemplateName: "Parts.Ajaxify", Model: part, Prefix: Prefix);
            });
        }
    }
}