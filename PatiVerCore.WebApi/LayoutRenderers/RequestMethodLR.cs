﻿using NLog.LayoutRenderers;
using NLog;
using System.Text;

namespace PatiVerCore.WebApi.LayoutRenderers
{
    [LayoutRenderer("request-method")]
    public class RequestMethodLR : LayoutRenderer
    {
        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            var s = ScopeContext.TryGetProperty("RequestMethod", out var value) ? value?.ToString() : null;
            builder.Append(s);
        }
    }
}
