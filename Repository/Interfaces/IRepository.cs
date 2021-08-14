using PremierAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PremierAPI.Repository.Interfaces
{
    public interface IRepository<T>
    {
        T GetById(int id);
        List<T> GetAll();
        T Create(T entity);
        T Update(T entity);
        T Delete(int id);
    }
}
