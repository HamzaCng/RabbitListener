using RabbitListener.Core.Models;
using RabbitListener.Service.Interfaces;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitListener.Service.Factories
{
    public static class MQServiceFactory
    {
        public static IMQService CreateRabbitMQService(RabbitMQConfigModel config)
        {
            return new RabbitMQService(config);
        }

        /// <summary>
        /// For Test
        /// </summary>
        /// <param name="channel"></param>
        /// <returns></returns>
        public static IMQService CreateRabbitMQService(IModel channel)
        {
            return new RabbitMQService(channel);
        }

        //public static IMQService CreateKafkaMQService(KafkaMQConfigModel config)
        //{
        //    return new KafkaMQService(config);
        //}
    }
}
