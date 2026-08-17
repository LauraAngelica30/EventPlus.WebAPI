using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO
{
    public class InstituicaoDTO
    {
        [Required(ErrorMessage = "O nome da instituição é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome da instituição pode ter no máximo 100 caracteres.")]
        public string NomeFantasia { get; set; } = string.Empty;
    }
}
