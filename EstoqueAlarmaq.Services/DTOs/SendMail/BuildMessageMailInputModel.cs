using System.Collections.Generic;

namespace EstoqueAlarmaq.Services.DTOs.SendMail
{
    public class BuildMessageMailInputModel
    {
        public FromMessageMailInputModel From { get; set; }
        public List<ToMessageMailInputModel> To { get; set; }
        public string Subject { get; set; }
        public string BodyMessage { get; set; }
    }

    public class ToMessageMailInputModel
    {
        public string NameTo { get; set; }
        public string EmailTo { get; set; }
    }

    public class FromMessageMailInputModel
    {
        public string NameFrom { get; set; }
        public string EmailFrom { get; set; }
    }
}
