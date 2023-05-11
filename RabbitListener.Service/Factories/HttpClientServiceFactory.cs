using RabbitListener.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitListener.Service.Factories
{
    public static class HttpClientServiceFactory
    {
        public static IHttpClientService CreateHttpClientService()
        {
            return new HttpClientService();
        }
    }
}
