using System;
using RabbitMQ.Client;

namespace Libs.RabbitMQ
{
    public class MqConnectionFactory
    {
        public ConnectionFactory Get(string uri = @"amqp://user:pass@hostName:port/vhost")
        {
            return new ConnectionFactory()
            {
                Uri = new Uri(uri)
            };
        }
    }
}