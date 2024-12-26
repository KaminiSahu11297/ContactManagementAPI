using ContactManagementAPI.Models;
using ContactManagementAPI.Repositories;

namespace ContactManagementAPI.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository; 
        }

        public async Task AddNewContact(Contact contact)
        {
            await _contactRepository.AddContactAsync(contact);
        }

        public async Task DeleteContact(int id)
        {
            await _contactRepository.DeleteContactByIdAsync(id);
        }

        public async Task<IEnumerable<Contact>> GetAllContact()
        {
            return await _contactRepository.GetAllContactAsync();
        }

        public async Task<Contact> GetContactById(int id)
        {
            return await _contactRepository.GetContactByIdAsync(id);
        }

        public async Task UpdateContact(Contact contact)
        {
           await _contactRepository.UpdateContactAsync(contact);
        }
    }
}
