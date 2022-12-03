namespace FrontendDentalCenter.Models
{
    public class UserViewModel
    {
        public int? Id { get; set; }
        public string Usuario { get; set; } = null!;
        public string Contraseña { get; set; } = null!;
        public int? IdMedico { get; set; }
        public int? IdPaciente { get; set; }
        public int? IdAsistente { get; set; }
        public string? Tipo { get; set; }
    }

    public class LoginData
    {
        public string Usuario { get; set; } = null!;
        public string Contraseña { get; set; } = null!;
    }
    public class LoginGetShowViewModel
    {
        public int Id { get; set; }
        public int IdMedico { get; set; }
        public int IdPaciente { get; set; }
        public int IdAsistente { get; set; }
        public string? Tipo { get; set; }
    }

    
}

