using ContactManagementAPI.Models;

namespace ContactManagementAPI.Repositories
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAllContactAsync();
        Task<Contact> GetContactByIdAsync(int id);
        Task AddContactAsync(Contact contact);
        Task UpdateContactAsync(Contact contact);
        Task DeleteContactByIdAsync(int id);
    }
}
