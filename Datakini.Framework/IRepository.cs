using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;
namespace Datakini.Framework
{
    public interface IRepository<T>
    {
        IQueryable<T> FindAll { get; }
        IQueryable<T> FindAllIncluding(params Expression<Func<T, object>>[] includeProperties);
        T Find(object id);
        void InsertOrUpdate(T item);
        void Delete(int id);
    }
}
