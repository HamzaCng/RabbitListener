using RabbitListener.Core.Models;
using RabbitListener.Service.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitListener.Service
{
    internal class RabbitMQService : IRabbitMQService
    {
        private ConnectionFactory _factory { get; }
        public RabbitMQService(RabbitMQConfigModel config)
        {
            _factory = new ConnectionFactory { HostName = config.HostName, UserName = config.UserName, Password = config.Password };
        }

        public void CreateListener(string queueName, EventHandler<BasicDeliverEventArgs> received)
        {
            IConnection connection = _factory.CreateConnection();
            IModel channel = connection.CreateModel();

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += received;

            channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);

        }
    }
}
