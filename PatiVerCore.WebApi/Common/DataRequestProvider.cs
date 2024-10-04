namespace PatiVerCore.WebApi.Common
{
    public static class DataRequestProvider
    {
        public static string? GetRequestIp(this HttpContext httpContext)
        {
            var forwardedHeader = httpContext?.Request?.Headers["X-Forwarded-For"].FirstOrDefault();
            var remoteIpAddress = httpContext?.Request?.Host.Host.ToString();
            var ipAddress = string.IsNullOrEmpty(forwardedHeader) ? remoteIpAddress : forwardedHeader?.Split(',').FirstOrDefault()?.Trim();

            return ipAddress;
        }

        public static string? GetRequestEndpoint(this HttpContext httpContext)
        {
            return httpContext?.Request?.Path;
        }

        public static string? GetRequestMethod(this HttpContext httpContext)
        {
            return httpContext?.Request?.Method;
        }

        public static string? GetTraceIdentifier(this HttpContext httpContext)
        {
            return httpContext?.TraceIdentifier;
        }
    }
}
