using Data;
using EndPointLibs.Repositories.Common;
using Libs.Models;
using Libs.Repositories;

namespace EndPointLibs.Repositories
{
    internal class TlsClientAuthRepository : RepositoryBase<TlsClientAuth>, ITlsClientAuthRepository
    {
        public TlsClientAuthRepository(ApplicationContext repositoryContext) : base(repositoryContext) {}
    }
}