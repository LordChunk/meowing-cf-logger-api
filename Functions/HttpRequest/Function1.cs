using System.Net;
using System.Threading.Tasks;
using Data;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Newtonsoft.Json;

namespace HttpRequest
{
    public class Function1
    {
        private readonly RepositoryWrapper _repositoryWrapper;

        public Function1(RepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        [Function("Function1")]
        public async Task<HttpResponseData> GetRecent(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req,
            FunctionContext executionContext
        ) {
            var requests = await _repositoryWrapper.HttpRequest.GetRecentRequests(2);

            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteStringAsync(JsonConvert.SerializeObject(requests));

            return response;
        }
    }
}
