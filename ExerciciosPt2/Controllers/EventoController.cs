using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ExerciciosPt2.Controllers
{
    public class Evento : Controller
    {

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]  //formulario (botao de submit)

         public IActionResult Criar(Evento evento)
        {
            if (!ModelState.IsValid)
            {
                return View(evento);
            }

            evento.Id = _evento.Any() ? _evento.Max(a => a.Id) + 1 : 1;

            _evento.Add(evento);

            return RedirectToAction("Index");
        } 
    }
}