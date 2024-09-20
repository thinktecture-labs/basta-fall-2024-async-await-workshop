using Serilog;
using Serilog.Events;
using ILogger = Serilog.ILogger;

namespace ReducedWebApp.CompositionRoot;

public static class Logging
{
    public static ILogger CreateLogger() =>
        new LoggerConfiguration()
           .MinimumLevel.Information()
           .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
           .WriteTo.Console()
           .CreateLogger();
}