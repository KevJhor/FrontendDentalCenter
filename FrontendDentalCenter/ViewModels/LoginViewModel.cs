namespace FrontendDentalCenter.ViewModels
{
    public class LoginPacientePostViewModel
    {
        public string Usuario { get; set; } = null!;
        public string Contraseña { get; set; } = null!;
        public int? IdPaciente { get; set; }
        public string? Tipo { get; set; }
    }
}
