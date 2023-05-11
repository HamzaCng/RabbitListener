using RabbitListener.Core.Models;
using RabbitListener.Service.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitListener.Service
{
    internal class RabbitMQService : IMQService
    {
        IModel _channel;

        public RabbitMQService(RabbitMQConfigModel config)
        {
            var factory = new ConnectionFactory { HostName = config.HostName, UserName = config.UserName, Password = config.Password };
            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();
        }

        public RabbitMQService(IModel channel)
        {
            _channel = channel;   
        }

        public void CreateListener(string queueName, EventHandler<BasicDeliverEventArgs> received)
        {          

            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += received;

            _channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
        }
    }
}
