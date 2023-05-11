using RabbitListener.Core.Models;
using RabbitListener.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitListener.Service
{
    internal class HttpClientService : IHttpClientService
    {
        public async Task<LogModel> GetStatusCodeAsync(string url)
        {
            using (var client = new HttpClient())
            {
                var result = new LogModel();

                try
                {
                    var request = await client.GetAsync(url);
                    result.StatusCode = request.StatusCode.ToString();

                }
                catch (Exception)
                {
                    return new LogModel()
                    {
                        ServiceName = "RabbitListener",
                        Url = url,
                        StatusCode = "Bad URL Address!",
                    };
                }

                var model = new LogModel()
                {
                    ServiceName = "RabbitListener",
                    Url = url,
                    StatusCode = result.StatusCode,
                };

                return model;
            }
        }
    }
}
