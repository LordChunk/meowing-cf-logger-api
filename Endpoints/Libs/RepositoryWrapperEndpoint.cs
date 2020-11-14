using EndPointLibs.Repositories;
using EndPointLibs.Repositories.Common;
using Libs.RabbitMQ;
using Libs.Repositories;


namespace EndPointLibs
{
    public sealed class RepositoryWrapperEndpoint : IRepositoryWrapper
    {

        private CfHttpHeaderRepository _cfHttpHeader;
        private HttpHeaderRepository _httpHeader;
        private HttpRequestRepository _httpRequest;
        private TlsClientAuthRepository _tlsClientAuth;
        private TlsExportedAuthenticatorRepository _tlsExportedAuthenticator;

        public ICfHttpHeaderRepository CfHttpHeader => _cfHttpHeader ??= new CfHttpHeaderRepository(_mqConnection, "cf-http-header");
        public IHttpHeaderRepository HttpHeader => _httpHeader ??= new HttpHeaderRepository(_mqConnection, "http-header");
        public IHttpRequestRepository HttpRequest => _httpRequest ??= new HttpRequestRepository(_mqConnection, "http-request");
        public ITlsClientAuthRepository TlsClientAuth => _tlsClientAuth ??= new TlsClientAuthRepository(_mqConnection, "tls-client-auth");
        public ITlsExportedAuthenticatorRepository TlsExportedAuthenticator => 
            _tlsExportedAuthenticator ??= new TlsExportedAuthenticatorRepository(_mqConnection, "tls-exported-authenticator");

        private readonly IMqConnectionFactory _mqConnection;

        public RepositoryWrapperEndpoint(IMqConnectionFactory mqConnection)
        {
            _mqConnection = mqConnection;
        }
    }
}