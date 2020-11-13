using Data;
using EndPointLibs.Repositories.Common;
using Libs.Models;
using Libs.Repositories;

namespace EndPointLibs.Repositories
{
    internal class HttpHeaderRepository : RepositoryBase<HttpHeader>, IHttpHeaderRepository
    {
        public HttpHeaderRepository(ApplicationContext repositoryContext) : base(repositoryContext) {}
    }
}