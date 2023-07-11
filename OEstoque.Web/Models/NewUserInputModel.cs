using EstoqueAlarmaq.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace OEstoque.Web.Models
{
    public class NewUserInputModel
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo Email não é um endereço de email válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "É necessario selecionar o tipo de usuário.")]
        public TypeUser TypeUser { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "O campo Confirmar Senha é obrigatório.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "A senha e a confirmação de senha não correspondem.")]
        public string ConfirmPassword { get; set; }
    }
}
