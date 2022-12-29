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
        where T : class
    {
        T Get(Guid id);
        List<T> Get();
        List<T> Get(Expression<Func<Team, bool>> predicate);
        
        void Create(T item);

        void Update(T item);

        void Delete(Guid id);
        void Delete(T item);
    }
}
