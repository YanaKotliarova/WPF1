using System.ComponentModel.DataAnnotations;

namespace WPF1
{
    internal class User
    {
        [Key]
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public User() { }
        public User(string[] data)
        {
            Date = DateOnly.Parse(data[0]);
            FirstName = data[1];
            LastName = data[2];
            Patronymic = data[3];
            City = data[4];
            Country = data[5];
        }
    }
}
