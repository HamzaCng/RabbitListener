using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitListener.Core.Models
{
    public record LogModel
    {
        public string ServiceName { get; set; }
        public string Url { get; set; }
        public string StatusCode { get; set; }

    }
}
