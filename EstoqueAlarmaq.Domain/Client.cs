namespace EstoqueAlarmaq.Domain
{
    public class Client
    {
        public Client(int code, string name)
        {
            this.Code = code;
            this.Name = name;
        }
        
        public int Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }        
    }
}