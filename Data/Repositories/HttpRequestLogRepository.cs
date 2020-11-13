﻿using Data.Repositories.Common;
using Libs.Models;
using Libs.Repositories;

namespace Data.Repositories
{
    internal class HttpRequestLogRepository : RepositoryBase<HttpRequestLog>, IHttpRequestLogRepository
    {
        public HttpRequestLogRepository(ApplicationContext context) : base(context) {}
    }
}