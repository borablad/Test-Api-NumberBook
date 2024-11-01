using Test_Api_NumberBook.Models;

namespace Test_Api_NumberBook.Services
{
    public interface IContactService
    {
        Task<IEnumerable<Contact>> GetContactsAsync(int pageNumber, int pageSize);
        Task<Contact> GetContactByIdAsync(Guid id);
        Task AddContactAsync(Contact contact);
        Task UpdateContactAsync(Contact contact);
        Task DeleteContactAsync(Guid id);
    }
}
