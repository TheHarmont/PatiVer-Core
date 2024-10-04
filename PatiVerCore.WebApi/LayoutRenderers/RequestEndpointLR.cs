using NLog.LayoutRenderers;
using NLog;
using System.Text;

namespace PatiVerCore.WebApi.LayoutRenderers
{
    [LayoutRenderer("request-endpoint")]
    public class RequestEndpointLR : LayoutRenderer
    {
        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            var s = ScopeContext.TryGetProperty("RequestEndpoint", out var value) ? value?.ToString() : null;
            builder.Append(s);
        }
    }
}
