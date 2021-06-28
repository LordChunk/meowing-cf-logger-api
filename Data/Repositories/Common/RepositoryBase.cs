using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Data.Models.Common;
using Microsoft.EntityFrameworkCore;
using NLog;

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
        private static readonly Logger Logger = NLog.LogManager.GetCurrentClassLogger();
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
            Logger.Info($"Adding entity type: {entity.GetType()} to database");
            await DbSet.AddAsync(entity);

            var changed = await Context.SaveChangesAsync();
            Logger.Info($"Added entity to database");
            Logger.Debug($"{entity}");
            return changed > 0 ? entity : null;
        }

        public async Task<TEntity> Get(params Expression<Func<TEntity, bool>>[] predicates)
        {
            Logger.Info($"Getting 1 item from database");
            
            var item = await predicates
                .Aggregate(
                    GetQueryBase(),
                    (query, predicate) => query.Where(predicate))
                .FirstOrDefaultAsync();

            Logger.Debug($"Found item: {item}");
            return item;
        }

        public async Task<List<TEntity>> GetAll(params Expression<Func<TEntity, bool>>[] predicates)
        {
            Logger.Info($"Getting many items from database");

            var items = await predicates
                .Aggregate(
                    GetQueryBase(),
                    (query, predicate) => query.Where(predicate))
                .ToListAsync();

            Logger.Info($"Got {items.Count} items");

            if (Logger.IsDebugEnabled)
            {
                foreach (var entity in items)
                    Logger.Debug(entity.ToString());
            }
            
            return items;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            Logger.Info("Updating item");
            Logger.Debug(entity.ToString());
            Context.Entry(entity).State = EntityState.Modified;

            var changed = await Context.SaveChangesAsync();
            Logger.Info("Saved updates");
            return changed > 0 ? entity : null;
        }
        public virtual async Task<List<TEntity>> Remove(params Expression<Func<TEntity, bool>>[] predicates)
        {
            Logger.Info("Removing many items from database");
            var entities = await GetAll(predicates);
            Logger.Info($"Found {entities.Count} items to remove");
            if (Logger.IsDebugEnabled)
            {
                foreach (var entity in entities)
                    Logger.Debug(entity.ToString());
            }
            
            await using var transaction = await Context.Database.BeginTransactionAsync();
            try
            {
                Context.RemoveRange(entities);
                int deleted = await Context.SaveChangesAsync();

                await transaction.CommitAsync();

                if (deleted == entities.Count)
                {
                    Logger.Info("Successfully removed all entities");
                    return entities;
                }
                
                await transaction.RollbackAsync();
                Logger.Warn($"Delete query only removed {deleted} entities instead of {entities.Count}. No items were deleted.");
            }
            catch (Exception e)
            {
                Logger.Error("An error occured while removing items from the database");
                Logger.Error(e.ToString());
            }

            return null;
        }

        public async Task<TEntity> Remove(TEntity entity)
        {
            Logger.Info("Removing 1 item from database");
            Logger.Debug(entity.ToString());
            Context.Remove(entity);

            var changed = await Context.SaveChangesAsync();
            Logger.Info("Removed item from database");
            return changed > 0 ? entity : null;
        }
    }
}