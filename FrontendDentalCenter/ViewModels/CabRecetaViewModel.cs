namespace FrontendDentalCenter.ViewModels
{
    public class CabRecetaViewModel
    {
        public int IdRecetaMedica { get; set; }
        public string? NombreDeClinica { get; set; }
        public DateTime? Fecha { get; set; }
    }
    public class CabRecetaViewModelPost
    {
        public string? NombreDeClinica { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
