using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExerciciosPt2.Models;


namespace ExerciciosPt2.ViewModels
{
    public class BuscaEventoViewModel
    {
        public string? NomeBusca { get; set; }
        public string? LocalBusca { get; set; }

        public DateTime? DataInicial { get; set; }

        public List<Evento> Resultados { get; set; } = new();
    }
}