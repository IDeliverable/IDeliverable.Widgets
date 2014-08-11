using Orchard.ContentManagement;
using Orchard.ContentManagement.Records;
using Orchard.Core.Common.Utilities;

namespace IDeliverable.Widgets.Models {
    public class AjaxWidgetPart : ContentPart<AjaxWidgetPartRecord> {
        internal LazyField<ContentItem> _selectedContentItemField = new LazyField<ContentItem>();

        public int? SelectedContentItemId {
            get { return Record.SelectedContentItemId; }
            set { Record.SelectedContentItemId = value; }
        }

        public ContentItem SelectedContentItem {
            get { return _selectedContentItemField.Value; }
            set { _selectedContentItemField.Value = value; }
        }

        public string DisplayType {
            get { return Record.DisplayType; }
            set { Record.DisplayType = value; }
        }
    }

    public class AjaxWidgetPartRecord : ContentPartRecord {
        public virtual int? SelectedContentItemId { get; set; }
        public virtual string DisplayType { get; set; }
    }
}