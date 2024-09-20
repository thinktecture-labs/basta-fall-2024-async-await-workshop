using System;
using System.Threading;
using System.Threading.Tasks;
using Light.SharedCore.DatabaseAccessAbstractions;
using Microsoft.EntityFrameworkCore;
using WebApi.DatabaseAccess;
using WebApi.DatabaseAccess.Model;
using WebApi.TransactionalOutbox;

namespace WebApi.Orders;

public interface ICompleteOrderDbSession : IAsyncSession
{
    Task<Order?> GetOrderAsync(Guid orderId, CancellationToken cancellationToken);
    void AddMessageAsOutboxItem(object message);
}

public sealed class EfCompleteOrderSession : EfOutboxSession, ICompleteOrderDbSession
{
    public EfCompleteOrderSession(
        IOutboxItemFactory outboxItemFactory,
        IOutboxTrigger outboxProcessor,
        WebApiDbContext dbContext
    ) : base(outboxItemFactory, outboxProcessor, dbContext) { }

    public Task<Order?> GetOrderAsync(Guid orderId, CancellationToken cancellationToken) =>
        DbContext.Orders.FirstOrDefaultAsync(o => o.Id == orderId, cancellationToken);
}