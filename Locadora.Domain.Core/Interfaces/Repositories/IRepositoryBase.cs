using System.Collections.Generic;

namespace Locadora.Domain.Core.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        void Add(T obj);
        void Update(T obj);
        void Remove(T obj);
        IEnumerable<T> GetAll();
        T GetById(int id);
    }
}
