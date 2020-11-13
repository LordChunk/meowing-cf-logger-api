using EndPointLibs.Repositories.Common;
using Libs.Models;
using Libs.RabbitMQ;
using Libs.Repositories;

namespace EndPointLibs.Repositories
{
    internal class HttpRequestRepository : RepositoryBase<HttpRequest>, IHttpRequestRepository
    {
        public HttpRequestRepository(IMqConnectionFactory mqConnection, string queueName) : base(mqConnection, queueName) {}
    }
}