﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitListener.Core.Models
{
    public record RabbitMQConfigModel
    {      
        public string HostName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        
    }
}
