using Data.Repositories;

namespace Data
{
    public sealed class RepositoryWrapper
    {
        private readonly ApplicationContext _repositoryContext;

        private CfHttpHeaderRepository _cfHttpHeader;
        private HttpHeaderRepository _httpHeader;
        private HttpRequestRepository _httpRequest;
        private TlsClientAuthRepository _tlsClientAuth;
        private TlsExportedAuthenticatorRepository _tlsExportedAuthenticator;

        private StatisticsRepository _statisticsRepository;

        public ICfHttpHeaderRepository CfHttpHeader => _cfHttpHeader ??= new CfHttpHeaderRepository(_repositoryContext);
        public IHttpHeaderRepository HttpHeader => _httpHeader ??= new HttpHeaderRepository(_repositoryContext);
        public IHttpRequestRepository HttpRequest => _httpRequest ??= new HttpRequestRepository(_repositoryContext, HttpHeader);
        public ITlsClientAuthRepository TlsClientAuth => _tlsClientAuth ??= new TlsClientAuthRepository(_repositoryContext);
        public ITlsExportedAuthenticatorRepository TlsExportedAuthenticator => _tlsExportedAuthenticator ??= new TlsExportedAuthenticatorRepository(_repositoryContext);
        public StatisticsRepository Statistics => _statisticsRepository ??= new StatisticsRepository(_repositoryContext);

        public RepositoryWrapper(ApplicationContext context) => _repositoryContext = context;
    }
}