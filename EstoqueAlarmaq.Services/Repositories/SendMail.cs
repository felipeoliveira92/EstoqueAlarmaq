using EstoqueAlarmaq.Services.DTOs.SendMail;
using EstoqueAlarmaq.Services.Interfaces;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;

namespace EstoqueAlarmaq.Services.Repositories
{
    public class SendMail : ISendMail
    {
        public MimeMessage Message { get; set; }
        public SmtpClient SmtpClient { get; set; }

        public SendMail()
        {
            this.Message = new MimeMessage();
            this.SmtpClient = new SmtpClient();
        }

        public void BuildMessage(BuildMessageMailInputModel inputModel)
        {
            this.Message.From.Add(new MailboxAddress("OEstoque", "teste@mmdata.com.br"));
            this.Message.To.Add(new MailboxAddress(inputModel.NameTo, inputModel.MailTo));
            this.Message.Subject = inputModel.Subject;

            this.Message.Body = new TextPart(TextFormat.Html)
            {
                Text = $@"{inputModel.BodyMessage}"
            };
        }

        public void Send(SendInputModel inputModel)
        {
            if (!this.SmtpClient.IsConnected)
                this.SmtpClient.Connect(inputModel.HostSmtp, inputModel.PortSmtp, inputModel.UseSsl);

            if (inputModel.Authentication)
            {
                if (!this.SmtpClient.IsAuthenticated)
                    this.SmtpClient.Authenticate(inputModel.MailAuthentication, inputModel.PasswordAuthentication);
            }

            this.SmtpClient.Send(this.Message);
        }

        public void Disconnect()
        {
            this.SmtpClient.Disconnect(true);
        }
    }
}