using NLog;
using NLog.LayoutRenderers;
using System.Text;

namespace PatiVerCore.WebApi.LayoutRenderers
{
    [LayoutRenderer("request-ip")]
    public class RequestIpLR : LayoutRenderer
    {
        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            var s = ScopeContext.TryGetProperty("RequestIp", out var value) ? value?.ToString() : null;
            builder.Append(s);
        }
    }
}
