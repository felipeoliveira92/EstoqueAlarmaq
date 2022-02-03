using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstoqueAlarmaq.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantidade { get; set; }
        public string PhotoLocation { get; set; }
        
        public int? OrderServicesId { get; set; }
        public OrderService OrderServices { get; set; }

        public Product(string code, string name, string description, int quantidade, string photoLocation)
        {
            Code = code;
            Name = name;
            Description = description;
            Quantidade = quantidade;
            PhotoLocation = photoLocation;
        }
        public Product()
        {

        }        
    }
}
