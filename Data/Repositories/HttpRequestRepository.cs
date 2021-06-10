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
        private readonly IRequestUrlRepository _requestUrlRepository;

        public HttpRequestRepository(
            ApplicationContext repositoryContext, 
            IHttpHeaderRepository httpHeaderRepository, 
            IRequestUrlRepository requestUrlRepository
        ) : base(repositoryContext)
        {
            _httpHeaderRepository = httpHeaderRepository;
            _requestUrlRepository = requestUrlRepository;
        }

        protected override IQueryable<HttpRequest> GetQueryBase()
        {
            return base.GetQueryBase()
                .Include(b => b.Cf)
                .Include(b => b.Headers);
        }

        public override async Task<HttpRequest> Add(HttpRequest request)
        {
            // Add RequestUrl to database
            var url = request.Url;
            request.Url = await _requestUrlRepository.Get(u => u.Url == url.Url) ??
                          await _requestUrlRepository.Add(url);

            // Add HttpHeaders to database
            var headers = request.Headers;
            request.Headers = headers.Select(header =>
            {
                var storedHeader = _httpHeaderRepository.Get(
                    h => h.Header == header.Header, 
                    h => h.Value == header.Value
                ).Result;
                
                return storedHeader ?? _httpHeaderRepository.Add(header).Result;
            }).ToList();
            
            
            return await base.Add(request);
        }
    }
}