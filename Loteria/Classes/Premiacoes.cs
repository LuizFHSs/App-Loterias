using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loteria.Classes
{
    internal class Premiacoes
    {
        public string descricaoFaixa { get; set; } = string.Empty;
        public int faixa { get; set; }
        public int numeroDeGanhadores { get; set; }
        public double valorPremio { get; set; }
    }
}
