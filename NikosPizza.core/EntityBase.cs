using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikosPizza.core
{
    public abstract class EntityBase
    {
        public DateTime? Creado { get; set; }
        public DateTime? Update { get; set; }
    }
}
