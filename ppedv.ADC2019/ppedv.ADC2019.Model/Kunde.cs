using System;
using System.Collections.Generic;

namespace ppedv.ADC2019.Model
{
    public class Kunde : Entity
    {
        public string Name { get; set; }
        public DateTime GebDatum { get; set; }
        public ICollection<Vermietung> Vermietungen { get; set; } = new HashSet<Vermietung>();
    }
}
