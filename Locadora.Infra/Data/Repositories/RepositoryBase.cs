using Locadora.Domain.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Locadora.Infra.Data.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T: class
    {
        protected LocadoraContext locadoraContext = new LocadoraContext();
        public RepositoryBase(LocadoraContext _locadoraContext)
        {
            locadoraContext = _locadoraContext;
        }

        public void Add(T obj)
        {
            try
            {
                locadoraContext.Set<T>().Add(obj);
                locadoraContext.SaveChanges();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public IEnumerable<T> GetAll()
        {
            return locadoraContext.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return locadoraContext.Set<T>().Find(id);
        }

        public void Remove(T obj)
        {
            try
            {
                locadoraContext.Set<T>().Remove(obj);
                locadoraContext.SaveChanges();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void Update(T obj)
        {
            try
            {
                locadoraContext.Entry(obj).State = EntityState.Modified;
                locadoraContext.SaveChanges();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}
