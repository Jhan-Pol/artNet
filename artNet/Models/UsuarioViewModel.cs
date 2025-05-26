namespace artNet.Models
{
    public class UsuarioViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = "";         
        public string LastName { get; set; } = "";
        public string PhotoUrl { get; set; } = "";
        public string Age { get; set; } = "";
        public string City { get; set; } = "";
        public string Country { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Email { get; set; } = "";
    }

}
