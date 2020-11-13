using EndPointLibs.Repositories.Common;
using Libs.Models;
using Libs.RabbitMQ;
using Libs.Repositories;

namespace EndPointLibs.Repositories
{
    internal class TlsClientAuthRepository : RepositoryBase<TlsClientAuth>, ITlsClientAuthRepository
    {
        public TlsClientAuthRepository(IMqConnectionFactory mqConnection, string queueName) : base(mqConnection, queueName)
        {
        }
    }
}