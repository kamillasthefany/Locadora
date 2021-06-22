using Locadora.Application.DTOs;
using Locadora.Application.Interfaces.Mapper;
using Locadora.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Locadora.Application.Mapper
{
    public class MapperFilme : IMapperFilme
    {
        public Filme MapperDTOToEntity(FilmeDTO filmeDTO)
        {
            return new Filme
            {
                Titulo = filmeDTO.Titulo,
                Descricao = filmeDTO.Descricao
            };
        }

        public FilmeDTO MapperEntityToDTO(Filme filme)
        {
            return new FilmeDTO
            {
                Id = filme.Id,
                Titulo = filme.Titulo,
                Descricao = filme.Descricao
            };
        }

        public IEnumerable<FilmeDTO> MapperListDTOToEntity(IEnumerable<Filme> filmes)
        {
            var filmesDTO = filmes.Select(c => new FilmeDTO
            {
                Id = c.Id,
                Titulo = c.Titulo,
                Descricao = c.Descricao
            });

            return filmesDTO;
        }
    }
}
