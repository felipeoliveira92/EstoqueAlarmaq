using System;
using System.Collections.Generic;

namespace EstoqueAlarmaq.Domain
{
    public class OrderService
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public User Tecnico { get; set; }
        public User User { get; set; }
        public string Observation { get; set; }
        public DateTime DateCreatedAt { get; set; } = DateTime.Now;

        public ICollection<Product> Products { get; set; }

        public OrderService(Client client, User tecnico, User user, string observation, List<Product> products)
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