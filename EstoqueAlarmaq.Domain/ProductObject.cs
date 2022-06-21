namespace EstoqueAlarmaq.Domain
{
    public class ProductObject
    { 
        //classe que representa o objeto produto em si
        public int IdProductObject { get; set; }
        public string CodeProductObject { get; set; }
        public int IdProduct { get; set; }
        public Product Product { get; set; }        
    }
}
