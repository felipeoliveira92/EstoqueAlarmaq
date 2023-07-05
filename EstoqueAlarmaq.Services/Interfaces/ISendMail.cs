using EstoqueAlarmaq.Services.DTOs.SendMail;
using System.Threading.Tasks;

namespace EstoqueAlarmaq.Services.Interfaces
{
    public interface ISendMail
    {
        Task Connect(ConnectInputModel inputModel);
        void BuildMessage(BuildMessageMailInputModel inputModel);
        Task Send();
        Task Disconnect();
    }
}
