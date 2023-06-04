namespace FrontendDentalCenter.ViewModels
{
    public class HistoriaMedicaViewModelPost
    {
        public int IdHistoriaMedica { get; set; }
        public int? IdCita { get; set; }
        public int IdMedico { get; set; }
        public int IdAsistente { get; set; }
        public int? IdRecetaMedica { get; set; }
        public int? IdTratamiento { get; set; }
    }
    public class CabHistoriaMedicaViewModelPost
    {
        public int? IdPaciente { get; set; }
        public DateTime? FechaDeActualizacion { get; set; }
    }
}
