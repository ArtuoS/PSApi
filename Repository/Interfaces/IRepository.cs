using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremierAPI.Repository.Interfaces
{
    public interface IRepository<T>
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        T Insert(T entity);
        T Update(T entity);
        T Delete(T entity);
    }
}
