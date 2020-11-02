using Data.Models;
using Data.Repositories.Common;
using Data.Repositories.Interfaces;

namespace Data.Repositories
{
    public class TlsClientAuthRepository : RepositoryBase<TlsClientAuth>
    {
        public TlsClientAuthRepository(ApplicationContext repositoryContext) : base(repositoryContext) {}
    }
}