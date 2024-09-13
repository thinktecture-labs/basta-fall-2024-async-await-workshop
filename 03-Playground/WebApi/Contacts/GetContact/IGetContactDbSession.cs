using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Light.SharedCore.DatabaseAccessAbstractions;
using WebApi.Contacts.GetContacts;
using WebApi.DatabaseAccess.Model;

namespace WebApi.Contacts.GetContact;

public interface IGetContactDbSession : IAsyncReadOnlySession
{
    Task<Contact?> GetContactWithAddressesAsync(
        Guid contactId,
        CancellationToken cancellationToken = default
    );
}