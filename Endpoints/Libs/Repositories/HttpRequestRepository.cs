using System.Linq;
using Data;
using EndPointLibs.Repositories.Common;
using Libs.Models;
using Libs.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EndPointLibs.Repositories
{
    internal class HttpRequestRepository : RepositoryBase<HttpRequest>, IHttpRequestRepository
    {
    }
}