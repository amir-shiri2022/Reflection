using System;
using System.Collections.Generic;
using System.Text;

namespace ReflectionLibrary
{
    public interface IRepository<T>
    {
        string Add(T entity);
        void Remove(T entity);
    }
    public class Repository<T> : IRepository<T>
    {
        public string Add(T entity)
        {
            return $"Adding -> {entity.ToString()}";
        }

        public void Remove(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
