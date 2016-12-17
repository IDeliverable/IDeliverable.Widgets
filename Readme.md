# IDeliverable.Widgets

IDeliverable.Widgets is a module for the Orchard CMS that extends the built-in widget system with additional functionality. Widgets can be configured to be loaded asynchronously using an AJAX call (without modifying any code or markup). Additionally, widgets can be output cached even if the full page is not. Finally, the module adds a widget container part, which can be used to display widgets per content item without the need to create an item-specific layer.

## Features

This module provides a number of useful functional enhancements to the widgets system in the Orchard CMS.

### Widgets per content item

A very common requirement when building websites based on the Orchard CMS is to render *content item-specific widgets*, i.e. widgets that by definition and content are affinitized to a particular page or other content item. The way you would normally do this is by creating a page-specific widget layer and then adding the widgets in the available zones on that layer. This quickly becomes unmanagable, especially for very large websites, as it becomes increasingly difficult to keep track of the relationships between all those layers and the content items they represent.

**IDeliverable.Widgets** solves this problem by providing a content part named `WidgetsContainerPart` which can be added to any non-widget content type (such as **Page** for example). With this content part attached, you can now add widgets to a specific content item of that content type, without the need to create a dedicated widget layer for it.

### AJAX widgets

There are scenarios where the rendering of the pages on your website is generally fast, but where a widget on those pages may take a long time to render (perhaps because it calls out to external services to retreive data). In such cases you may want to decouple the loading and rendering of the overall page (which might be served from `Orchard.OutputCache`) from the loading and rendering of that slower widget. Especially if the slow widget might not be the user's primary concern, depending on what the user wants to do, it may make sense for the user to start viewing or interacting with the rest of the page while that slow-performing widget is still loading.

By default this is not possible in Orchard. All widgets and other shapes that make up the final rendered page are served to the client in one single response, which means the slowest part determines the response time of the whole page. **IDeliverable.Widgets** changes this by allowing you to configure individual widgets to be loaded asynchronously in separate requests via AJAX.

With **IDeliverable.Widgets** this is made easy by providing a content part named `AjaxifyPart`. This part can be attached to any widget content type (or regular content type for that matter) and will cause the widget to be loaded by the client using a separate AJAX request, without changing any code or markup.

### Widget output caching

To improve performance on production websites, you will typically have the `Orchard.OutputCache` feature enabled so that pages are rendered once and then cached for a configured amount of time. There are situations where, for whatever reason, you do not wish to output cache the surrounding page, but you would still like to output cache certain widgets that are not personalized but still particularly expensive to render. This caching strategy is commonly referred to as *donut hole caching*.

Without changing any code or markup, widgets can be configured to be output cached independently of the surrounding page. The output cache duration can be configured per widget. To enable output caching of individual widgets, **IDeliverable.Widgets** provides a content part named `OutputCachePart`. Simply attach it to any widget content type to be able to control, per widget, whether it should be output cached or not and for how long.

**NOTE:** This feature is a very rudimentary way to achieve donut hole caching, and it has significant limitations. For a much more robust and complete implementation of donut caching and donut hole caching for Orchard, please refer to the [IDeliverable.Donuts module](http://www.ideliverable.com/products/premium-orchard-modules/ideliverable-donuts) which is more likely to be actively developed going forward.

## Compatibility

This module is compatible with **Orchard version 1.10.x**. The module might also work on older or newer versions of Orchard but this is not guaranteed.

## License

This module is open source and free for use under the permissive [MIT license](https://opensource.org/licenses/MIT), which means you are free to change it, redistribute it and generally use it in whatever way you want.
