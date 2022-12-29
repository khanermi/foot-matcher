using FootMatcher.Models.Models;
using FootMatcher.Repositories.Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FootMatcher.FileSystemRepositories.Repositories
{
    public class FileSystemRepository<T> : IRepository<T>
        where T : class
    {
        public void Create(T item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Delete(T item)
        {
            throw new NotImplementedException();
        }

        public T Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<T> Get()
        {
            throw new NotImplementedException();
        }

        public List<T> Get(Expression<Func<Team, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
