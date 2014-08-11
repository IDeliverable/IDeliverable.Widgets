using System.Collections.Generic;
using IDeliverable.Widgets.Models;
using Orchard;
using Orchard.Widgets.Models;

namespace IDeliverable.Widgets.Services {
    public interface IWidgetManager : IDependency {
        IEnumerable<WidgetExPart> GetWidgets(int hostId);
        LayerPart GetContentLayer();
    }
}