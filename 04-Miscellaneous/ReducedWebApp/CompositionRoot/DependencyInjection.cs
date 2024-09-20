using ProtoBuf.Grpc.Server;
using Serilog;
using WebApi.AsyncStreaming;
using ILogger = Serilog.ILogger;

namespace ReducedWebApp.CompositionRoot;

public static class DependencyInjection
{
    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder, ILogger logger)
    {
        builder.Host.UseSerilog(logger);
        builder
           .Services
           .AddSingleton(TimeProvider.System)
           .AddAsyncStreamingExample()
           .AddHealthChecks()
           .Services
           .AddCodeFirstGrpc();
        return builder;
    }
}