using System;

namespace ppedv.ADC2019.Model
{
    public class Vermietung : Entity
    {
        public DateTime Datum { get; set; }
        public DateTime Ende { get; set; }
        public virtual Standort StartStandort { get; set; }
        public virtual Standort ZielStandort { get; set; }
        public virtual Auto Auto { get; set; }
        public virtual Kunde Kunde { get; set; }
    }
}
