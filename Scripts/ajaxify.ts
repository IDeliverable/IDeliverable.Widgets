/// <reference path="typings/jquery/jquery.d.ts" />

module IDeliverable.AjaxWidget {
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
}
