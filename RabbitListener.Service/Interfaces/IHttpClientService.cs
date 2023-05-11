using RabbitListener.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitListener.Service.Interfaces
{
    public interface IHttpClientService
    {
        /// <summary>
        ///  Get Status Code for Url.
        /// </summary>
        /// <param name="url">Links</param>    
        /// <returns></returns>
        Task<LogModel> GetStatusCodeAsync(string url);
    }
}
