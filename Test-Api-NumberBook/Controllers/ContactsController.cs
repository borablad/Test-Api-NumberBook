using Microsoft.AspNetCore.Mvc;
using Test_Api_NumberBook.Models;
using Test_Api_NumberBook.Services;

namespace Test_Api_NumberBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _service;

        public ContactsController(IContactService service)
        {
            _service = service;
        }

        // Метод для получения списка контактов с параметрами пагинации / Method to get a paginated list of contacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContacts(int pageNumber = 1, int pageSize = 10)
        {
            var contacts = await _service.GetContactsAsync(pageNumber, pageSize);
            return Ok(contacts); // Возвращает результат со статусом 200 и списком контактов / Returns 200 status with contact list
        }

        // Метод для получения контакта по ID / Method to retrieve a contact by its ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContact(Guid id)
        {
            var contact = await _service.GetContactByIdAsync(id);
            if (contact == null)
                return NotFound(); // Возвращает статус 404, если контакт не найден / Returns 404 if contact not found
            return Ok(contact); // Возвращает статус 200 с найденным контактом / Returns 200 status with found contact
        }

        // Метод для создания нового контакта / Method to create a new contact
        [HttpPost]
        public async Task<IActionResult> CreateContact(Contact contact)
        {
            contact.Id = Guid.NewGuid();
            await _service.AddContactAsync(contact); 
            // Возвращает статус 201 и путь для получения созданного контакта / Returns 201 status and path to access created contact
            return CreatedAtAction(nameof(GetContact), new { id = contact.Id }, contact);
        }

        // Метод для обновления информации о существующем контакте / Method to update an existing contact's information
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(Guid id, Contact contact)
        {
            if (id != contact.Id)
                return BadRequest(); // Возвращает статус 400, если ID не совпадают / Returns 400 status if IDs do not match

            await _service.UpdateContactAsync(contact); // Обновление контакта через сервис / Updates contact via service
            return NoContent(); // Возвращает статус 204, так как контент не требуется / Returns 204 status, as no content is required
        }

        // Метод для удаления контакта по ID / Method to delete a contact by its ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(Guid id)
        {
            await _service.DeleteContactAsync(id); // Удаление контакта через сервис / Deletes contact via service
            return NoContent(); // Возвращает статус 204 после успешного удаления / Returns 204 status upon successful deletion
        }
    }

}
