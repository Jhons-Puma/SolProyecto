using System.ComponentModel.DataAnnotations;

namespace SolProyecto.DataAccess.DBEntities.Abstraccions
{
    public class EntityBase
    {
        [Key]
        public int id { get; set; }
        public bool estado { get; set; }
    }
}
