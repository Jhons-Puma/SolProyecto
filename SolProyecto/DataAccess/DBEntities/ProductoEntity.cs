using SolProyecto.DataAccess.DBEntities.Abstraccions;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolProyecto.DataAccess.DBEntities
{
    [Table("TbProducto")]
    public class ProductoEntity : EntityBase
    {
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
