using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EstoqueAlarmaq.Infra.Models
{
    public class UserModel : IdentityUser
    {
        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public string Address { get; set; }
        public string AddressNumber { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
    }
}
