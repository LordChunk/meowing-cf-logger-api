using System.Linq;
using Data;
using EndPointLibs.Repositories.Common;
using Libs.Models;
using Microsoft.EntityFrameworkCore;

namespace EndPointLibs.Repositories
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