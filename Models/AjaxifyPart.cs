using Orchard.ContentManagement;
using Orchard.ContentManagement.Records;

namespace IDeliverable.Widgets.Models {
    public class AjaxifyPart : ContentPart<AjaxifyPartRecord> {
        public bool Ajaxify {
            get { return Record.Ajaxify; }
            set { Record.Ajaxify = value; }
        }
    }

    public class AjaxifyPartRecord : ContentPartRecord {
        public virtual bool Ajaxify { get; set; }
    }
}