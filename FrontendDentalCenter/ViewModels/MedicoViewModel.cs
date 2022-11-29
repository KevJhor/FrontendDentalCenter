namespace FrontendDentalCenter.ViewModels
{
    public class MedicoViewModel
    {
        public int IdMedico { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Genero { get; set; }
    }
    public class MedicoViewModelPost
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Genero { get; set; }
    }
}