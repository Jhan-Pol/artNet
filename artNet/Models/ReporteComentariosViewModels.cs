namespace artNet.Models
{
    public class ReporteComentariosViewModels
    {
        public int ComentarioId { get; set; }
        public string? ContenidoComentario { get; set; }
        public string ReportePor { get; set; }
        public string? Motivo { get; set; }
        public DateTime FechaReporte { get; set; }
    }
}
