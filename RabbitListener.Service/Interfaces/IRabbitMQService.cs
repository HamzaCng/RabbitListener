using RabbitListener.Core.Models;
using RabbitMQ.Client.Events;

namespace RabbitListener.Service.Interfaces
{
    public interface IRabbitMQService
    {
        void CreateListener(string queueName, EventHandler<BasicDeliverEventArgs> received);
    }
}
