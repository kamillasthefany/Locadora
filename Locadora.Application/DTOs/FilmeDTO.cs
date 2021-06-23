using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Locadora.Application.DTOs
{
    public class FilmeDTO
    {
        public int Id { get; set; }
        
        [MaxLength(255)]
        [Display(Name = "Título")]
        [Required(ErrorMessage = "Informe o título")]
        public string Titulo { get; set; }

        [MaxLength(255)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [MaxLength(50)]
        public string ContentType { get; set; }

        [Display(Name = "Capa do Filme")] 
        public IFormFile Capa { get; set; }

        public byte[] CapaByte { get; set; }
    }
}
