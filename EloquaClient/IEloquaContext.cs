using LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.Contacts;

namespace LG.Eloqua.Api.Rest.ClientLibrary
{
    public interface IEloquaContext
    {
        IDbSet<Contact> Contacts { get; }
        IBulkApi Bulk { get; }
    }
}