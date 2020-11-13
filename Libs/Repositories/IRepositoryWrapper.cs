namespace Libs.Repositories
{
    public interface IRepositoryWrapper
    {
        ICfHttpHeaderRepository CfHttpHeader { get; }
        IHttpHeaderRepository HttpHeader { get; }
        IHttpRequestRepository HttpRequest { get; }
        ITlsClientAuthRepository TlsClientAuth { get; }
        ITlsExportedAuthenticatorRepository TlsExportedAuthenticator { get; }
    }
}