namespace FrontendDentalCenter.Areas.Paciente.Models
{
    public class PacienteCitaViewModel
    {
        public int IdCita { get; set; }
        public int? IdPaciente { get; set; }
        public int? IdMedico { get; set; }
        public string? Estado { get; set; }
        public DateTime? FechaHora { get; set; }
    }
    public class PacienteCitaViewModelPost
    {
        public int? IdPaciente { get; set; }
        public int? IdMedico { get; set; }
        public string? Estado { get; set; }
        public DateTime? FechaHora { get; set; }
    }
}