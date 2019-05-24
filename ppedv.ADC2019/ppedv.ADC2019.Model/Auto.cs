using System.Collections.Generic;

namespace ppedv.ADC2019.Model
{
    public class Auto : Entity
    {
        public string Hersteller { get; set; }
        public string Modell { get; set; }
        public int PS { get; set; }
        public string Farbe { get; set; }
        public virtual Standort Standort { get; set; }
        public ICollection<Vermietung> Vermietungen { get; set; } = new HashSet<Vermietung>();

    }
}
