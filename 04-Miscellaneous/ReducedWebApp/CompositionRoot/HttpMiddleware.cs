using Serilog;
using WebApi.AsyncStreaming;

namespace ReducedWebApp.CompositionRoot;

public static class HttpMiddleware
{
    public static WebApplication ConfigureMiddleware(this WebApplication app)
    {
        app.UseSerilogRequestLogging();
        app.UseRouting();
        app.MapAsyncStreamingExample();
        app.MapHealthChecks("/");
        return app;
    }
}