namespace EstoqueAlarmaq.Services.DTOs
{
    public class CreateProductsDTO
    {        
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantidade { get; set; }
        public string PhotoLocation { get; set; }
    }
}
