using IDeliverable.Widgets.Models;
using Orchard;
using System;

namespace IDeliverable.Widgets.Services
{
    public interface IOuputCachedWidgetsService : IDependency
    {
        OutputCachedWidgetModel CaptureWidgetOutput(Func<string> htmlFactory);
    }
}