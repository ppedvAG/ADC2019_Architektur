using ppedv.ADC2019.Model;
using ppedv.ADC2019.Model.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace ppedv.ADC2019.Data.EF
{
    public class EfAutoRepository : EfRepository<Auto>, IAutoRepository
    {
        public EfAutoRepository(EfContext con) : base(con)
        { }

        public IEnumerable<Auto> GetAlleAutoDieBlauSind()
        {
            return con.Autos.Where(x => x.Farbe == "blau");
        }
    }
}
