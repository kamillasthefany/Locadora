using Locadora.Application.DTOs;
using Locadora.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
            var filmes = _service.GetAll();
            return View(filmes);
        }

        [HttpGet]
        public ActionResult Create()
        {
            FilmeDTO filme = new FilmeDTO();
            return View(filme);
        }

        [HttpPost]
        public ActionResult Create(FilmeDTO filme)
        {
            _service.Add(filme);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var filme = _service.GetById(id);
            return View(filme);
        }

        [HttpPost]
        public ActionResult Edit(FilmeDTO filme)
        {
            _service.Update(filme);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var filme = _service.GetById(id);
            return View(filme);
        }

        [HttpPost]
        public ActionResult Delete(FilmeDTO filme)
        {        
            _service.Remove(filme);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var filme = _service.GetById(id);
            return View(filme);
        }

        public ActionResult ObterCapa(int id)
        {
            var filme = _service.GetById(id);

            if (!string.IsNullOrEmpty(filme.ContentType))
            {
                return File(filme.CapaByte, filme.ContentType);
            }

            return File("images/not-found.jpg", "image/jpeg");
        }
    }
}
