/// <reference path="typings/jquery/jquery.d.ts" />

module IDeliverable.AjaxWidget {
    $(function () {

        $(".widget-ajax-placeholder").each(function () {
            var ajaxUrl = $(this).data("widget-ajax-url");
            var parent = $(this).parent();
            if (ajaxUrl) {

                var update = function(url, target) {
                    $.get(url, function (html) {
                        var newContent = $(html);
                        target.replaceWith(newContent);

                        // Process local urls, such as pager urls.
                        newContent.on("click", "a[href^='" + ajaxUrl + "']", function (e) {
                            update($(this).attr("href"), newContent);
                            e.preventDefault();
                        });
                    });
                };

                update(ajaxUrl, parent); 
            }
        });
    });
}