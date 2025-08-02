using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loteria.Classes
{
    internal class Lotofacil
    {
        public bool acumulado { get; set; }
        public int? numero { get; set; }
        public string? dataApuracao { get; set; }
        public string? dataProximoConcurso { get; set; }
        public int? numeroConcursoProximo { get; set; }
        public List<string> listaDezenas { get; set; } = new();
        public List<Premiacoes>? listaRateioPremio { get; set; }
        public double? valorEstimadoProximoConcurso { get; set; }

        // API https://loteriascaixa-api.herokuapp.com/api/loteria/concurso
        public int concurso { get; set; }
        public List<string> dezenas { get; set; } = new();
        public string data { get; set; } = string.Empty;
    }
}
