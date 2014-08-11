/// <reference path="typings/jquery/jquery.d.ts" />
var IDeliverable;
(function (IDeliverable) {
    (function (AjaxWidget) {
        $(function () {
            $(".widget-ajax-placeholder").each(function () {
                var ajaxUrl = $(this).data("widget-ajax-url");
                var parent = $(this).parent();
                if (ajaxUrl) {
                    $.get(ajaxUrl, function (data) {
                        parent.replaceWith(data);
                    });
                }
            });
        });
    })(IDeliverable.AjaxWidget || (IDeliverable.AjaxWidget = {}));
    var AjaxWidget = IDeliverable.AjaxWidget;
})(IDeliverable || (IDeliverable = {}));
//# sourceMappingURL=ajaxify.js.map
