using Data.Models;
using Data.Repositories.Common;

namespace Data.Repositories
{
    public class TlsExportedAuthenticatorRepository : RepositoryBase<TlsExportedAuthenticator>
    {
        internal TlsExportedAuthenticatorRepository(ApplicationContext repositoryContext) : base(repositoryContext) {}
    }
}