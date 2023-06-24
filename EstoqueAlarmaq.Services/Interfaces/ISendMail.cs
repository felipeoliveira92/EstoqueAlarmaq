﻿using EstoqueAlarmaq.Services.DTOs.SendMail;

namespace EstoqueAlarmaq.Services.Interfaces
{
    public interface ISendMail
    {
        void BuildMessage(BuildMessageMailInputModel inputModel);
        void Send(SendInputModel inputModel);
        void Disconnect();
    }
}
