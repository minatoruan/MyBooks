namespace MyBooks.Model.Entities
{
    public class CredentialLogOn : EntityBase
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Hint { get; set; }
    }
}