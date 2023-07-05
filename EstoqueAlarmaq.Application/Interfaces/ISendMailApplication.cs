using EstoqueAlarmaq.Services.DTOs.SendMail;

namespace EstoqueAlarmaq.Application.Interfaces
{
    public interface ISendMailApplication
    {
        void BuildMessage(BuildMessageMailInputModel inputModel);
        void Send();
    }
}
