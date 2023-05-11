using RabbitListener.Core.Models;
using RabbitListener.Service.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitListener.Service
{
    internal class RabbitMQService : IMQService
    {
        IConnection _connection;

        public RabbitMQService(RabbitMQConfigModel config)
        {
            var factory = new ConnectionFactory { HostName = config.HostName, UserName = config.UserName, Password = config.Password };
            _connection = factory.CreateConnection();
        }

        public RabbitMQService(IConnection connection)
        {
            _connection = connection;   
        }

        public void CreateListener(string queueName, EventHandler<BasicDeliverEventArgs> received)
        {

            IModel channel = _connection.CreateModel();

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += received;

            channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);

        }
    }
}
