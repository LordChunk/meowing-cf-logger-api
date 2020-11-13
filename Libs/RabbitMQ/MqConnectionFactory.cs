using System;
using RabbitMQ.Client;

namespace Libs.RabbitMQ
{
    public class MqConnectionFactory : IMqConnectionFactory
    {
        public ConnectionFactory Get(string uri = @"amqp://guest:guest@localhost:5672/")
        {
            return new ConnectionFactory()
            {
                Uri = new Uri(uri)
            };
        }
    }
}