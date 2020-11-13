﻿using Libs.Models;

namespace Libs.Repositories
{
    public interface ICfHttpHeaderRepository : IRepository<CfHttpHeader> { }
    public interface IHttpHeaderRepository : IRepository<HttpHeader> { }
    public interface IHttpRequestLogRepository : IRepository<HttpRequestLog> {}
    public interface IHttpRequestRepository : IRepository<HttpRequest> { }

    public interface ITlsClientAuthRepository : IRepository<TlsClientAuth> { }
    public interface ITlsExportedAuthenticatorRepository : IRepository<TlsExportedAuthenticator> { }
}