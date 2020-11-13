using Data;
using ICfHttpHeaderRepository = EndPointLibs.Repositories.ICfHttpHeaderRepository;
using IHttpHeaderRepository = EndPointLibs.Repositories.IHttpHeaderRepository;
using IHttpRequestRepository = EndPointLibs.Repositories.IHttpRequestRepository;
using ITlsClientAuthRepository = EndPointLibs.Repositories.ITlsClientAuthRepository;
using ITlsExportedAuthenticatorRepository = EndPointLibs.Repositories.ITlsExportedAuthenticatorRepository;

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