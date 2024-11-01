using Test_Api_NumberBook.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Test_Api_NumberBook.Repositories
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAllAsync(int pageNumber, int pageSize);
        Task<Contact> GetByIdAsync(Guid id);
        Task AddAsync(Contact contact);
        Task UpdateAsync(Contact contact);
        Task DeleteAsync(Guid id);
    }
}
