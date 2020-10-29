using System.Threading.Tasks;
using Data.Repositories.Interfaces;

namespace Data.Repositories.Common
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly RepositoryContext _repositoryContext;

        private ICfHttpHeaderRepository _cfHttpHeader;
        private IHttpHeaderRepository _httpHeader;
        private IHttpRequestRepository _httpRequest;
        private ITlsClientAuthRepository _tlsClientAuth;
        private ITlsExportedAuthenticatorRepository _tlsExportedAuthenticator;

        public ICfHttpHeaderRepository CfHttpHeader => _cfHttpHeader ??= new CfHttpHeaderRepository(_repositoryContext);
        public IHttpHeaderRepository HttpHeader => _httpHeader ??= new HttpHeaderRepository(_repositoryContext);
        public IHttpRequestRepository HttpRequest => _httpRequest ??= new HttpRequestRepository(_repositoryContext);
        public ITlsClientAuthRepository TlsClientAuth => _tlsClientAuth ??= new TlsClientAuthRepository(_repositoryContext);
        public ITlsExportedAuthenticatorRepository TlsExportedAuthenticator => _tlsExportedAuthenticator ??= new TlsExportedAuthenticatorRepository(_repositoryContext);


        public RepositoryWrapper(RepositoryContext repositoryContext) => _repositoryContext = repositoryContext;
        public async Task Save() => await _repositoryContext.SaveChangesAsync();
    }
}