using SolProyecto.DataAccess.DBEntities.Abstraccions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolProyecto.DataAccess.DBEntities
{

    [Table("TbCliente")]
    public class ClienteEntity : EntityBase
    {
 
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string numeroDocumento { get; set; }
        public string correo { get; set; }
        public string clave { get; set; }
    }
}
