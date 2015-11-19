using IDeliverable.Widgets.Events;
using Orchard.Environment.Extensions;
using Orchard.UI.Resources;
using System.Collections.Generic;
using Autofac.Features.Metadata;

namespace IDeliverable.Widgets.Services
{
    [OrchardFeature("IDeliverable.Widgets.OutputCache")]
    [OrchardSuppressDependency("Orchard.UI.Resources.ResourceManager")]
    public class EventRaisingResourceManager : ResourceManager
    {
        private readonly IResourceManagerEvents _resourceManagerEvents;

        private bool SuppressRequireEvents { get; set; }

        public EventRaisingResourceManager(IEnumerable<Meta<IResourceManifestProvider>> resourceProviders, IResourceManagerEvents resourceManagerEvents)
            : base(resourceProviders)
        {
            _resourceManagerEvents = resourceManagerEvents;
        }

        public override void RegisterFootScript(string script)
        {
            base.RegisterFootScript(script);
            _resourceManagerEvents.FootScriptRegistered(script);
        }

        public override void RegisterHeadScript(string script)
        {
            base.RegisterHeadScript(script);
            _resourceManagerEvents.HeadScriptRegistered(script);
        }

        public override RequireSettings Require(string resourceType, string resourceName)
        {
            //include calls require under the hood, so we will end up with dupicate events in that case
            if (!SuppressRequireEvents)
            {
                _resourceManagerEvents.ResourceRequired(resourceType, resourceName);
            }

            return base.Require(resourceType, resourceName);
        }

        public override RequireSettings Include(string resourceType, string resourcePath, string resourceDebugPath, string relativeFromPath)
        {
            SuppressRequireEvents = true;
            var result = base.Include(resourceType, resourcePath, resourceDebugPath, relativeFromPath);
            SuppressRequireEvents = false;

            _resourceManagerEvents.ResourceIncluded(resourceType, resourcePath, resourceDebugPath, relativeFromPath);

            return result;
        }
    }
}