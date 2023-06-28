﻿using EstoqueAlarmaq.Application.Interfaces;
using EstoqueAlarmaq.Domain;
using EstoqueAlarmaq.Infra.Identity;
using EstoqueAlarmaq.Infra.Models;
using EstoqueAlarmaq.Services.DTOs.SendMail;
using EstoqueAlarmaq.Services.Extensions;
using Microsoft.AspNetCore.Identity;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueAlarmaq.Application.Repositories
{
    public class UserApplication : IUserApplication
    {
        private readonly IIdentityRepository _identityRepository;
        private readonly ISendMailApplication _sendMailApplication;

        public UserApplication(IIdentityRepository identityRepository, ISendMailApplication sendMailApplication)
        {
            _identityRepository = identityRepository;
            _sendMailApplication = sendMailApplication;
        }

        public async Task<SignInResult> Login(string email, string password, bool rememberMe, bool lockoutOnFailure)
            => await _identityRepository.Login(email, password, rememberMe, lockoutOnFailure);

        public async Task Logout()
            => await _identityRepository.Logout();

        public void GenerateConfirmationEmail(UserModel user, string urlConfirmation)
        {
            var emailMessage = new StringBuilder();
            emailMessage.Append($"<p>Olá, {user.Name.FirstWord()}.</p>");
            emailMessage.Append("<p>Recebemos seu cadastro em nosso sistema. Para concluir o processo de cadastro, clique no link a seguir:</p>");
            emailMessage.Append($"<p><a href='{urlConfirmation}'>Confirmar Cadastro</a></p>");
            emailMessage.Append("<p>Atenciosamente,<br>Equipe de Suporte</p>");

            _sendMailApplication.BuildMessage(new BuildMessageMailInputModel
            {
                NameTo = user.Name,
                MailTo = user.Email,
                Subject = "Confirmação de email",
                BodyMessage = emailMessage.ToString()
            });

            _sendMailApplication.Send();
            _sendMailApplication.Disconnect();
        }

        public async Task<bool> IsEmailConfirmedAsync(UserModel user)
            => await _identityRepository.IsEmailConfirmedAsync(user);

        public async Task<UserModel> FindUserByEmailAsync(string email)
            => await _identityRepository.FindUserByEmailAsync(email);

        public async Task<string> GenerateTokenByUserAsync(UserModel user)
            => await _identityRepository.GenerateTokenByUserAsync(user);

        public async Task<string> GeneratePasswordResetTokenAsync(UserModel user)
            => await _identityRepository.GeneratePasswordResetTokenAsync(user);

        public void GenerateForgotPasswordEmail(UserModel user, string urlConfirmation)
        {
            var emailMessage = new StringBuilder();
            emailMessage.Append($"<p>Olá, {user.Name.FirstWord()}.</p>");
            emailMessage.Append("<p>Houve uma solicitação de redefinição de senha para seu usuário em nosso site. Se não foi você que fez a solicitação, ignore essa mensagem. Caso tenha sido você, clique no link abaixo para criar sua nova senha:</p>");
            emailMessage.Append($"<p><a href='{urlConfirmation}'>Redefinir Senha</a></p>");
            emailMessage.Append("<p>Atenciosamente,<br>Equipe de Suporte</p>");

            _sendMailApplication.BuildMessage(new BuildMessageMailInputModel
            {
                NameTo = user.Name,
                MailTo = user.Email,
                Subject = "Redefinição de senha",
                BodyMessage = emailMessage.ToString()
            });

            _sendMailApplication.Send();
            _sendMailApplication.Disconnect();
        }
    }
}
