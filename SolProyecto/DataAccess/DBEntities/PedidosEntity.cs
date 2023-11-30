using SolProyecto.DataAccess.DBEntities.Abstraccions;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolProyecto.DataAccess.DBEntities
{
    [Table("TbPedido")]
    public class PedidosEntity : EntityBase
    {
        public DateTime fechaOrden { get; set; }
        public string tarjetaCredito { get; set; }
        public string fechaVenCredito { get; set; }
        public string CVV { get; set; }
        public string email { get; set; }
        public virtual ClienteEntity TbCliente { get; set; }
        public double precio { get; set; }
    }
}
