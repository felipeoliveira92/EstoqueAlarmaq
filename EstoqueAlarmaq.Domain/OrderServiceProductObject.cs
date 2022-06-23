using System.ComponentModel.DataAnnotations;

namespace EstoqueAlarmaq.Domain
{
    public class OrderServiceProductObject
    {
        [Key]
        public int IdOrderServiceProductObject { get; set; }
        public int IdOrderService { get; set; }
        public OrderService OrderService { get; set; }
        public int IdProductObject { get; set; }
        public ProductObject ProductObject { get; set; }
    }
}
