using System;
using System.Collections.Generic;
using System.Linq;
using Orchard.OutputCache.Models;

namespace IDeliverable.Widgets.Models {
    public class CacheSettings {
        public CacheSettings(CacheSettingsPart part) {
            DefaultCacheDuration = part.DefaultCacheDuration;
            DefaultMaxAge = part.DefaultMaxAge;
            VaryQueryStringParameters = String.IsNullOrWhiteSpace(part.VaryQueryStringParameters) ? new string[0] : part.VaryQueryStringParameters.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToArray();
            VaryRequestHeaders = String.IsNullOrWhiteSpace(part.VaryRequestHeaders) ? new string[0] : part.VaryRequestHeaders.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToArray();
            IgnoredUrls = part.IgnoredUrls;
            ApplyCulture = part.ApplyCulture;
            DebugMode = part.DebugMode;
            IgnoreNoCache = part.IgnoreNoCache;
        }

        public int DefaultCacheDuration { get; set; }
        public int DefaultMaxAge { get; set; }
        public IList<string> VaryQueryStringParameters { get; set; }
        public IList<string> VaryRequestHeaders { get; set; }
        public string IgnoredUrls { get; set; }
        public bool ApplyCulture { get; set; }
        public bool DebugMode { get; set; }
        public bool IgnoreNoCache { get; set; }
    }
}