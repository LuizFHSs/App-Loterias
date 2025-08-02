using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loteria.Classes
{
    internal class Federal
    {
        public string dataApuracao { get; set; } = string.Empty;
        public int numero { get; set; } = 0;
        public List<string> listaDezenas { get; set; } = new();

        // API https://loteriascaixa-api.herokuapp.com/api/loteria/concurso
        // API https://loteriascaixa-api.herokuapp.com/api/loteria/concurso
        public int concurso { get; set; }
        public List<string> dezenas { get; set; } = new();
        public string data { get; set; } = string.Empty;
    }
}
