using ContactManagementAPI.Data;
using ContactManagementAPI.Models;

namespace ContactManagementAPI.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly DbContext _dbContext;
        public ContactRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddContactAsync(Contact contact)
        {
            var contacts = await _dbContext.GetContactsAsync();
            contact.Id = contacts.Any() ? contacts.Max(x => x.Id) + 1 : 1;
            contacts.Add(contact);
            await _dbContext.SaveContactAsync(contacts);
        }

        public async Task DeleteContactByIdAsync(int id)
        {
            var contacts = await _dbContext.GetContactsAsync();
            var existingContact = contacts.FirstOrDefault(x => x.Id == id);

            if(existingContact != null)
            {
                contacts.Remove(existingContact);
                await _dbContext.SaveContactAsync(contacts);
            }
        }

        public async Task<IEnumerable<Contact>> GetAllContactAsync()
        {
            return await _dbContext.GetContactsAsync();
        }

        public async Task<Contact> GetContactByIdAsync(int id)
        {
            var contact = await _dbContext.GetContactsAsync();
            return contact.FirstOrDefault(x =>x.Id == id);
        }

        public async Task UpdateContactAsync(Contact contact)
        {
            var contacts = await _dbContext.GetContactsAsync();
            var existingContact = contacts.FirstOrDefault(x => x.Id == contact.Id);

            if(existingContact != null) 
            { 
                existingContact.FirstName = contact.FirstName;
                existingContact.LastName = contact.LastName;
                existingContact.Email = contact.Email;
                await _dbContext.SaveContactAsync(contacts);
                }
        }
    }
}
