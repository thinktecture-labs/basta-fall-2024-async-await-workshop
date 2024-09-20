using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace ReducedWebApp.Tests;

public sealed class WebAppFactory : WebApplicationFactory<Program>
{
    private readonly ILogger _logger;
    public WebAppFactory(ILogger logger) => _logger = logger;

    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.UseSerilog(_logger);
        return base.CreateHost(builder);
    }

    public GrpcChannel CreateGrpcChannel() => GrpcChannel.ForAddress(Server.BaseAddress, CreateChannelOptions());

    private GrpcChannelOptions CreateChannelOptions() => new ()
    {
        HttpHandler = Server.CreateHandler()
    };
}