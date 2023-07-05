using EstoqueAlarmaq.Services.DTOs.SendMail;
using EstoqueAlarmaq.Services.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace EstoqueAlarmaq.Services.Repositories
{
    public class SendMail : ISendMail
    {
        public MimeMessage Message { get; set; }
        public SmtpClient SmtpClient { get; set; }
        public bool UnTrustedCertificate { get; set; }

        public SendMail()
        {
            this.Message = new MimeMessage();
            this.SmtpClient = new SmtpClient();
        }

        public async Task Connect(ConnectInputModel inputModel)
        {
            if (!this.SmtpClient.IsConnected)
            {
                this.UnTrustedCertificate = inputModel.UnTrustedCertificate;

                this.SmtpClient.ServerCertificateValidationCallback = SslCertificateValidation;

                if(inputModel.ProtocolOption > 0)
                    this.SmtpClient.SslProtocols = GetProtocolOption(inputModel.ProtocolOption);

                await this.SmtpClient.ConnectAsync(inputModel.HostSmtp, inputModel.PortSmtp, GetSecureOption(inputModel.SecureOption));
            }

            if (inputModel.HasAuthentication)
            {
                if (!this.SmtpClient.IsAuthenticated)
                    await this.SmtpClient.AuthenticateAsync(inputModel.EmailAuthentication, inputModel.PasswordAuthentication);
            }
        }

        public void BuildMessage(BuildMessageMailInputModel inputModel)
        {
            this.Message.From.Add(new MailboxAddress("OEstoque", "dagmar.walsh@ethereal.email"));
            this.Message.To.Add(new MailboxAddress(inputModel.NameTo, inputModel.MailTo));
            this.Message.Subject = inputModel.Subject;

            this.Message.Body = new TextPart(TextFormat.Html)
            {
                Text = $@"{inputModel.BodyMessage}"
            };
        }

        public async Task Send()
        {
            await this.SmtpClient.SendAsync(this.Message);
        }

        public async Task Disconnect()
        {
            await this.SmtpClient.DisconnectAsync(true);
        }

        private SecureSocketOptions GetSecureOption(int option)
        {
            if(option < 0 || option > 4)
                option = 1;

            return (SecureSocketOptions)option;
        }

        private SslProtocols GetProtocolOption(int option)
        {
            switch (option)
            {
                case 1:
                    return SslProtocols.Ssl2;
                case 2:
                    return SslProtocols.Ssl3;
                case 3:
                    return SslProtocols.Tls;
                case 4:
                    return SslProtocols.Tls11;
                case 5:
                    return SslProtocols.Tls12;
                case 6:
                    return SslProtocols.Tls13;
                default:
                    return SslProtocols.Default;
            }
        }

        private bool SslCertificateValidation(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            // Se verdadeiro, indica que o usuario confia no certificado mesmo sendo invalido pelas validações do mailkit
            if (this.UnTrustedCertificate)
                return true;

            // Se não houver erros, retorno verdadeiro, certificado valido.
            if (sslPolicyErrors == SslPolicyErrors.None)
                return true;

            var host = (string)sender;

            if ((sslPolicyErrors & SslPolicyErrors.RemoteCertificateNotAvailable) != 0)
            {
                // Significa que o certificado está indisponível. retorno falso.
                Console.WriteLine($"O certificado SSL não está disponível para {host}");
                return false;
            }

            if ((sslPolicyErrors & SslPolicyErrors.RemoteCertificateNameMismatch) != 0)
            {
                // This means that the server's SSL certificate did not match the host name that we are trying to connect to.
                var certificate2 = certificate as X509Certificate2;
                var cn = certificate2 != null ? certificate2.GetNameInfo(X509NameType.SimpleName, false) : certificate.Subject;

                Console.WriteLine("The Common Name for the SSL certificate did not match {0}. Instead, it was {1}.", host, cn);
                return false;
            }

            // The only other errors left are chain errors.
            Console.WriteLine("The SSL certificate for the server could not be validated for the following reasons:");

            // The first element's certificate will be the server's SSL certificate (and will match the `certificate` argument)
            // while the last element in the chain will typically either be the Root Certificate Authority's certificate -or- it
            // will be a non-authoritative self-signed certificate that the server admin created. 
            foreach (var element in chain.ChainElements)
            {
                // Each element in the chain will have its own status list. If the status list is empty, it means that the
                // certificate itself did not contain any errors.
                if (element.ChainElementStatus.Length == 0)
                    continue;

                Console.WriteLine("\u2022 {0}", element.Certificate.Subject);
                foreach (var error in element.ChainElementStatus)
                {
                    // `error.StatusInformation` contains a human-readable error string while `error.Status` is the corresponding enum value.
                    Console.WriteLine("\t\u2022 {0}", error.StatusInformation);
                }
            }

            return false;
        }
    }
}