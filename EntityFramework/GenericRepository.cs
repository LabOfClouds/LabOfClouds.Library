using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace LabOfClouds.Library.EntityFramework
{
    public class GenericRepository<TEntity, TContext>
        : IDisposable, IGenericRepository<TEntity>
        where TEntity : class
        where TContext : DbContext, new()
    {
        protected DbContext Context;
        private bool _disposed;

        #region Constructor
        public GenericRepository(bool proxyCreationEnabled = true)
        {
            Context = new TContext();
            Context.Configuration.ProxyCreationEnabled = proxyCreationEnabled;
        }
        #endregion

        #region Find

        public TEntity Find(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        #endregion

        #region List

        public List<TEntity> List()
        {
            return Context.Set<TEntity>().ToList();
        }

        public List<TEntity> List(int page, int pageSize)
        {
            var model = List()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            return model;
        }

        #endregion

        #region Limit

        public List<TEntity> Limit(int size)
        {
            var model = List()
                .Take(size)
                .ToList();
            return model;
        }

        #endregion

        #region SelectList

        public List<SelectListItem> SelectList(Func<TEntity, SelectListItem> expression)
        {
            List<SelectListItem> list = List().Select(expression).ToList();

            list.Add(new SelectListItem { Value = "", Text = "--- Selecione ---" });

            list = list.OrderBy(x => x.Text).ToList();

            return list;
        }

        #endregion

        #region Count

        public int Count()
        {
            return Context.Set<TEntity>().Count();
        }

        #endregion

        #region Add

        public void Add(TEntity item)
        {
            Context.Set<TEntity>().Add(item);
        }

        #endregion

        #region Remove

        public void Remove(TEntity item)
        {
            Context.Set<TEntity>().Remove(item);
        }

        public void RemoveById(int id)
        {
            var item = Find(id);
            Remove(item);
        }

        #endregion

        #region Edit

        public void Edit(TEntity item)
        {
            Context.Entry(item).State = EntityState.Modified;
        }

        #endregion

        #region Dispose

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region Save

        public void Save()
        {
            Context.SaveChanges();
        }

        #endregion
    }
}