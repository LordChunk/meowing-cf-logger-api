using EndPointLibs.Repositories.Common;
using Libs.Models;
using Libs.RabbitMQ;
using Libs.Repositories;

namespace EndPointLibs.Repositories
{
    internal class HttpHeaderRepository : RepositoryBase<HttpHeader>, IHttpHeaderRepository
    {
        public HttpHeaderRepository(IMqConnectionFactory mqConnection, string queueName) : base(mqConnection, queueName)
        {
        }
    }
}