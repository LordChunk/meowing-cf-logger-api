using System.Linq;
using System.Threading.Tasks;
using Data.Models;
using Data.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    internal class HttpRequestRepository : RepositoryBase<HttpRequest>, IHttpRequestRepository
    {
        private readonly IHttpHeaderRepository _httpHeaderRepository;

        public HttpRequestRepository(ApplicationContext repositoryContext, IHttpHeaderRepository httpHeaderRepository) : base(repositoryContext)
        {
            _httpHeaderRepository = httpHeaderRepository;
        }

        protected override IQueryable<HttpRequest> GetQueryBase()
        {
            return base.GetQueryBase()
                .Include(b => b.Cf)
                .Include(b => b.Headers);
        }

        public override async Task<HttpRequest> Add(HttpRequest request)
        {
            var headers = request.Headers;
            request.Headers = null;

            var headersWithId = headers.Select(header =>
            {
                var storedHeader = _httpHeaderRepository.Get(
                    h => h.Header == header.Header, 
                    h => h.Value == header.Value
                ).Result;
                
                return storedHeader ?? _httpHeaderRepository.Add(header).Result;
            });

            request.Headers = headersWithId.ToList();
            
            return await base.Add(request);
        }
    }
}