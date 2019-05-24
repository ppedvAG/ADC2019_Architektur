using ppedv.ADC2019.Model;
using ppedv.ADC2019.Model.Contracts;
using System;

namespace ppedv.ADC2019.Data.EF
{
    public class EfUnitOfWork : IUnitOfWork, IDisposable
    {
        EfContext con = new EfContext();

        public IAutoRepository AutoRepository => new EfAutoRepository(con);

        public void Dispose()
        {
            con.Dispose();
        }

        public IRepository<T> GetRepo<T>() where T : Entity
        {
            return new EfRepository<T>(con);
        }

        public void SaveAll()
        {
            con.SaveChanges();
        }
    }
}
