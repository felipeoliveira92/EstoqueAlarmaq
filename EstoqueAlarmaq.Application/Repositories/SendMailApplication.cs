using EstoqueAlarmaq.Application.Interfaces;
using EstoqueAlarmaq.Services.DTOs.SendMail;
using EstoqueAlarmaq.Services.Interfaces;
using System;

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
            try
            {
                Connect();
                _sendMailRepository.Send().Wait();
                Disconnect();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Connect()
        {
            try
            {
                _sendMailRepository.Connect(new ConnectInputModel
                {
                    UnTrustedCertificate = false,
                    HasAuthentication = true,
                    HostSmtp = "smtp.ethereal.email",
                    PortSmtp = 587,
                    EmailAuthentication = "dagmar.walsh@ethereal.email",
                    PasswordAuthentication = "BeURe3synxA2npWzMZ",
                    SecureOption = 1,
                    ProtocolOption = 0
                }).Wait();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Disconnect()
        {
            _sendMailRepository.Disconnect().Wait();
        }
    }
}
