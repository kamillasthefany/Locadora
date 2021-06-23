using Locadora.Application.DTOs;
using Locadora.Application.Interfaces.Mapper;
using Locadora.Domain.Entities;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Locadora.Application.Mapper
{
    public class MapperFilme : IMapperFilme
    {
        public Filme MapperDTOToEntity(FilmeDTO filmeDTO)
        {
            var filme = new Filme
            {
                Titulo = filmeDTO.Titulo,
                Descricao = filmeDTO.Descricao
            };

            using (var memoryStream = new MemoryStream())
            {
                filmeDTO.Capa.CopyTo(memoryStream);
                filme.ContentType = filmeDTO.Capa.ContentType;
                filme.Capa = memoryStream.ToArray();
            }

            return filme;
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
