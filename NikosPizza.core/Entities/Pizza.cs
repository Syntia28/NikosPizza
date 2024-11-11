
namespace NikosPizza.core.Entities
{
    public class Pizza : EntityBase
    {
        public Pizza() { }
        public Guid PizzaId { get; set; }
        public string Nombre { get; set; }
        public Guid? TamanioPizzaId { get; set; }
        public TamanioPizza? TamanioPizza { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public string ImagenUrl { get; set; }
    }
}