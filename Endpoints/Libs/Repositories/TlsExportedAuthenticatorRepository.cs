using EndPointLibs.Repositories.Common;
using Libs.Models;
using Libs.RabbitMQ;
using Libs.Repositories;

namespace EndPointLibs.Repositories
{
    internal class TlsExportedAuthenticatorRepository : RepositoryBase<TlsExportedAuthenticator>, ITlsExportedAuthenticatorRepository
    {
        public TlsExportedAuthenticatorRepository(IMqConnectionFactory mqConnection, string queueName) : base(mqConnection, queueName)
        {
        }
    }
}