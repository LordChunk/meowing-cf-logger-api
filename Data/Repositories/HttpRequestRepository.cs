using Data.Models;
using Data.Repositories.Common;

namespace Data.Repositories
{
    public class HttpRequestRepository : RepositoryBase<HttpRequest>
    {
        internal HttpRequestRepository(ApplicationContext repositoryContext) : base(repositoryContext) {}
    }
}