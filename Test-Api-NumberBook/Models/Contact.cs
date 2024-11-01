namespace Test_Api_NumberBook.Models
{
    public class Contact
    {
        public int Id { get; set; }              // ID для идентификации контакта / ID for contact identification
        public string FirstName { get; set; }    // Имя / Name
        public string LastName { get; set; }     // Фамилия / LastName
        public string PhoneNumber { get; set; }  // Номер телефона / Phone number
        public string Email { get; set; }        // Email
    }
}
