using Locadora.Application.DTOs;
using Locadora.Application.Interfaces;
using Locadora.Application.Interfaces.Mapper;
using Locadora.Domain.Core.Interfaces.Services;
using System.Collections.Generic;

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
            var filme = mapper.MapperDTOToEntity(filmeDTO);
            service.Add(filme);
        }

        public IEnumerable<FilmeDTO> GetAll()
        {
            var filmes = service.GetAll();
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
            var filme = mapper.MapperDTOToEntity(filmeDTO);
            service.Update(filme);
        }
    }
}
