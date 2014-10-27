using System;

namespace IDeliverable.Widgets {
    public static class SignalKeys {
        public static string AjaxifiedContentItem(int contentItemId) {
            return String.Format("AjaxifiedContentItem-{0}", contentItemId);
        }
    }
}