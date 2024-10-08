using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using WebApi.CommonValidation;

namespace WebApi.Contacts.GetContacts;

public static class GetContactsEndpoint
{
    public static void MapGetContacts(this WebApplication app) =>
        app.MapGet("/api/contacts", GetContacts);

    public static async Task<IResult> GetContacts(
        IGetContactsDbSession dbSession,
        PagingParametersValidator validator,
        CancellationToken cancellationToken,
        int skip = 0,
        int take = 20
    )
    {
        if (validator.CheckForErrors(new PagingParameters(skip, take), out var errors))
        {
            return Results.BadRequest(errors);
        }

        var contacts = await dbSession.GetContactsAsync(skip, take, cancellationToken);
        return Results.Ok(contacts);
    }
}