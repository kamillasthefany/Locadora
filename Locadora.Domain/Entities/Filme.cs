using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Locadora.Domain.Entities
{
    public class Filme : Base
    {
        [Required]
        [MaxLength(255)]
        public string Titulo { get; set; }

        [Required]
        [MaxLength(255)]
        public string Descricao { get; set; }
    }
}
