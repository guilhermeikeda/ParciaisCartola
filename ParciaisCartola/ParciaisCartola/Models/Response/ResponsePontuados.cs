using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParciaisCartola.Models.Response
{
    public class ResponsePontuados
    {
        public int Rodada { get; set; }

        public Dictionary<int, AtletasPontuados> atletas { get; set; }

       public class AtletasPontuados
        {
            public double pontuacao { get; set; }
        }
    }
}
