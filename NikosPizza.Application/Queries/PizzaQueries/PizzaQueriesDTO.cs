using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikosPizza.Application.Queries.PizzaQueries
{
    public class PizzaQueriesDTO
    {
        public Guid Id { get; set; }
        public string Nombre {  get; set; }
        public string Precio { get; set; }
        public string Descripcion { get; set; }
        public string Url { get; set; }
        public Guid? TamanoPizzaId { get; set; }
    }
}
