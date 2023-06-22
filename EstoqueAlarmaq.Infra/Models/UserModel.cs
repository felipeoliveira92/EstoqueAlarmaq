using Microsoft.AspNetCore.Identity;

namespace EstoqueAlarmaq.Infra.Models
{
    public class UserModel : IdentityUser
    {
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public string Address { get; set; }
        public string AddressNumber { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
    }
}
