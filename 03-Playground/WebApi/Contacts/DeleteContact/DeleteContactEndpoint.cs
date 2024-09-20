using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Serilog;
using WebApi.Contacts.Common;

namespace WebApi.Contacts.DeleteContact;

public static class DeleteContactEndpoint
{
    public static void MapDeleteContact(this WebApplication app)
    {
        app.MapDelete("/api/contacts/{id:required:guid}", DeleteContact);
    }
    
    public static async Task<IResult> DeleteContact(
        IDeleteContactDbSession dbSession,
        ILogger logger,
        Guid id,
        CancellationToken cancellationToken
    )
    {
        var contact = await dbSession.GetContactAsync(id, cancellationToken);
        if (contact is null)
        {
            return Results.NotFound();
        }

        dbSession.RemoveContact(contact);
        await dbSession.SaveChangesAsync(cancellationToken);

        logger.Information("{@Contact} was deleted successfully", contact);
        return Results.Ok(ContactDetailDto.FromContact(contact));
    }
}