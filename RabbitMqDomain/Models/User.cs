using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMqDomain.Models
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        //public int age { get; set; } 
        public string email { get; set; }
        public string phone_number { get; set; }

    }
}
