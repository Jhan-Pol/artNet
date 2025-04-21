namespace artNet.Models
{
    public class ComentariosViewModels
    {
        //Se ve un los comentarios sin cargar el mural entero
        public int Id { get; set; }
        public string Autor { get; set; }
        public string Contenido { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
