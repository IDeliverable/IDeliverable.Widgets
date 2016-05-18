/// <reference path="typings/jquery/jquery.d.ts" />

module IDeliverable.AjaxWidget {
    $(function () {

        $(".widget-ajax-placeholder").each(function () {
            var placeholder: JQuery = $(this);
            var loader: JQuery = placeholder.find(".widget-ajax-loader");
            var errorLabel: JQuery = placeholder.find(".widget-ajax-error");
            var ajaxUrl: string = placeholder.data("widget-ajax-url");
            var parent: JQuery = placeholder.parent();

            if (ajaxUrl) {
                var update = function (url: string, target: JQuery) {
                    errorLabel.hide();
                    loader.show();
                    $.get(url, function (html) {
                        var newContent = $(html);
                        target.replaceWith(newContent);

                        // Process local urls, such as pager urls.
                        newContent.on("click", "a[href^='" + ajaxUrl + "']", function (e) {
                            update($(this).attr("href"), newContent);
                            e.preventDefault();
                        });
                    }).fail(function() {
                        errorLabel.show();
                        loader.hide();
                    });
                };

                update(ajaxUrl, parent); 
            }
        });
    });
}