using EndPointLibs.Repositories;
using Libs.Repositories;


namespace EndPointLibs
{
    public class RepositoryWrapperEndpoint : IRepositoryWrapper
    {

        private CfHttpHeaderRepository _cfHttpHeader;
        private HttpHeaderRepository _httpHeader;
        private HttpRequestRepository _httpRequest;
        private TlsClientAuthRepository _tlsClientAuth;
        private TlsExportedAuthenticatorRepository _tlsExportedAuthenticator;

        public ICfHttpHeaderRepository CfHttpHeader => _cfHttpHeader ??= new CfHttpHeaderRepository();
        public IHttpHeaderRepository HttpHeader => _httpHeader ??= new HttpHeaderRepository();
        public IHttpRequestRepository HttpRequest => _httpRequest ??= new HttpRequestRepository();
        public ITlsClientAuthRepository TlsClientAuth => _tlsClientAuth ??= new TlsClientAuthRepository();
        public ITlsExportedAuthenticatorRepository TlsExportedAuthenticator => _tlsExportedAuthenticator ??= new TlsExportedAuthenticatorRepository();

    }
}