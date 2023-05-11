using RabbitListener.Service.Factories;
using RabbitMQ.Fakes.DotNetStandard;
using RabbitMQ.Client;
using RabbitMQ.Fakes.DotNetStandard.Models;

namespace RabbitListener.Service.Test
{
    [TestClass]
	public class RabbitMQServiceTest
	{

        [TestMethod]
        public void RabbitMQServiceTest_Test()
        {
            var server = new RabbitServer();
            var factory = new FakeConnectionFactory(server);

            var queueName = "urls";
            var queue = new Queue
            {
                IsAutoDelete = false,
                IsDurable = false,
                Name = queueName,
                IsExclusive = true, 
            };

            server.Queues.TryAdd(queueName, queue);

            var connection = factory.CreateConnection();
            var service = MQServiceFactory.CreateRabbitMQService(connection);

            service.CreateListener("urls",(model,e) =>
            {


            });           

        }

    }  
}
