using FootMatcher.FileSystemRepositories.Options;
using FootMatcher.Models.Models;
using FootMatcher.Repositories.Interfaces.Interfaces;
using Microsoft.Extensions.Options;
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
        protected readonly FileSystemRepositoryOptions _options;
        protected readonly string _filename;
        protected readonly string _filepath;

        public FileSystemRepository(IOptions<FileSystemRepositoryOptions> options, string filename)
        {
            _options = options.Value;
            _filename = filename;
            _filepath = Path.Combine(_options.FileSystemDbDirectoryPath, filename);

            CreateDirectoryIfNotExists();
        }

        public void Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            var items = Get().ToList();
            items.Add(item);

            SaveItems(items);
        }

        public void Add(IEnumerable<T> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            var storedItems = Get().ToList();
            storedItems.AddRange(items);

            SaveItems(storedItems);
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

            return item;
        }

        public IEnumerable<T> Get()
        {
            var fileInfo = new FileInfo(_filepath);

            using (var fs = new FileStream(fileInfo.FullName, FileMode.OpenOrCreate))
            {
                var items = new List<T>();
                try
                {
                    items.AddRange(JsonSerializer.Deserialize<List<T>>(fs));
                }
                catch (JsonException jse)
                {
                }                

                return items;
            }
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
            var fileInfo = new FileInfo(_filepath);
            if (!fileInfo.Exists)
            {
                throw new Exception($"File {fileInfo.FullName} doesn't exist");
            }

            using (var fs = new FileStream(fileInfo.FullName, FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize(fs, items);
            }
        }

        private void CreateDirectoryIfNotExists()
        {
            var currentDirectoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
            if (!currentDirectoryInfo.Exists)
            {
                throw new Exception("current directory doesnt exist");
            }

            var directory = Directory.CreateDirectory(_options.FileSystemDbDirectoryPath);
        }
    }
}
