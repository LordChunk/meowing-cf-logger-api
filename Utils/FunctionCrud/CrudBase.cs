using System.Threading.Tasks;
using Interface.Data;
using Interface.Models.Common;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;


namespace FunctionCrud
{
    public abstract class CrudBase<TEntity> where TEntity : EntityBase
    {
        private readonly IRepository<TEntity> _repository;

        protected CrudBase(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        protected IRepository<TEntity> GetRepository() => _repository;

        public abstract Task<HttpResponseData> Run(
            HttpRequestData req,
            FunctionContext executionContext);
    }
}