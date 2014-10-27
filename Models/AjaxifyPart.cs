using Orchard.ContentManagement;

namespace IDeliverable.Widgets.Models {
    public class AjaxifyPart : ContentPart {
        public bool Ajaxify {
            get { return this.Retrieve(x => x.Ajaxify); }
            set { this.Store(x => x.Ajaxify, value); }
        }

        public bool Cache {
            get { return this.Retrieve(x => x.Cache); }
            set { this.Store(x => x.Cache, value); }
        }
    }
}