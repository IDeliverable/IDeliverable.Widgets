using Orchard.Events;

namespace IDeliverable.Widgets.Events
{
    public interface IResourceManagerEvents : IEventHandler
    {
        void FootScriptRegistered(string script);
        void HeadScriptRegistered(string script);
        void ResourceRequired(string resourceType, string resourceName);
        void ResourceIncluded(string resourceType, string resourcePath, string resourceDebugPath, string relativeFromPath);
    }
}