using RabbitListener.Service.Factories;
using RabbitMQ.Fakes.DotNetStandard;
using RabbitMQ.Client;
using RabbitMQ.Fakes.DotNetStandard.Models;
using System.Text;

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
            var url = "https://www.akakce.com/";     

            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            var service = MQServiceFactory.CreateRabbitMQService(channel);  

            service.CreateListener("urls",(model,e) =>
            {
                var body = e.Body.ToArray();
                var payload = Encoding.UTF8.GetString(body);

                Assert.AreEqual(url, payload);

            });    

            var messageBody = Encoding.UTF8.GetBytes(url);
            channel.BasicPublish(exchange: server.DefaultExchange.Name, routingKey: queueName, mandatory: false, basicProperties: null, body: messageBody);
          
        }

    }  
}
