namespace WPF1
{
    internal class User
    {
        internal int Id { get; set; }
        internal DateOnly Date { get; set; }
        internal string FirstName { get; set; }
        internal string LastName { get; set; }
        internal string Patronymic { get; set; }
        internal string City { get; set; }
        internal string Country { get; set; }

        internal User() { }
        internal User(string[] data)
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
