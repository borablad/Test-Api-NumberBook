using Test_Api_NumberBook.Data;
using Test_Api_NumberBook.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Api_NumberBook.Repositories
{
    public class ContactRepository : IContactRepository
    {
        // Поле для контекста базы данных / Field for the database context
        private readonly ContactContext _context;

        public ContactRepository(ContactContext context)
        {
            _context = context;
        }

        // Метод для получения списка контактов с пагинацией / Method to get a paginated list of contacts
        public async Task<IEnumerable<Contact>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _context.Contacts
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        // Метод для получения контакта по его уникальному ID / Method to retrieve a contact by its unique ID
        public async Task<Contact> GetByIdAsync(Guid id)
        {
            return await _context.Contacts.FindAsync(id);
        }

        // Метод для добавления нового контакта в базу данных / Method to add a new contact to the database
        public async Task AddAsync(Contact contact)
        {
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
        }

        // Метод для обновления информации о существующем контакте / Method to update information of an existing contact
        public async Task UpdateAsync(Contact contact)
        {
            _context.Contacts.Update(contact);
            await _context.SaveChangesAsync();
        }

        // Метод для удаления контакта по его уникальному ID / Method to delete a contact by its unique ID
        public async Task DeleteAsync(Guid id)
        {
            var contact = await GetByIdAsync(id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                await _context.SaveChangesAsync();
            }
        }
    }

}
