using ContactsApp.Core.Models;

namespace ContactsApp.Service.Interfaces
{
    public interface IContactsRepository
    {
        Task<IEnumerable<Contact>> GetAllContacts(bool trackChanges);
        Task<Contact> GetContact(int contactId, bool trackChanges);
        Task CreateContact(Contact contact);
        Task DeleteContact(Contact contact);
        Task UpdateContact(Contact contact);
    }
}
