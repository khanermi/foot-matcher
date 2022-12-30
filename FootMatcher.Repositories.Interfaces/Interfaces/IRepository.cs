using FootMatcher.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FootMatcher.Repositories.Interfaces.Interfaces
{
    public interface IRepository<T>
        where T : ModelBase
    {
        T Get(Guid id);
        IEnumerable<T> Get();
        IEnumerable<T> Get(Func<T, bool> predicate);
        
        void Add(T item);
        void Add(IEnumerable<T> items);

        void Update(T item);

        void Delete(Guid id);
        void Delete(T item);
        void Delete(Func<T, bool> predicate);
    }
}
