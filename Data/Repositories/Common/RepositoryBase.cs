using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Interface.Data;
using Interface.Models.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data.Repositories.Common
{
    public abstract class RepositoryBase<TEntity> : RepositoryBase<TEntity, ApplicationContext>
           where TEntity : class, IEntity
    {
        internal RepositoryBase(ApplicationContext context) : base(context)
        {
        }
    }

    public abstract class RepositoryBase<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        private static readonly ILogger<RepositoryBase<TEntity, TContext>> Logger = DataLogger.CreateLogger<RepositoryBase<TEntity, TContext>>();
        protected readonly TContext Context;
        protected readonly DbSet<TEntity> DbSet;

        internal RepositoryBase(TContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        protected virtual IQueryable<TEntity> GetQueryBase()
        {
            return DbSet;
        }

        public virtual async Task<TEntity> Add(TEntity entity)
        {
            Logger.LogInformation($"Adding entity type: {entity.GetType()} to database");
            await DbSet.AddAsync(entity);

            var changed = await Context.SaveChangesAsync();
            Logger.LogInformation($"Added entity to database");
            Logger.LogDebug($"{entity}");
            return changed > 0 ? entity : null;
        }

        public async Task<TEntity> Get(params Expression<Func<TEntity, bool>>[] predicates)
        {
            Logger.LogInformation($"Getting 1 item from database");
            
            var item = await predicates
                .Aggregate(
                    GetQueryBase(),
                    (query, predicate) => query.Where(predicate))
                .FirstOrDefaultAsync();

            Logger.LogDebug($"Found item: {item}");
            return item;
        }

        public async Task<List<TEntity>> GetAll(params Expression<Func<TEntity, bool>>[] predicates)
        {
            Logger.LogInformation($"Getting many items from database");

            var items = await predicates
                .Aggregate(
                    GetQueryBase(),
                    (query, predicate) => query.Where(predicate))
                .ToListAsync();

            Logger.LogInformation($"Got {items.Count} items");

            //if (Logger.IsDebugEnabled)
            //{
            //    foreach (var entity in items)
            //        Logger.LogDebug(entity.ToString());
            //}

            return items;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            Logger.LogInformation("Updating item");
            Logger.LogDebug(entity.ToString());
            Context.Entry(entity).State = EntityState.Modified;

            var changed = await Context.SaveChangesAsync();
            Logger.LogInformation("Saved updates");
            return changed > 0 ? entity : null;
        }
        public virtual async Task<List<TEntity>> Remove(params Expression<Func<TEntity, bool>>[] predicates)
        {
            Logger.LogInformation("Removing many items from database");
            var entities = await GetAll(predicates);
            Logger.LogInformation($"Found {entities.Count} items to remove");
            //if (Logger.IsDebugEnabled)
            //{
            //    foreach (var entity in entities)
            //        Logger.LogDebug(entity.ToString());
            //}
            
            await using var transaction = await Context.Database.BeginTransactionAsync();
            try
            {
                Context.RemoveRange(entities);
                int deleted = await Context.SaveChangesAsync();

                await transaction.CommitAsync();

                if (deleted == entities.Count)
                {
                    Logger.LogInformation("Successfully removed all entities");
                    return entities;
                }
                
                await transaction.RollbackAsync();
                Logger.LogWarning($"Delete query only removed {deleted} entities instead of {entities.Count}. No items were deleted.");
            }
            catch (Exception e)
            {
                Logger.LogError("An error occured while removing items from the database");
                Logger.LogError(e.ToString());
            }

            return null;
        }

        public async Task<TEntity> Remove(TEntity entity)
        {
            Logger.LogInformation("Removing 1 item from database");
            Logger.LogDebug(entity.ToString());
            Context.Remove(entity);

            var changed = await Context.SaveChangesAsync();
            Logger.LogInformation("Removed item from database");
            return changed > 0 ? entity : null;
        }
    }
}