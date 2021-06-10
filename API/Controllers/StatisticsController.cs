using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class StatisticsController : ControllerBase
    {
        private readonly RepositoryWrapper _repositoryWrapper;

        public StatisticsController(RepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable>> RequestsPerCountry()
        {
            var headers = await _repositoryWrapper.Statistics.RequestsPerCountry();


            return Ok(headers);
        }
    }
}
