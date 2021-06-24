using Data.Repositories;

namespace Data
{
    public sealed class RepositoryWrapper
    {
        private readonly ApplicationContext _repositoryContext;

        private HttpHeaderRepository _httpHeader;
        private HttpRequestRepository _httpRequest;
        private TlsExportedAuthenticatorRepository _tlsExportedAuthenticator;
        private IRequestUrlRepository _requestUrl;
        private StatisticsRepository _statisticsRepository;

        public IHttpHeaderRepository HttpHeader => _httpHeader ??= new HttpHeaderRepository(_repositoryContext);
        public IHttpRequestRepository HttpRequest => _httpRequest ??= new HttpRequestRepository(_repositoryContext, HttpHeader, RequestUrl);
        public ITlsExportedAuthenticatorRepository TlsExportedAuthenticator => _tlsExportedAuthenticator ??= new TlsExportedAuthenticatorRepository(_repositoryContext);
        public IRequestUrlRepository RequestUrl => _requestUrl ??= new RequestUrlRepository(_repositoryContext);
        public StatisticsRepository Statistics => _statisticsRepository ??= new StatisticsRepository(_repositoryContext);

        public RepositoryWrapper(ApplicationContext context) => _repositoryContext = context;
    }
}