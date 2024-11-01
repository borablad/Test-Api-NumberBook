using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Test_Api_NumberBook.Models;

namespace Test_Api_NumberBook.Data
{
    // Для хранения данных использую In-Memory Database (для тестового задания думаю этого достаточно)
    // To store data I use In-Memory Database (I think this is enough for the test task)
    public class ContactContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public ContactContext(DbContextOptions<ContactContext> options) : base(options)
        {
            // Проверяем, есть ли данные, и добавляем пользователя по умолчанию, если данных нет
            if (this.Contacts.Any() == false)
            {
                this.Contacts.Add(new Contact
                {
                    FirstName = "Default",
                    LastName = "User",
                    PhoneNumber = "0000000000",
                    Email = "defaultuser@example.com"
                });
                this.SaveChanges(); // Сохраняем изменения
            }
        }
    }
}
