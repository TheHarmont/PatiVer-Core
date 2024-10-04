using NLog;
using NLog.LayoutRenderers;
using System.Text;

namespace PatiVerCore.WebApi.LayoutRenderers
{
    [LayoutRenderer("trace-identifier")]
    public class TraceIdentifierLR : LayoutRenderer
    {
        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            builder.Append(ScopeContext.TryGetProperty("TraceIdentifier", out var value) ? value?.ToString() : null);
        }
    }
}
