using System.Collections.Generic;

namespace ppedv.ADC2019.Model.Contracts
{
    public interface IAutoRepository : IRepository<Auto>
    {
        IEnumerable<Auto> GetAlleAutoDieBlauSind();
    }
}
