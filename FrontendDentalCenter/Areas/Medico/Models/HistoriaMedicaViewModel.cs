namespace FrontendDentalCenter.Areas.Medico.Models
{
    public class HistoriaMedicaViewModel
    {
        public int IdDetHistoriaMedica { get; set; }
        public int IdHistoriaMedica { get; set; }
        public int? IdCita { get; set; }
        public int IdMedico { get; set; }
        public int IdAsistente { get; set; }
        public int? IdRecetaMedica { get; set; }
        public int? IdTratamiento { get; set; }
    }
}
