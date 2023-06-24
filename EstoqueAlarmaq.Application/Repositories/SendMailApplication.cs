using EstoqueAlarmaq.Application.Interfaces;
using EstoqueAlarmaq.Services.DTOs.SendMail;
using EstoqueAlarmaq.Services.Interfaces;

namespace EstoqueAlarmaq.Application.Repositories
{
    public class SendMailApplication : ISendMailApplication
    {
        private readonly ISendMail _sendMailRepository;

        public SendMailApplication(ISendMail sendMailRepository)
        {
            _sendMailRepository = sendMailRepository;
        }

        public void BuildMessage(BuildMessageMailInputModel inputModel)
        {
            _sendMailRepository.BuildMessage(inputModel);
        }
        
        public void Send()
        {
            _sendMailRepository.Send(new SendInputModel
            {
                Authentication = true,
                HostSmtp = "",
                PortSmtp = 587,
                UseSsl = false,
                MailAuthentication = "",
                PasswordAuthentication = ""
            });
        }

        public void Disconnect()
        {
            _sendMailRepository.Disconnect();
        }
    }
}
