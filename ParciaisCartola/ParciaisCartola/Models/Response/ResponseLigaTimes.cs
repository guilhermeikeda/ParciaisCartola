using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParciaisCartola.Models.Response
{
    public class ResponseLigaTimes
    {
        public Liga liga { get; set; }

        public List<Time> times { get; set; }

        public int pagina { get; set; }
    }

}
