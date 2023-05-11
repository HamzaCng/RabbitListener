using RabbitListener.Core.Models;
using RabbitListener.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitListener.Service.Factories
{
    public static class RabbitMQServiceFactory
    {
        public static IRabbitMQService CreateRabbitMQService(RabbitMQConfigModel config)
        {
            return new RabbitMQService(config);
        }
       
    }
}
