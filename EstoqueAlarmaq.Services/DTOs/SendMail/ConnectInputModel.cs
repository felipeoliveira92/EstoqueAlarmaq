namespace EstoqueAlarmaq.Services.DTOs.SendMail
{
    public class ConnectInputModel
    {
        public bool UnTrustedCertificate { get; set; }
        public bool HasAuthentication { get; set; }
        public string HostSmtp { get; set; }
        public int PortSmtp { get; set; }
        public int SecureOption { get; set; }
        public int ProtocolOption { get; set; }
        public string EmailAuthentication { get; set; }
        public string PasswordAuthentication { get; set; }
    }
}
