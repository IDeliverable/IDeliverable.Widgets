/// <reference path="typings/jquery/jquery.d.ts" />
var IDeliverable;
(function (IDeliverable) {
    var AjaxWidget;
    (function (AjaxWidget) {
        $(function () {
            $(".widget-ajax-placeholder").each(function () {
                var placeholder = $(this);
                var loader = placeholder.find(".widget-ajax-loader");
                var errorLabel = placeholder.find(".widget-ajax-error");
                var ajaxUrl = placeholder.data("widget-ajax-url");
                var parent = placeholder.parent();
                if (ajaxUrl) {
                    var update = function (url, target) {
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
                        }).fail(function () {
                            errorLabel.show();
                            loader.hide();
                        });
                    };
                    update(ajaxUrl, parent);
                }
            });
        });
    })(AjaxWidget = IDeliverable.AjaxWidget || (IDeliverable.AjaxWidget = {}));
})(IDeliverable || (IDeliverable = {}));

//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbImFqYXhpZnkudHMiXSwibmFtZXMiOlsiSURlbGl2ZXJhYmxlIiwiSURlbGl2ZXJhYmxlLkFqYXhXaWRnZXQiXSwibWFwcGluZ3MiOiJBQUFBLG1EQUFtRDtBQUVuRCxJQUFPLFlBQVksQ0FpQ2xCO0FBakNELFdBQU8sWUFBWTtJQUFDQSxJQUFBQSxVQUFVQSxDQWlDN0JBO0lBakNtQkEsV0FBQUEsVUFBVUEsRUFBQ0EsQ0FBQ0E7UUFDNUJDLENBQUNBLENBQUNBO1lBRUUsQ0FBQyxDQUFDLDBCQUEwQixDQUFDLENBQUMsSUFBSSxDQUFDO2dCQUMvQixJQUFJLFdBQVcsR0FBRyxDQUFDLENBQUMsSUFBSSxDQUFDLENBQUM7Z0JBQzFCLElBQUksTUFBTSxHQUFHLFdBQVcsQ0FBQyxJQUFJLENBQUMscUJBQXFCLENBQUMsQ0FBQztnQkFDckQsSUFBSSxVQUFVLEdBQUcsV0FBVyxDQUFDLElBQUksQ0FBQyxvQkFBb0IsQ0FBQyxDQUFDO2dCQUN4RCxJQUFJLE9BQU8sR0FBRyxXQUFXLENBQUMsSUFBSSxDQUFDLGlCQUFpQixDQUFDLENBQUM7Z0JBQ2xELElBQUksTUFBTSxHQUFHLFdBQVcsQ0FBQyxNQUFNLEVBQUUsQ0FBQztnQkFFbEMsRUFBRSxDQUFDLENBQUMsT0FBTyxDQUFDLENBQUMsQ0FBQztvQkFDVixJQUFJLE1BQU0sR0FBRyxVQUFVLEdBQUcsRUFBRSxNQUFNO3dCQUM5QixVQUFVLENBQUMsSUFBSSxFQUFFLENBQUM7d0JBQ2xCLE1BQU0sQ0FBQyxJQUFJLEVBQUUsQ0FBQzt3QkFDZCxDQUFDLENBQUMsR0FBRyxDQUFDLEdBQUcsRUFBRSxVQUFVLElBQUk7NEJBQ3JCLElBQUksVUFBVSxHQUFHLENBQUMsQ0FBQyxJQUFJLENBQUMsQ0FBQzs0QkFDekIsTUFBTSxDQUFDLFdBQVcsQ0FBQyxVQUFVLENBQUMsQ0FBQzs0QkFFL0IsMENBQTBDOzRCQUMxQyxVQUFVLENBQUMsRUFBRSxDQUFDLE9BQU8sRUFBRSxXQUFXLEdBQUcsT0FBTyxHQUFHLElBQUksRUFBRSxVQUFVLENBQUM7Z0NBQzVELE1BQU0sQ0FBQyxDQUFDLENBQUMsSUFBSSxDQUFDLENBQUMsSUFBSSxDQUFDLE1BQU0sQ0FBQyxFQUFFLFVBQVUsQ0FBQyxDQUFDO2dDQUN6QyxDQUFDLENBQUMsY0FBYyxFQUFFLENBQUM7NEJBQ3ZCLENBQUMsQ0FBQyxDQUFDO3dCQUNQLENBQUMsQ0FBQyxDQUFDLElBQUksQ0FBQzs0QkFDSixVQUFVLENBQUMsSUFBSSxFQUFFLENBQUM7NEJBQ2xCLE1BQU0sQ0FBQyxJQUFJLEVBQUUsQ0FBQzt3QkFDbEIsQ0FBQyxDQUFDLENBQUM7b0JBQ1AsQ0FBQyxDQUFDO29CQUVGLE1BQU0sQ0FBQyxPQUFPLEVBQUUsTUFBTSxDQUFDLENBQUM7Z0JBQzVCLENBQUM7WUFDTCxDQUFDLENBQUMsQ0FBQztRQUNQLENBQUMsQ0FBQ0EsQ0FBQ0E7SUFDUEEsQ0FBQ0EsRUFqQ21CRCxVQUFVQSxHQUFWQSx1QkFBVUEsS0FBVkEsdUJBQVVBLFFBaUM3QkE7QUFBREEsQ0FBQ0EsRUFqQ00sWUFBWSxLQUFaLFlBQVksUUFpQ2xCIiwiZmlsZSI6ImFqYXhpZnkuanMiLCJzb3VyY2VzQ29udGVudCI6WyIvLy8gPHJlZmVyZW5jZSBwYXRoPVwidHlwaW5ncy9qcXVlcnkvanF1ZXJ5LmQudHNcIiAvPlxyXG5cclxubW9kdWxlIElEZWxpdmVyYWJsZS5BamF4V2lkZ2V0IHtcclxuICAgICQoZnVuY3Rpb24gKCkge1xyXG5cclxuICAgICAgICAkKFwiLndpZGdldC1hamF4LXBsYWNlaG9sZGVyXCIpLmVhY2goZnVuY3Rpb24gKCkge1xyXG4gICAgICAgICAgICB2YXIgcGxhY2Vob2xkZXIgPSAkKHRoaXMpO1xyXG4gICAgICAgICAgICB2YXIgbG9hZGVyID0gcGxhY2Vob2xkZXIuZmluZChcIi53aWRnZXQtYWpheC1sb2FkZXJcIik7XHJcbiAgICAgICAgICAgIHZhciBlcnJvckxhYmVsID0gcGxhY2Vob2xkZXIuZmluZChcIi53aWRnZXQtYWpheC1lcnJvclwiKTtcclxuICAgICAgICAgICAgdmFyIGFqYXhVcmwgPSBwbGFjZWhvbGRlci5kYXRhKFwid2lkZ2V0LWFqYXgtdXJsXCIpO1xyXG4gICAgICAgICAgICB2YXIgcGFyZW50ID0gcGxhY2Vob2xkZXIucGFyZW50KCk7XHJcblxyXG4gICAgICAgICAgICBpZiAoYWpheFVybCkge1xyXG4gICAgICAgICAgICAgICAgdmFyIHVwZGF0ZSA9IGZ1bmN0aW9uICh1cmwsIHRhcmdldCkge1xyXG4gICAgICAgICAgICAgICAgICAgIGVycm9yTGFiZWwuaGlkZSgpO1xyXG4gICAgICAgICAgICAgICAgICAgIGxvYWRlci5zaG93KCk7XHJcbiAgICAgICAgICAgICAgICAgICAgJC5nZXQodXJsLCBmdW5jdGlvbiAoaHRtbCkge1xyXG4gICAgICAgICAgICAgICAgICAgICAgICB2YXIgbmV3Q29udGVudCA9ICQoaHRtbCk7XHJcbiAgICAgICAgICAgICAgICAgICAgICAgIHRhcmdldC5yZXBsYWNlV2l0aChuZXdDb250ZW50KTtcclxuXHJcbiAgICAgICAgICAgICAgICAgICAgICAgIC8vIFByb2Nlc3MgbG9jYWwgdXJscywgc3VjaCBhcyBwYWdlciB1cmxzLlxyXG4gICAgICAgICAgICAgICAgICAgICAgICBuZXdDb250ZW50Lm9uKFwiY2xpY2tcIiwgXCJhW2hyZWZePSdcIiArIGFqYXhVcmwgKyBcIiddXCIsIGZ1bmN0aW9uIChlKSB7XHJcbiAgICAgICAgICAgICAgICAgICAgICAgICAgICB1cGRhdGUoJCh0aGlzKS5hdHRyKFwiaHJlZlwiKSwgbmV3Q29udGVudCk7XHJcbiAgICAgICAgICAgICAgICAgICAgICAgICAgICBlLnByZXZlbnREZWZhdWx0KCk7XHJcbiAgICAgICAgICAgICAgICAgICAgICAgIH0pO1xyXG4gICAgICAgICAgICAgICAgICAgIH0pLmZhaWwoZnVuY3Rpb24oKSB7XHJcbiAgICAgICAgICAgICAgICAgICAgICAgIGVycm9yTGFiZWwuc2hvdygpO1xyXG4gICAgICAgICAgICAgICAgICAgICAgICBsb2FkZXIuaGlkZSgpO1xyXG4gICAgICAgICAgICAgICAgICAgIH0pO1xyXG4gICAgICAgICAgICAgICAgfTtcclxuXHJcbiAgICAgICAgICAgICAgICB1cGRhdGUoYWpheFVybCwgcGFyZW50KTsgXHJcbiAgICAgICAgICAgIH1cclxuICAgICAgICB9KTtcclxuICAgIH0pO1xyXG59Il0sInNvdXJjZVJvb3QiOiIvc291cmNlLyJ9
