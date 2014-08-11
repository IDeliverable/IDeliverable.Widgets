using Orchard.ContentManagement;
using Orchard.Core.Common.Utilities;

namespace IDeliverable.Widgets.Models {
    public class AjaxWidgetPart : ContentPart {
        internal LazyField<ContentItem> _selectedContentItemField = new LazyField<ContentItem>();

        public int? SelectedContentItemId {
            get { return this.Retrieve(x => x.SelectedContentItemId); }
            set { this.Store(x => x.SelectedContentItemId, value); }
        }

        public ContentItem SelectedContentItem {
            get { return _selectedContentItemField.Value; }
            set { _selectedContentItemField.Value = value; }
        }

        public string DisplayType {
            get { return this.Retrieve(x => x.DisplayType); }
            set { this.Store(x => x.DisplayType, value); }
        }
    }
}