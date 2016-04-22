using System;
using System.Collections.Generic;
using IDeliverable.Widgets.Events;
using IDeliverable.Widgets.Models;
using Orchard.Environment.Extensions;

namespace IDeliverable.Widgets.Services
{
    [OrchardFeature("IDeliverable.Widgets.OutputCache")]
    public class DefaultOuputCachedWidgetsService : IOuputCachedWidgetsService, IResourceManagerEvents
    {
        private bool WithinContext { get; set; }
        private IList<ResourceRequiredModel> RequiredResources { get; set; }
        private IList<ResourceIncludedModel> IncludedResources { get; set; }
        private IList<string> FootScripts { get; set; }
        private IList<string> HeadScripts { get; set; }

        public OutputCachedWidgetModel CaptureWidgetOutput(Func<string> htmlFactory)
        {
            var model = new OutputCachedWidgetModel();

            try
            {
                WithinContext = true;
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
                WithinContext = false;
            }


            return model;
        }

        // When these events are raised while creating html to be cached, then we need to add a record of the values passed into the cache as well so that we can re-instate the resources when we get the html back from the cache
        public void FootScriptRegistered(string script)
        {
            if (WithinContext)
            {
                FootScripts.Add(script);
            }
        }

        public void HeadScriptRegistered(string script)
        {
            if (WithinContext)
            {
                HeadScripts.Add(script);
            }
        }

        public void ResourceRequired(string resourceType, string resourceName)
        {
            if (WithinContext)
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
            if (WithinContext)
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