using PersonalBudgetWPF.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBudgetWPF.Repos
{
    public abstract class BaseRepo<T> : IDisposable where T : class, new()
    {
        public PersonalBudgetContext Context { get; } = new PersonalBudgetContext();
        protected DbSet<T> Table;

        bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposed)
                return;
            if(disposing)
            {
                Context.Dispose();
                // Free any managed objects here
                //
            }

            // Free any unmanaged objects here
            //
            disposed = true;
        }

        internal int SaveChanges()
        {
            try
            {
                return Context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            catch (DbUpdateException)
            {
                throw;
            }
            catch (CommitFailedException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Add(T entity)
        {
            Table.Add(entity);
            return SaveChanges();
        }

        public int Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return SaveChanges();
        }

        public int Delete(T entity)
        {
            //Context.Entry(entity).State = EntityState.Deleted;
            Table.Remove(entity);
            return SaveChanges();
        }

        public T GetOne(int? id) => Table.Find(id);

        public List<T> GetAll() => Table.ToList();
    }
}
