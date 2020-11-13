using RabbitMQ.Client;

namespace Libs.RabbitMQ
{
    public interface IMqConnectionFactory
    {
        ConnectionFactory Get(string uri = @"amqp://guest:guest@localhost:5672/");
    }
}