using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Light.SharedCore.DatabaseAccessAbstractions;

namespace WebApi.Contacts.GetContacts;

public interface IGetContactsDbSession : IAsyncReadOnlySession
{
    Task<List<ContactListDto>> GetContactsAsync(int skip, int take, CancellationToken cancellationToken = default);
}