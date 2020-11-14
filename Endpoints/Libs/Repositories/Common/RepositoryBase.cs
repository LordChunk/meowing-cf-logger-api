using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Data;
using Libs.Models.Common;
using Libs.RabbitMQ;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace EndPointLibs.Repositories.Common
{
    internal abstract class RepositoryBase<TEntity> : RepositoryBase<TEntity, ApplicationContext>
           where TEntity : class, IEntity
    {
        internal RepositoryBase(IMqConnectionFactory mqConnection, string queueName) : base(mqConnection, queueName) {}
    }

    internal abstract class RepositoryBase<TEntity, TContext> : IRabbitMqRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        public string QueueName { get; }
        private readonly ConnectionFactory _mqFactory;

        internal RepositoryBase(IMqConnectionFactory mqConnection, string queueName)
        {
            QueueName = queueName;
            _mqFactory = mqConnection.Get();
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            using (var conn = _mqFactory.CreateConnection())
            using (var channel = conn.CreateModel())
            {
                channel.QueueDeclare(queue: QueueName, true, false, false, null);

                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(entity));

                channel.BasicPublish("", QueueName, null, body);

                var bodyBytes = channel.BasicGet(QueueName, false)?.Body.ToArray();

                if (bodyBytes == null) return null;

                var retrievedBody = JsonConvert.DeserializeObject<TEntity>(Encoding.UTF8.GetString(bodyBytes));

                return retrievedBody;
            }
        }

        public async Task<TEntity> Get(params Expression<Func<TEntity, bool>>[] predicates)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TEntity>> GetAll(params Expression<Func<TEntity, bool>>[] predicates)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
        public virtual async Task<List<TEntity>> Remove(params Expression<Func<TEntity, bool>>[] predicates)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}