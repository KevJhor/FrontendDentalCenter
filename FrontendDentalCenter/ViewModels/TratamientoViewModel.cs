namespace FrontendDentalCenter.ViewModels
{
    public class TratamientoViewModel
    {
        public int IdTratamiento { get; set; }
        public string? Tipo { get; set; }
        public int? DuracionDias { get; set; }
        public double? Precio { get; set; }
        public string? Descripcion { get; set; }
    }
    public class TratamientoViewModelPost
    {
        public string? Tipo { get; set; }
        public int? DuracionDias { get; set; }
        public double? Precio { get; set; }
        public string? Descripcion { get; set; }
    }
}
