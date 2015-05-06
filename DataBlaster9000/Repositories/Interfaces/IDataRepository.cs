using System.Collections.Generic;

namespace DataBlaster3000.Repositories.Interfaces
{
    public interface IDataRepository<T> where T : class
    {
        void Add(T obj);
        void Delete(T obj);
        void Update(T obj);
        IEnumerable<T> All();
    }
}