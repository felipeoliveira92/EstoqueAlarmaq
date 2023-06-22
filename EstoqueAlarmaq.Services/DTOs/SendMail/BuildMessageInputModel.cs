namespace EstoqueAlarmaq.Services.DTOs.SendMail
{
    public class BuildMessageInputModel
    {
        public string NameFrom { get; set; }
        public string MailFrom { get; set; }
        public string NameTo { get; set; }
        public string MailTo { get; set; }
        public string Subject { get; set; }
        public string BodyMessage { get; set; }
    }
}
