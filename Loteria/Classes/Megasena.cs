using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loteria.Classes
{
    internal class Megasena
    {
        public bool acumulado { get; set; }
        public int? numero { get; set; }
        public string? dataApuracao { get; set; }
        public string? dataProximoConcurso { get; set; }
        public int? numeroConcursoProximo { get; set; }
        public List<string> listaDezenas { get; set; } = new();
        public List<Premiacoes>? listaRateioPremio { get; set; }
        public double? valorEstimadoProximoConcurso { get; set; }
    }
}
