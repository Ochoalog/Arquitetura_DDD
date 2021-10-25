using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos
{
    public class UserDto
    {
        [Required(ErrorMessage = "Nome é um campo obrigatório.")]
        [StringLength(60, ErrorMessage = "Nome deve ter no máximo {1} caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email é um cmapo obrigatório.")]
        [EmailAddress]
        public string Email { get; set; }
    }
}