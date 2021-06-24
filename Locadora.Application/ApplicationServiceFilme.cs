using Locadora.Application.DTOs;
using Locadora.Application.Interfaces;
using Locadora.Application.Interfaces.Mapper;
using Locadora.Domain.Core.Interfaces.Services;
using Locadora.Domain.Entities;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Locadora.Application
{
    public class ApplicationServiceFilme : IApplicationServiceFilme
    {
        private readonly IServiceFilme service;
        private readonly IMapperFilme mapper;

        public ApplicationServiceFilme(IServiceFilme _service, IMapperFilme _mapper)
        {
            service = _service;
            mapper = _mapper;
        }

        public void Add(FilmeDTO filmeDTO)
        {
            Filme filme = new Filme
            {
                Titulo = filmeDTO.Titulo,
                Descricao = filmeDTO.Descricao
            };

            ObterCapa(filmeDTO, filme);

            service.Add(filme);
        }

        public IEnumerable<FilmeDTO> GetAll(string busca = "")
        {
            var filmes = service.GetAll();

            if (!string.IsNullOrEmpty(busca))
            {
                filmes = filmes.Where(c => c.Titulo.ToUpper()
                                            .StartsWith(busca.ToUpper()));
            }

            return mapper.MapperListDTOToEntity(filmes);
        }

        public FilmeDTO GetById(int id)
        {
            var filme = service.GetById(id);
            return mapper.MapperEntityToDTO(filme);
        }

        public void Remove(FilmeDTO filmeDTO)
        {
            var filme = mapper.MapperDTOToEntity(filmeDTO);
            service.Remove(filme);
        }

        public void Update(FilmeDTO filmeDTO)
        {
            var filme = service.GetById(filmeDTO.Id);
            filme.Titulo = filmeDTO.Titulo;
            filme.Descricao = filmeDTO.Descricao;

            ObterCapa(filmeDTO, filme);

            service.Update(filme);
        }

        private void ObterCapa(FilmeDTO filmeDTO, Filme filme)
        {
            if (filmeDTO.Capa != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    filmeDTO.Capa.CopyTo(memoryStream);
                    filme.ContentType = filmeDTO.Capa.ContentType;
                    filme.Capa = memoryStream.ToArray();
                }
            }
        }
    }
}
