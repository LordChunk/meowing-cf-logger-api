﻿using System.Linq;
using Data.Repositories.Common;
using Libs.Models;
using Libs.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    internal class HttpRequestRepository : RepositoryBase<HttpRequest>, IHttpRequestRepository
    {
        public HttpRequestRepository(ApplicationContext repositoryContext) : base(repositoryContext) {}

        protected override IQueryable<HttpRequest> GetQueryBase()
        {
            return base.GetQueryBase()
                .Include(b => b.Cf);
        }
    }
}