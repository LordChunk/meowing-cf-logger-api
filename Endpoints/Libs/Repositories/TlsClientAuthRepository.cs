using Data;
using EndPointLibs.Repositories.Common;
using Libs.Models;

namespace EndPointLibs.Repositories
{
    internal class TlsClientAuthRepository : RepositoryBase<TlsClientAuth>, ITlsClientAuthRepository
    {
        public TlsClientAuthRepository(ApplicationContext repositoryContext) : base(repositoryContext) {}
    }
}