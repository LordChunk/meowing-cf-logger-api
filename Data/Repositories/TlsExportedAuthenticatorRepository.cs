using Data.Models;
using Data.Repositories.Common;

namespace Data.Repositories
{
    public class TlsExportedAuthenticatorRepository : RepositoryBase<TlsExportedAuthenticator>
    {
        public TlsExportedAuthenticatorRepository(ApplicationContext repositoryContext) : base(repositoryContext) {}
    }
}