﻿using Data.Repositories.Common;
using Libs.Models;
using Libs.Repositories;

namespace Data.Repositories
{
    internal class HttpHeaderRepository : RepositoryBase<HttpHeader>, IHttpHeaderRepository
    {
        public HttpHeaderRepository(ApplicationContext repositoryContext) : base(repositoryContext) {}
    }
}