using Data.Models;
using Data.Repositories.Common;
using Data.Repositories.Interfaces;

namespace Data.Repositories
{
    public class TlsExportedAuthenticatorRepository : RepositoryBase<TlsExportedAuthenticator>, ITlsExportedAuthenticatorRepository
    {
        public TlsExportedAuthenticatorRepository(RepositoryContext repositoryContext) : base(repositoryContext) {}
    }
}