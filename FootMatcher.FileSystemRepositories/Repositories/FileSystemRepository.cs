using FootMatcher.Models.Models;
using FootMatcher.Repositories.Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FootMatcher.FileSystemRepositories.Repositories
{
    public class FileSystemRepository<T> : IRepository<T>
        where T : ModelBase
    {
        private readonly string _filePath; 

        public FileSystemRepository(string filePath)
        {
            _filePath = filePath;
        }

        public void Create(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            var items = Get().ToList();
            items.Add(item);

            SaveItems(items);
        }

        public void Delete(Guid id)
        {
            Delete(x => x.Id == x.Id);
        }

        public void Delete(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            Delete(item.Id);
        }

        public void Delete(Func<T, bool> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            var items = Get();
            SaveItems(items.Where(x => !predicate(x)));
        }

        public T Get(Guid id)
        {
            var item = Get(x => x.Id == id)
                .FirstOrDefault();

            if (item == null)
            {
                throw new Exception($"Item {item.Id} not found");
            }

            return item;
        }

        public IEnumerable<T> Get()
        {
            var fileInfo = new FileInfo(_filePath);
            if (!fileInfo.Exists)
            {
                throw new Exception($"File {fileInfo.FullName} doesn't exist");
            }

            using var fs = new FileStream(fileInfo.FullName, FileMode.OpenOrCreate);
            
            var items = JsonSerializer.Deserialize<List<T>>(fs);

            return items;
        }

        public IEnumerable<T> Get(Func<T, bool> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            return Get().Where(predicate);
        }

        public void Update(T item)
        {
            var items = Get().Where(x => x.Id != item.Id)
                .ToList();
            items.Add(item);

            SaveItems(items);
        }

        private void SaveItems(IEnumerable<T> items)
        {
            var fileInfo = new FileInfo(_filePath);
            if (!fileInfo.Exists)
            {
                throw new Exception($"File {fileInfo.FullName} doesn't exist");
            }

            using var fs = new FileStream(fileInfo.FullName, FileMode.OpenOrCreate);

            JsonSerializer.Serialize(fs, items);
        }
    }
}
