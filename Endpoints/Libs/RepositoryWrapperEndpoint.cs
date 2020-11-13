using Libs.Repositories;


namespace EndPointLibs
{
    public class RepositoryWrapperEndpoint : IRepositoryWrapper
    {
        public ICfHttpHeaderRepository CfHttpHeader { get; }
        public IHttpHeaderRepository HttpHeader { get; }
        public IHttpRequestRepository HttpRequest { get; }
        public ITlsClientAuthRepository TlsClientAuth { get; }
        public ITlsExportedAuthenticatorRepository TlsExportedAuthenticator { get; }
    }
}