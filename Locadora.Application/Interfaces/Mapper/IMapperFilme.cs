using Locadora.Application.DTOs;
using Locadora.Domain.Entities;
using System.Collections.Generic;

namespace Locadora.Application.Interfaces.Mapper
{
    public interface IMapperFilme
    {
        Filme MapperDTOToEntity(FilmeDTO filmeDTO);
        FilmeDTO MapperEntityToDTO(Filme filme);
        IEnumerable<FilmeDTO> MapperListDTOToEntity(IEnumerable<Filme> filmeDTO);
    }
}
