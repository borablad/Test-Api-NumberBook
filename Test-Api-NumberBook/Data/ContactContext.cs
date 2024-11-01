using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Test_Api_NumberBook.Models;

namespace Test_Api_NumberBook.Data
{
    // Для хранения данных использую In-Memory Database (для тестового задания думаю этого достаточно)
    // To store data I use In-Memory Database (I think this is enough for the test task)
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }
    }
}
