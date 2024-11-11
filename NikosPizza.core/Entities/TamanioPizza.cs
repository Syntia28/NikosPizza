
namespace NikosPizza.core.Entities
{
    public class TamanioPizza : EntityBase
    {
        public TamanioPizza() { }
        public Guid TamanioPizzaId { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
    }
}