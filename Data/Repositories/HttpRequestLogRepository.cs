using Data.Models;
using Data.Repositories.Common;

namespace Data.Repositories
{
    public class HttpRequestLogRepository : RepositoryBase<HttpRequestLog>
    {
        public HttpRequestLogRepository(ApplicationContext context) : base(context)
        {
        }
    }
}