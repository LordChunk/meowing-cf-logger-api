using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        public ICfHttpHeaderRepository CfHttpHeader { get; }
        public IHttpHeaderRepository HttpHeader { get; }
        public IHttpRequestRepository HttpRequest { get; }
        public ITlsClientAuthRepository TlsClientAuth { get; }
        public ITlsExportedAuthenticatorRepository TlsExportedAuthenticator { get; }

        Task Save();
    }
}