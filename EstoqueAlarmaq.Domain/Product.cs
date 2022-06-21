namespace EstoqueAlarmaq.Domain
{
    public class Product
    {
        //Classe que representa o produto como um geral e não o objeto
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public string PhotoLocation { get; set; }       
    }
}
