using ppedv.ADC2019.Model;
using ppedv.ADC2019.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.ADC2019.Data.EF
{
    public class EfRepository<T> : IRepository<T> where T : Entity
    {
        protected EfContext con;
        public EfRepository(EfContext con)
        {
            this.con = con;
        }

        public void Add(T entity)
        {
            //if (typeof(T) == typeof(Auto))
            //    con.Autos.Add(entity as Auto);
            con.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            con.Set<T>().Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return con.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return con.Set<T>().Find(id);
        }

        public IQueryable<T> Query()
        {
            return con.Set<T>();
        }

        public void Update(T entity)
        {
            var loaded = GetById(entity.Id);
            if (loaded != null)
            {
                con.Entry(loaded).CurrentValues.SetValues(entity);
            }
        }
    }

    public class EfAutoRepository : EfRepository<Auto>, IAutoRepository
    {
        public EfAutoRepository(EfContext con) : base(con)
        { }

        public IEnumerable<Auto> GetAlleAutoDieBlauSind()
        {
            return con.Autos.Where(x => x.Farbe == "blau");
        }
    }


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
