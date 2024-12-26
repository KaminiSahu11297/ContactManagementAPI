using ContactManagementAPI.Models;

namespace ContactManagementAPI.Services
{
    public interface IContactService
    {
        Task<IEnumerable<Contact>> GetAllContact();
        Task<Contact> GetContactById(int id);   
        Task AddNewContact(Contact contact);
        Task DeleteContact(int id);
        Task UpdateContact(Contact contact);
    }
}
