using Data.Repositories;
using Interface.Data;

namespace Data
{
    public sealed class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly ApplicationContext _repositoryContext;

        private HttpHeaderRepository _httpHeader;
        private HttpRequestRepository _httpRequest;
        private RequestUrlRepository _requestUrl;
        private StatisticsRepository _statisticsRepository;

        public IHttpHeaderRepository HttpHeader => _httpHeader ??= new HttpHeaderRepository(_repositoryContext);
        public IHttpRequestRepository HttpRequest => _httpRequest ??= new HttpRequestRepository(_repositoryContext, HttpHeader, RequestUrl);
        public IRequestUrlRepository RequestUrl => _requestUrl ??= new RequestUrlRepository(_repositoryContext);
        public IStatisticsRepository Statistics => _statisticsRepository ??= new StatisticsRepository(_repositoryContext);

        public RepositoryWrapper(ApplicationContext context) => _repositoryContext = context;
    }
}