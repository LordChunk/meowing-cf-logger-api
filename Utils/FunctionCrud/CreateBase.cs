using System.IO;
using System.Net;
using System.Threading.Tasks;
using Interface.Data;
using Interface.Models.Common;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Newtonsoft.Json;

namespace FunctionCrud
{
    public class CreateBase<TEntity> : CrudBase<TEntity> where TEntity : EntityBase
    {
        public CreateBase(IRepository<TEntity> repository) : base(repository)
        {
        }

        public override async Task<HttpResponseData> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "/"+ nameof(TEntity))]
            HttpRequestData req, 
            FunctionContext executionContext)
        {
            var model = await EntityBase.CreateFromStream<TEntity>(req.Body);
            var storedModel = await GetRepository().Add(model);

            var res = req.CreateResponse(HttpStatusCode.Created);
            await res.WriteAsJsonAsync(storedModel);

            return res;
        }

    }
}