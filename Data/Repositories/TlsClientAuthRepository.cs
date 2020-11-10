using Data.Models;
using Data.Repositories.Common;

namespace Data.Repositories
{
    internal class TlsClientAuthRepository : RepositoryBase<TlsClientAuth>, ITlsClientAuthRepository
    {
        public TlsClientAuthRepository(ApplicationContext repositoryContext) : base(repositoryContext) {}
    }
}