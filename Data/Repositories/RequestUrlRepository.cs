using Data.Repositories.Common;
using Interface.Data;
using Interface.Models;

namespace Data.Repositories
{
    public class RequestUrlRepository : RepositoryBase<RequestUrl>, IRequestUrlRepository
    {
        public RequestUrlRepository(ApplicationContext context) : base(context)
        {
        }
    }
}