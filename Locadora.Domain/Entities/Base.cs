using System;

namespace Locadora.Domain.Entities
{
    public class Base
    {
        public int Id { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public DateTime UltimaAlteracao { get; set; } = DateTime.Now;
        public bool Deletado { get; set; } = false;
    }
}
