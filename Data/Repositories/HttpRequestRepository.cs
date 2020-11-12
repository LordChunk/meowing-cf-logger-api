using System.Linq;
using Data.Models;
using Data.Repositories.Common;
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