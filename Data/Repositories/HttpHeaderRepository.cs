using Data.Models;
using Data.Repositories.Common;

namespace Data.Repositories
{
    public class HttpHeaderRepository : RepositoryBase<HttpHeader>
    {
        internal HttpHeaderRepository(ApplicationContext repositoryContext) : base(repositoryContext) {}
    }
}