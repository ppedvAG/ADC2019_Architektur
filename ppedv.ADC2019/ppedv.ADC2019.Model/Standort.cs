using System.Collections.Generic;

namespace ppedv.ADC2019.Model
{
    public class Standort : Entity
    {
        public string Name { get; set; }
        public ICollection<Auto> Autos { get; set; } = new HashSet<Auto>();
    }
}
