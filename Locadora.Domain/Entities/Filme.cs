using System.ComponentModel.DataAnnotations;

namespace Locadora.Domain.Entities
{
    public class Filme : Base
    {
        [Required]
        [MaxLength(255)]
        public string Titulo { get; set; }

        [MaxLength(255)]
        public string Descricao { get; set; }

        [MaxLength(50)]
        public string ContentType { get; set; }    
        public byte[] Capa { get; set; }
    }
}
