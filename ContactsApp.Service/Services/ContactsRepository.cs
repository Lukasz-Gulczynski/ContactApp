using ContactsApp.Core.Models;
using ContactsApp.Repo.Data;
using ContactsApp.Repo.GenericRepository.Service;
using ContactsApp.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContactsApp.Service.Services
{
    public class ContactsRepository : RepositoryBase<Contact>, IContactsRepository
    {
        public ContactsRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task CreateContact(Contact contact)
        {
            await CreateAsync(contact);
        }

        public async Task DeleteContact(Contact contact)
        {
            await RemoveAsync(contact);
        }

        public async Task<IEnumerable<Contact>> GetAllContacts(bool trackChanges)
        {
            return await FindAllAsync(trackChanges).Result.OrderBy(c => c.Id).ToListAsync();
        }

        public async Task<Contact> GetContact(int contactId, bool trackChanges)
        {
            return await FindByConditionAsync(c => c.Id.Equals(contactId), trackChanges).Result.SingleOrDefaultAsync();
        }

        public async Task UpdateContact(Contact contact)
        {
            await UpdateAsync(contact);
        }
    }
}