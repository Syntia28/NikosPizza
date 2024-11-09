
namespace NikosPizza.core.Entities
{
    public class Pizza
    {
        public Pizza() { }
        public Guid PizzaId { get; set; }
        public string Nombre { get; set; }
        public string Tamaño { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public DateTime Creado { get; set; }
        public DateTime? Update { get; set; }

    }
}