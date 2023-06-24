namespace EstoqueAlarmaq.Services.DTOs.SendMail
{
    public class BuildMessageMailInputModel
    {
        public string NameTo { get; set; }
        public string MailTo { get; set; }
        public string Subject { get; set; }
        public string BodyMessage { get; set; }
    }
}
