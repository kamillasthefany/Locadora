using Locadora.Application.DTOs;
using System.Collections.Generic;

namespace Locadora.Application.Interfaces
{
    public interface IApplicationServiceFilme
    {
        void Add(FilmeDTO filmeDTO);
        void Update(FilmeDTO filmeDTO);
        void Remove(FilmeDTO filmeDTO);
        IEnumerable<FilmeDTO> GetAll(string busca = "");
        FilmeDTO GetById(int id);
    }
}
