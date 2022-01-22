using System;
using System.Collections.Generic;

namespace EstoqueAlarmaq.Domain
{
    public class OrderService
    {
        public int Id { get; set; }
        public string Client { get; set; }
        public string Products { get; set; }
        public string User { get; set; }
        public string Observation { get; set; }
        public DateTime DateCreatedAt { get; set; } = DateTime.Now;

        public OrderService(string client, string products, string user, string observation)
        {
            this.Client = client;
            this.Products = products;
            this.User = user;
            this.Observation = observation;
        }

        public OrderService()
        {

        }
    }
}