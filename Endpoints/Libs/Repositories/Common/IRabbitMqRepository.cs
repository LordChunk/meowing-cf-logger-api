using Libs.Models.Common;
using Libs.Repositories;

namespace EndPointLibs.Repositories.Common
{
    public interface IRabbitMqRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
       string QueueName { get; }
    }
}