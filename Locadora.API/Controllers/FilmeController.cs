using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Locadora.Application.DTOs;
using Locadora.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Locadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly IApplicationServiceFilme _applicationServiceFilme;

        public FilmeController(IApplicationServiceFilme applicationService)
        {
            _applicationServiceFilme = applicationService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<FilmeDTO>> Get()
        {
            return Ok(_applicationServiceFilme.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<FilmeDTO> Get(int id)
        {
            return Ok(_applicationServiceFilme.GetById(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] FilmeDTO filmeDTO)
        {
            try
            {
                if (filmeDTO == null)
                    return NotFound();

                _applicationServiceFilme.Add(filmeDTO);
                return Ok("Sucesso");
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] FilmeDTO filme)
        {
            try
            {
                if (filme == null)
                    return NotFound();

                _applicationServiceFilme.Update(filme);
                return Ok("Sucesso");
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] FilmeDTO filme)
        {
            try
            {
                if (filme == null)
                    return NotFound();

                _applicationServiceFilme.Remove(filme);
                return Ok("Sucesso");
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}
