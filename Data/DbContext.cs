using ContactManagementAPI.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ContactManagementAPI.Data
{
    public class DbContext
    {
        private readonly string _databasefile = Path.Combine(Directory.GetCurrentDirectory(), "Data", "contact.json");

        public async Task<List<Contact>> GetContactsAsync()
        {
            if (!File.Exists(_databasefile))
                return new List<Contact>();

            var jsondata = await File.ReadAllTextAsync(_databasefile);
            return JsonConvert.DeserializeObject<List<Contact>>(jsondata) ?? new List<Contact>();
        }
        public async Task SaveContactAsync(List<Contact> contacts)
        {
            var jsonData = JsonConvert.SerializeObject(contacts, Formatting.Indented);
            await File.WriteAllTextAsync(_databasefile, jsonData);
        }
    }
}
