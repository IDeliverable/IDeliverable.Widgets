# IDeliverable.Widgets
A module for the Orchard CMS that extends the built-in widget system with additional functionality. Widgets can be configured to be loaded asynchronously using an AJAX call (without modifying any code or markup). Additionally, widgets can be output cached even if the full page is not. Finally, the module adds a widget container part, which can be used to display widgets per content item without the need to create an item-specific layer.

## Features
The IDeliverable.Widgets module provides a number of useful functional enhancements to the widgets system in the Orchard CMS.

### AJAX widgets
Without changing any code or markup, any widget on your Orchard site can be configured to be loaded by the client browser asynchronously using an AJAX call. This can be used to implement *donut caching*.

### Widget output caching
Without changing any code or markup, widgets can be configured to be output cached independently of the surrounding page. The output cache duration can be configured per widget. This can be used to implement *donut hole caching*.

### Widgets per content item
A content part named ´WidgetsContainerPart´ can be added to any content type, allowing you to add one or more specific widgets to any given content item. This removes the need to create an item-specific widget layer just for the purposes of rendering a set of widgets with the content item.

### Always up to date
Our modules are always guaranteed to be kept up-to-date with the latest and greatest version of Orchard, while also maintaining compatibility with previous versions of Orchard whenever possible.

### Free and open source
Our free modules all come with full source code and are license with a permissive MIT license, which means you are free to change it, redistribute it and generally use it in whatever way you want.

## Key Concepts

### Loading widgets via AJAX
To improve performance on production websites, you typically have the `Orchard.OutputCache` feature enabled so that pages are rendered once and then cached for a configured amount of time. However, there are scenarios where you might like to not output cache certain parts of the page, or output cache certain parts with a much shorter expiration time than the rest of the page. This is often referred to as *donut caching*.

One example of when this is useful is personalized content. For example, you might have a widget on the homepage of your site, that renders an "Account" menu containing the name of the currently logged in user. You would want your homepage as a whole to be output cached, **except** that widget. Configuring that widget to be loaded asynchronously via AJAX solves the problem: the page might be served from output cache but the widget is rendered in a separate request which is not output cached.

With **IDeliverable.Widgets** this is made easy by providing a content part named `AjaxifyPart`. This part can be attached to any widget content type (or regular content type for that matter) and will cause the widget to be loaded by the client browser using a separate AJAX call.

### Donut hole caching
There are situations where, for whatever reason, you do not wish to output cache the surrounding page, but you would still like to output cache certain widgets that are particularly expensive to render. This is commonly referred to as *donut hole caching* and is conceptually the opposite of *donut caching*.

To enable output caching of widgets, **IDeliverable.Widgets** provides a content part named `OutputCachePart`. Simply attach it to any widget content type to be able to control per widget whether it should be output cached or not.

### Content-specific widgets
A very common requirement when building websites based on the Orchard CMS is to render *content item-specific widgets*, i.e. widgets that by definition and content are affinitized to a particular page or other content item.

The way you would normally do this is by creating a page-specific widget layer and then adding the widgets in the available zones on that layer. This quickly becomes unmanagable, especially for very large websites, as it becomes increasingly difficult to keep track of the relationships between layers and the content items they represent.

**IDeliverable.Widgets** solves this problem by providing a content part named `WidgetsContainerPart` which can be added to any (non-widget) content type (such as *Page* for example). With this content part attached, you can now add widgets to a specific content item of that content type, without the need to create a dedicated widget layer for it.

## Licensing
The **IDeliverable.Widgets** module is free and open source (source code is included in the download package). Like all of our free Orchard CMS modules, it is licensed under the [New BSD License (BSD)](https://en.wikipedia.org/wiki/BSD_licenses).

## Technical Support
We provide free best-effort technical support for all free Orchard CMS modules. This means it sometimes may take slightly longer for us to respond to your support ticket if we have a lot of other things going on.

To get in touch with us, either submit a support ticket using the Help link in the lower right corner, or send email to **support@ideliverable.com**.

For further information and more support options, go to [www.ideliverable.com/support](http://www.ideliverable.com/support).