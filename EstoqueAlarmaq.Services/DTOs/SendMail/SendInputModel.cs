namespace EstoqueAlarmaq.Services.DTOs.SendMail
{
    public class SendInputModel
    {
        public bool Authentication { get; set; }
        public string HostSmtp { get; set; }
        public int PortSmtp { get; set; }
        public bool UseSsl { get; set; }
        public string MailAuthentication { get; set; }
        public string PasswordAuthentication { get; set; }
    }
}
