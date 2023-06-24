using EstoqueAlarmaq.Domain.Enums;

namespace EstoqueAlarmaq.Domain
{
    public class EmailTemplate
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public TemplateType Template { get; set; }
    }
}
