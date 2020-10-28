using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Models.Common;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class RepositoryBase<TModel> where TModel : EntityBase
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TModel> _table;

        public RepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;
            _table = _dbContext.Set<TModel>();
        }

        public async void Add(IEnumerable<TModel> itemList) => await _table.AddRangeAsync(itemList);

        public async void Add(TModel item) => await _table.AddAsync(item);

        public void Delete(IEnumerable<TModel> itemList) => _table.RemoveRange(itemList);

        public void Delete(TModel item) => _table.Remove(item);

        public DbSet<TModel> Get() => _table;

        public async ValueTask<TModel> Get(int id) => await _table.FindAsync(id);

        public async ValueTask<IEnumerable<TModel>> Get(IEnumerable<int> ids)
        {
            var list = new List<TModel>();
            foreach (var id in ids)
            {
                list.Add(await Get(id));
            }
            return list;
        }

        public void Update(TModel item) => _table.Update(item);

        public void Update(IEnumerable<TModel> itemList) => _table.UpdateRange(itemList);

        public async ValueTask<int> Save() => await _dbContext.SaveChangesAsync();
    }
}