using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ppedv.ADC2019.Model.Contracts
{
    public interface IRepository<T> where T : Entity
    {
        IEnumerable<T> GetAll();
        IQueryable<T> Query();
        T GetById(int id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
