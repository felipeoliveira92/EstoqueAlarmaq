using System;
using System.Collections.Generic;

namespace EstoqueAlarmaq.Domain
{
    public class OrderService
    {
        public int Id { get; set; }
        public string Client { get; set; }
        public string Tecnico { get; set; }
        public string User { get; set; }
        public string Observation { get; set; }
        public DateTime DateCreatedAt { get; set; } = DateTime.Now;

        public List<Product> Products { get; set; }

        public OrderService(string client, string tecnico, string user, string observation, List<Product> products)
        {
            this.Client = client;
            this.Tecnico = tecnico;
            this.User = user;
            this.Observation = observation;
            this.Products = products;
        }

        public OrderService()
        {

        }
    }
}