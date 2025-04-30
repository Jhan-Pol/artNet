namespace artNet.Services.Dtos
{
    public class PublicacionesModels
    {
         public List<PublicacionesModels> Publicaciones { get; set; }
        public PublicacionesModels()
        {
            Publicaciones = new List<PublicacionesModels>();
        }
    }

    public class PublicacionModels
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Estado { get; set; }

        public PublicacionModels()
        {
            Title = string.Empty; // Initialize Title with a default non-null value
            Description = string.Empty; // Initialize Description with a default non-null value
            Estado = false; // Default value for Estado
            Id = Guid.NewGuid(); // Generate a new Guid
        }
    }
}
