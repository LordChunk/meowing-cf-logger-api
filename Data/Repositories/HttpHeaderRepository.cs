using Data.Models;
using Data.Repositories.Common;
using Data.Repositories.Interfaces;

namespace Data.Repositories
{
    public class HttpHeaderRepository : RepositoryBase<HttpHeader>
    {
        public HttpHeaderRepository(ApplicationContext repositoryContext) : base(repositoryContext) {}
    }
}