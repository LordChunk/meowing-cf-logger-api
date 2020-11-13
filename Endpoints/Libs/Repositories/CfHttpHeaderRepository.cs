using EndPointLibs.Repositories.Common;
using Libs.Models;
using Libs.RabbitMQ;
using Libs.Repositories;

namespace EndPointLibs.Repositories
{
    internal class CfHttpHeaderRepository : RepositoryBase<CfHttpHeader>, ICfHttpHeaderRepository
    {
        public CfHttpHeaderRepository(IMqConnectionFactory mqConnection, string queueName) : base(mqConnection, queueName)
        {
        }
    }
}