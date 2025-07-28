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
    }
}
