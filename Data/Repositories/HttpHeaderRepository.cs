using Data.Models;
using Data.Repositories.Common;

namespace Data.Repositories
{
    public class HttpHeaderRepository : RepositoryBase<HttpHeader>
    {
        public HttpHeaderRepository(ApplicationContext repositoryContext) : base(repositoryContext) {}
    }
}