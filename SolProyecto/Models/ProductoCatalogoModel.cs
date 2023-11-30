namespace SolProyecto.Models
{
    public class ProductoCatalogoModel
    {
        public int ProductoId { get; set; }
        public string marca { get; set; }
        public string SKU { get; set; }
        public double? precioInicial { get; set; }
        public double? descuento { get; set; }
        public double? precioFinal { get; set; }
        public int stock { get; set; }
        public bool? envio { get; set; }
        public bool? delibery { get; set; }
        public bool? retiroTienda { get; set; }
        public string imgURL { get; set; }
        public string descripcipn { get; set; }
    }
}
