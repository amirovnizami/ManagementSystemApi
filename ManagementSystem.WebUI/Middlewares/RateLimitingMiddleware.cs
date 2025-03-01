using System.Collections.Concurrent;

namespace ManagmentSystem.WebUI.Middlewares;

public class RateLimitingMiddleware
{
    private readonly RequestDelegate _next;
    private static readonly ConcurrentDictionary<string, (DateTime Timestamp, int Count)> _requests = new();

    private const int Limit = 5; 
    private static readonly TimeSpan TimeWindow = TimeSpan.FromSeconds(10);

    public RateLimitingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        string clientIp = context.Connection.RemoteIpAddress?.ToString() ?? "unknown";

        if (_requests.TryGetValue(clientIp, out var entry))
        {
            if ((DateTime.UtcNow - entry.Timestamp) < TimeWindow)
            {
                if (entry.Count >= Limit)
                {
                    context.Response.StatusCode = StatusCodes.Status429TooManyRequests;
                    await context.Response.WriteAsync("Too many requests. Please try again later.");
                    return;
                }
                _requests[clientIp] = (entry.Timestamp, entry.Count + 1);
            }
            else
            {
                _requests[clientIp] = (DateTime.UtcNow, 1);
            }
        }
        else
        {
            _requests[clientIp] = (DateTime.UtcNow, 1);
        }

        await _next(context);
    }
}