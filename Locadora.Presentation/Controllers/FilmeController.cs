using Locadora.Application.DTOs;
using Locadora.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Locadora.Presentation.Controllers
{
    public class FilmeController : Controller
    {
        private readonly IApplicationServiceFilme _service;

        public FilmeController(IApplicationServiceFilme applicationService)
        {
            _service = applicationService;
        }

        public IActionResult Index()
        {
            try
            {
                var filmes = _service.GetAll();
                return View(filmes);
            }
            catch (Exception exc)
            {
                throw exc;
            }

        }

        [HttpGet]
        public ActionResult Create()
        {
            try
            {
                FilmeDTO filme = new FilmeDTO();
                return View(filme);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        [HttpPost]
        public ActionResult Create(FilmeDTO filme)
        {
            try
            {
                _service.Add(filme);
                return RedirectToAction("Index");
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                var filme = _service.GetById(id);
                return View(filme);
            }
            catch (Exception exc)
            {
                throw exc;
            }

        }

        [HttpPost]
        public ActionResult Edit(FilmeDTO filme)
        {
            try
            {
                _service.Update(filme);
                return RedirectToAction("Index");
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                var filme = _service.GetById(id);
                return View(filme);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        [HttpPost]
        public ActionResult Delete(FilmeDTO filme)
        {
            try
            {
                _service.Remove(filme);
                return RedirectToAction("Index");
            }
            catch (Exception exc)
            {
                throw exc;
            }
       
        }

        public ActionResult Details(int id)
        {
            try
            {
                var filme = _service.GetById(id);
                return View(filme);
            }
            catch (Exception exc)
            {
                throw exc;
            }    
        }

        public ActionResult ObterCapa(int id)
        {
            try
            {
                var filme = _service.GetById(id);

                if (!string.IsNullOrEmpty(filme.ContentType))
                {
                    return File(filme.CapaByte, filme.ContentType);
                }

                return File("images/not-found.jpg", "image/jpeg");
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        private FilmeDTO ObterBytesCapa(int id)
        {
            try
            {
                return _service.GetById(id);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}
