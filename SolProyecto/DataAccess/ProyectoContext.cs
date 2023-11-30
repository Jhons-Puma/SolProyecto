using Microsoft.EntityFrameworkCore;
using SolProyecto.DataAccess.DBEntities;

namespace SolProyecto.DataAccess
{
    public class ProyectoContext :DbContext
    {
        public DbSet<ClienteEntity> TbCliente { get; set; }
        public DbSet<PedidosEntity> TbPedido { get; set; }
        public DbSet<ProductoEntity> TbProducto { get; set; }
        public DbSet<DetallePedidosEntity> TbDetallePedido { get; set; }

        public ProyectoContext(DbContextOptions<ProyectoContext> option) : base(option)
        {
            
        }
    }
}
