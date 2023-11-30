
using System.Collections.Generic;

namespace SolProyecto.Models
{
    public class ConfirmarCarritoCompraModel
    {

        public string nombre { get; set; }
        public string apellido { get; set; }
        public string numeroDocumento { get; set; }
        public string correo { get; set; }
        public string clave { get; set; }


 
        public string tarjetaCredito { get; set; }
        public string fechaVenCredito { get; set; }
        public string CVV { get; set; }
        public string email { get; set; }



        public List<ProductTemporalModel> TemporalProducts { get; set; }
        public ConfirmarCarritoCompraModel()
        {
            TemporalProducts = new List<ProductTemporalModel>();
        }
    }
}
