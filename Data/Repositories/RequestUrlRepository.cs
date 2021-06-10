using Data.Models;
using Data.Repositories.Common;

namespace Data.Repositories
{
    public class RequestUrlRepository : RepositoryBase<RequestUrl>, IRequestUrlRepository
    {
        public RequestUrlRepository(ApplicationContext context) : base(context)
        {
        }
    }
}