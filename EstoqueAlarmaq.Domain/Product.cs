namespace EstoqueAlarmaq.Domain
{
    public class Product
    {
        //Classe que representa o produto como um geral e não o objeto
        public int IdProduct { get; set; }
        public string NameProduct { get; set; }
        public string Description { get; set; }
        public int AmountProduct { get; set; }
        public string PhotoLocationProduct { get; set; }       
    }
}
