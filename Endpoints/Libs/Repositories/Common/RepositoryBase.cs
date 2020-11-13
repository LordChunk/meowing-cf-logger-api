﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Data;
using Libs.Models.Common;
using Libs.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EndPointLibs.Repositories.Common
{
    public abstract class RepositoryBase<TEntity> : RepositoryBase<TEntity, ApplicationContext>
           where TEntity : class, IEntity
    {
    }

    public abstract class RepositoryBase<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {

        internal RepositoryBase()
        {

        }

        public async Task<TEntity> Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> Get(params Expression<Func<TEntity, bool>>[] predicates)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TEntity>> GetAll(params Expression<Func<TEntity, bool>>[] predicates)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
        public virtual async Task<List<TEntity>> Remove(params Expression<Func<TEntity, bool>>[] predicates)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}