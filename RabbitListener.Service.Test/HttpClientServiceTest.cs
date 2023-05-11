using RabbitListener.Core.Models;
using RabbitListener.Service.Factories;
using RabbitListener.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RabbitListener.Service.Test
{
    [TestClass]
    public class HttpClientServiceTest
    {
        [TestMethod]
        public async Task GetStatusCodeAsync_RightUrlTest()
        {
            IHttpClientService service = HttpClientServiceFactory.CreateHttpClientService();
            var url = "https://www.akakce.com/";

            var checkResult = new LogModel {

                ServiceName = "RabbitListener",
                Url = url,
                StatusCode = HttpStatusCode.OK.ToString(),
            };
            
            var result = await service.GetStatusCodeAsync(url);

            Assert.IsNotNull(result);          
            Assert.AreEqual(result, checkResult);    
        }


        [TestMethod]
        public async Task GetStatusCodeAsync_EmptyUrlTest()
        {
            IHttpClientService service = HttpClientServiceFactory.CreateHttpClientService();
            var url = "";

            var checkResult = new LogModel
            {

                ServiceName = "RabbitListener",
                Url = url,
                StatusCode = "Broken URL Address!",
            };

            var result = await service.GetStatusCodeAsync(url);

            Assert.IsNotNull(result);
            Assert.AreEqual(result, checkResult);
        }
    }
}
