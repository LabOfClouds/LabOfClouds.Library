using System.Collections.Generic;

namespace LabOfClouds.Library.EntityFramework
{
    public interface IGenericRepository<TEntity>
        where TEntity : class
    {
        TEntity Find(int id);
        List<TEntity> List();
        void Add(TEntity item);
        void Remove(TEntity item);
        void RemoveById(int id);
        void Edit(TEntity item);
        void Dispose();
        void Save();
    }
}