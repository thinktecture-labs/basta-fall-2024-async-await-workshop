using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ProtoBuf.Grpc.Server;
using Serilog;
using WebApi.AsyncStreaming;
using WebApi.CommonValidation;
using WebApi.Contacts;
using WebApi.DatabaseAccess;
using WebApi.MessageBrokerAccess;
using WebApi.Orders;
using WebApi.TransactionalOutbox;

namespace WebApi.CompositionRoot;

public static class DependencyInjection
{
    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder, ILogger logger)
    {
        builder.Host.UseSerilog(logger);
        builder
           .Services
           .AddSingleton(TimeProvider.System)
           .AddDatabaseAccess(builder.Configuration)
           .AddMessageBroker()
           .AddCommonValidation()
           .AddContacts()
           .AddAsyncStreamingExample()
           .AddTransactionalOutbox()
           .AddOrders()
           .AddHealthChecks()
           .Services
           .AddCodeFirstGrpc();
        return builder;
    }
}