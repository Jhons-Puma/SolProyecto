using SolProyecto.DataAccess.DBEntities.Abstraccions;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolProyecto.DataAccess.DBEntities
{
    [Table("TbDetallePedido")]
    public class DetallePedidosEntity : EntityBase
    {
        public double? precioFinal { get; set; }
        public virtual ProductoEntity TbProducto { get; set; }
        public virtual PedidosEntity TbPedido { get; set; }
    }
}
