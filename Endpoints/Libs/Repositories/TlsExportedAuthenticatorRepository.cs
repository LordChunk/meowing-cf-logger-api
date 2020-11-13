using Data;
using EndPointLibs.Repositories.Common;
using Libs.Models;

namespace EndPointLibs.Repositories
{
    internal class TlsExportedAuthenticatorRepository : RepositoryBase<TlsExportedAuthenticator>, ITlsExportedAuthenticatorRepository
    {
        public TlsExportedAuthenticatorRepository(ApplicationContext repositoryContext) : base(repositoryContext) {}
    }
}