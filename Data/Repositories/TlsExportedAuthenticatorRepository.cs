using Data.Models;
using Data.Repositories.Common;

namespace Data.Repositories
{
    internal class TlsExportedAuthenticatorRepository : RepositoryBase<TlsExportedAuthenticator>, ITlsExportedAuthenticatorRepository
    {
        public TlsExportedAuthenticatorRepository(ApplicationContext repositoryContext) : base(repositoryContext) {}
    }
}