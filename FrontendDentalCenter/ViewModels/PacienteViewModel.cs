namespace FrontendDentalCenter.ViewModels
{
    public class PacienteViewModel
    {
        public int IdPaciente { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public int? Dni { get; set; }
        public DateTime? FechaDeNac { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public bool? Frecuente { get; set; }
    }
    public class Paciente2ViewModel
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public int? Dni { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
    }
    public class PacienteViewModelPost
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public int? Dni { get; set; }
        public DateTime? FechaDeNac { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public bool? Frecuente { get; set; }
    }
    public class PacienteViewModelPost2
    {
        public int IdPaciente { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public int? Dni { get; set; }
        public DateTime? FechaDeNac { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }

    }

}
