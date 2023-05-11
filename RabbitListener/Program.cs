using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitListener.Core.Models;
using RabbitListener.Service.Factories;
using RabbitListener.Service.Interfaces;
using RabbitMQ.Client.Events;
using System.Text;

#region Config

IConfiguration config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .Build();

var rabbitMqConf = config.GetRequiredSection("RabbitMQ").Get<RabbitMQConfigModel>();

#endregion

#region Fields

IMQService rabbitMQService = MQServiceFactory.CreateRabbitMQService(rabbitMqConf);

#endregion

#region Listener

rabbitMQService.CreateListener("urls", CallBack);

#endregion

#region Method
static void CallBack(object? model, BasicDeliverEventArgs e)
{
    IHttpClientService httpClientService = HttpClientServiceFactory.CreateHttpClientService();

    var body = e.Body.ToArray();
    var payload = Encoding.UTF8.GetString(body);

    var urls = payload.Split('\r').Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => x.Trim());

    Parallel.ForEach(urls, async (url) =>
    {
        //Get Status Code           
        var result = await httpClientService.GetStatusCodeAsync(url);

        var resultJson = JsonConvert.SerializeObject(result);

        Console.WriteLine(resultJson);
    });
}

Console.ReadLine();
#endregion






