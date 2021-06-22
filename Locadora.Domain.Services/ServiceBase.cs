using Locadora.Domain.Core.Interfaces.Repositories;
using Locadora.Domain.Core.Interfaces.Services;
using System.Collections.Generic;

namespace Locadora.Domain.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T : class
    {
        private readonly IRepositoryBase<T> repository;

        public ServiceBase(IRepositoryBase<T> _repository)
        {
            repository = _repository;
        }

        public void Add(T obj)
        {
            repository.Add(obj);
        }

        public IEnumerable<T> GetAll()
        {
            return repository.GetAll();
        }

        public T GetById(int id)
        {
            return repository.GetById(id);
        }

        public void Remove(T obj)
        {
            repository.Remove(obj);
        }

        public void Update(T obj)
        {
            repository.Update(obj);
        }
    }
}
