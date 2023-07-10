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
            // Aqui busco informações no sistema de quem é o From para os emails.
            inputModel.From = new FromMessageMailInputModel
            {
                NameFrom = "OEstoque",
                EmailFrom = "oestoque@teste.com.br"
            };

            try
            {
                _sendMailRepository.BuildMessage(inputModel);
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível construir a mensagem de email. Erro: {ex.Message}");
            }            
        }
        
        public void Send()
        {
            try
            {
                Connect();
                _sendMailRepository.Send().Wait();
                Disconnect();
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível enviar email. Erro: {ex.Message}");
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
                    HostSmtp = "sandbox.smtp.mailtrap.io",
                    PortSmtp = 587,
                    EmailAuthentication = "0bc42921f87d6b",
                    PasswordAuthentication = "f65856a8189114",
                    SecureOption = 1,
                    ProtocolOption = 0
                }).Wait();
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível conectar o servidor smtp. Erro: {ex.Message}");
            }
        }

        private void Disconnect()
        {
            _sendMailRepository.Disconnect().Wait();
        }
    }
}
