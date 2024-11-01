using Test_Api_NumberBook.Models;
using Test_Api_NumberBook.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Test_Api_NumberBook.Services
{
    public class ContactService : IContactService
    {
        // Поле для доступа к репозиторию контактов / Field for accessing the contact repository
        private readonly IContactRepository _repository;

        public ContactService(IContactRepository repository)
        {
            _repository = repository;
        }

        // Метод для получения списка контактов с пагинацией / Method to retrieve paginated list of contacts
        public Task<IEnumerable<Contact>> GetContactsAsync(int pageNumber, int pageSize)
        {
            return _repository.GetAllAsync(pageNumber, pageSize);
        }

        // Метод для получения контакта по ID / Method to retrieve a contact by its ID
        public Task<Contact> GetContactByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        // Метод для добавления нового контакта / Method to add a new contact
        public Task AddContactAsync(Contact contact)
        {
            return _repository.AddAsync(contact);
        }

        // Метод для обновления существующего контакта / Method to update an existing contact
        public Task UpdateContactAsync(Contact contact)
        {
            return _repository.UpdateAsync(contact);
        }

        // Метод для удаления контакта по ID / Method to delete a contact by its ID
        public Task DeleteContactAsync(int id)
        {
            return _repository.DeleteAsync(id);
        }
    }

}
