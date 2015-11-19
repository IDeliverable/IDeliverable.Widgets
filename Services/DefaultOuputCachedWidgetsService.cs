using IDeliverable.Widgets.Events;
using IDeliverable.Widgets.Models;
using Orchard.Environment.Extensions;
using System;
using System.Collections.Generic;

namespace IDeliverable.Widgets.Services
{
    [OrchardFeature("IDeliverable.Widgets.OutputCache")]
    public class DefaultOuputCachedWidgetsService : IOuputCachedWidgetsService, IResourceManagerEvents
    {
        // Indicates if we are inside the CaptureWidgetMethod. Used to determine if includes should be added to the model.
        private bool IsWithinCaptureContext { get; set; }
        private IList<ResourceRequiredModel> RequiredResources { get; set; }
        private IList<ResourceIncludedModel> IncludedResources { get; set; }
        private IList<string> FootScripts { get; set; }
        private IList<string> HeadScripts { get; set; }

        public OutputCachedWidgetModel CaptureWidgetOutput(Func<string> htmlFactory)
        {
            var model = new OutputCachedWidgetModel();

            try
            {
                IsWithinCaptureContext = true;
                RequiredResources = new List<ResourceRequiredModel>();
                IncludedResources = new List<ResourceIncludedModel>();
                FootScripts = new List<string>();
                HeadScripts = new List<string>();

                model.Html = htmlFactory();

                model.IncludedResources = IncludedResources;
                model.RequiredResources = RequiredResources;
                model.FootScripts = FootScripts;
                model.HeadScripts = HeadScripts;
            }
            finally
            {
                IsWithinCaptureContext = false;
            }


            return model;
        }

        // When these events are raised while creating html to be cached, then we need to add a record of the values passed into the cache as well so that we can re-instate the resources when we get the html back from the cache
        public void FootScriptRegistered(string script)
        {
            if (IsWithinCaptureContext)
                FootScripts.Add(script);
        }

        public void HeadScriptRegistered(string script)
        {
            if (IsWithinCaptureContext)
                HeadScripts.Add(script);
        }

        public void ResourceRequired(string resourceType, string resourceName)
        {
            if (IsWithinCaptureContext)
            {
                RequiredResources.Add(new ResourceRequiredModel
                {
                    ResourceType = resourceType,
                    ResourceName = resourceName,
                });
            }
        }

        public void ResourceIncluded(string resourceType, string resourcePath, string resourceDebugPath, string relativeFromPath)
        {
            if (IsWithinCaptureContext)
            {
                IncludedResources.Add(new ResourceIncludedModel
                {
                    ResourceType = resourceType,
                    ResourcePath = resourcePath,
                    ResourceDebugPath = resourceDebugPath,
                    RelativeFromPath = relativeFromPath
                });
            }
        }
    }
}