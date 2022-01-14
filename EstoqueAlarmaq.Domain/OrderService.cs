namespace EstoqueAlarmaq.Domain
{
    public class OrderService
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public Client Client { get; set; }
        public Product Product { get; set; }
        public User User { get; set; }
        public string Observation { get; set; }
        public DateTime DateCreatedAt { get; set; } 

        public OrderService(int code, Client client, Product product, User user, string observation)
        {
            this.Code = code;
            this.Client = client;
            this.Product = product;
            this.User = user;
            this.Observation = observation;
            this.DateCreatedAt = DateTime.now;
        }
    }
}