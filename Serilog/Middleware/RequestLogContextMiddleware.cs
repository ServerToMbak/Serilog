using Serilog.Context;
using System.Diagnostics;

namespace Serilogg.Middleware
{
    public class RequestLogContextMiddleware
    {

        private readonly RequestDelegate _next;

        public RequestLogContextMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        
        public Task InvokeAsync(HttpContent context)
        {
            using(LogContext.PushProperty("CorrelationId", context.ToString()))
            {
                return _next(context);
            }
        }
    }

    
}
