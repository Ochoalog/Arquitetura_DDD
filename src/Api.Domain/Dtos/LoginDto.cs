using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email é um campo obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail- em formato inválido")]
        [StringLength(100, ErrorMessage = "Email deve te rno máximo 100 caracteres.")]
        public string Email { get; set; }
    }
}