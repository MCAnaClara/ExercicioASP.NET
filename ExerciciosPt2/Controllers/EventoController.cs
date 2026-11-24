using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ExerciciosPt2.Models;
using ExerciciosPt2.ViewModels;
using Microsoft.VisualBasic;




namespace ExerciciosPt2.Controllers
{
    public class EventoController : Controller
    {

        private static List<Evento> _evento = new()
        {
            new Evento {Id = 1, Nome = "Aniversário", Descricao = "Aniversário joao", Local = "Bairro da tijuca", DataEvento = new DateTime(2027, 8, 17), QuantidadeVagas = 200, ValorIngresso = 15},
            new Evento {Id = 2, Nome = "Casamento", Descricao = "Aniversário pedro", Local = "Bairro da tijuca", DataEvento = new DateTime(2027, 2, 17), QuantidadeVagas = 200, ValorIngresso = 15}
        };




        public IActionResult Index()
        {
            return View(_evento);
        }
        public IActionResult Detalhes(int id)
        {
            var evento = _evento.FirstOrDefault(a => a.Id == id);

            if (evento == null)
            {
                return NotFound();
            }
            return View(evento);
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]




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


        [HttpGet]
        public IActionResult Buscar()
        {
            return View(new BuscaEventoViewModel());
        }


        [HttpPost]
        public IActionResult Buscar(BuscaEventoViewModel vm)
        {
            vm.Resultados = _evento; // carrega a lista de alunos na propriedade Resultados do objeto vm


            if (!string.IsNullOrEmpty(vm.NomeBusca))
            {
                vm.Resultados = _evento.Where(a => a.Nome.Contains(vm.NomeBusca, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            
            return View(vm);
        }
    }
}