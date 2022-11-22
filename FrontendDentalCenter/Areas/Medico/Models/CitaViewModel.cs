namespace FrontendDentalCenter.Areas.Medico.Models
{
    public class CitaViewModel
    {
        public int IdCita { get; set; }
        public int? IdPaciente { get; set; }
        public int? IdMedico { get; set; }
        public string? Estado { get; set; }
        public DateTime? FechaHora { get; set; }
    }
}
