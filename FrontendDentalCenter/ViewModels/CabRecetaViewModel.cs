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


    public class RecetaViewModel
    {
        public int IdDetRecetaMedica { get; set; }
        public int? IdRecetaMedica { get; set; }
        public int? IdMedicamento { get; set; }
        public double? Dosis { get; set; }
        public string? UnidadMedida { get; set; }
        public string? Descripcion { get; set; }
    }
    public class RecetaViewModelPost
    {
        public int? IdRecetaMedica { get; set; }
        public int? IdMedicamento { get; set; }
        public double? Dosis { get; set; }
        public string? UnidadMedida { get; set; }
        public string? Descripcion { get; set; }
    }
    public class ValoresTablaMedicamentoViewModel
    {
        public string? Medicamento { get; set; }
        public string? Dosis { get; set; }
        public string? UnidadMedida { get; set; }
        public string? Descripcion { get; set; }
    }


}
