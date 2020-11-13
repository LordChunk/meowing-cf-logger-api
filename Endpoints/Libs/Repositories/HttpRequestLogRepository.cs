using EndPointLibs.Repositories.Common;
using Libs.Models;
using Libs.RabbitMQ;
using Libs.Repositories;

namespace EndPointLibs.Repositories
{
    internal class HttpRequestLogRepository : RepositoryBase<HttpRequestLog>, IHttpRequestLogRepository
    {
        public HttpRequestLogRepository(IMqConnectionFactory mqConnection, string queueName) : base(mqConnection, queueName) {}
    }
}