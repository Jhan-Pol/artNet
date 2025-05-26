namespace artNet.Domain.Entities.User
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; } // Hash, no texto plano
        public string Email { get; set; }

    }
}
