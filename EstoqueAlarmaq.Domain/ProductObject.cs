namespace EstoqueAlarmaq.Domain
{
    public class ProductObject
    { 
        //classe que representa o objeto produto em si
        public int Id { get; set; }
        public string Code { get; set; }
        public int IdProduct { get; set; }
        public Product Product { get; set; }        
    }
}
