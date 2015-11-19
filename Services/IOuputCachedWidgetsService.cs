using System;
using IDeliverable.Widgets.Models;
using Orchard;

namespace IDeliverable.Widgets.Services
{
    public interface IOuputCachedWidgetsService : IDependency
    {
        OutputCachedWidgetModel CaptureWidgetOutput(Func<string> htmlFactory);
    }
}