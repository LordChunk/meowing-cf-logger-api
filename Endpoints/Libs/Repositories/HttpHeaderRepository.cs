using Data;
using EndPointLibs.Repositories.Common;
using Libs.Models;

namespace EndPointLibs.Repositories
{
    internal class HttpHeaderRepository : RepositoryBase<HttpHeader>, IHttpHeaderRepository
    {
        public HttpHeaderRepository(ApplicationContext repositoryContext) : base(repositoryContext) {}
    }
}