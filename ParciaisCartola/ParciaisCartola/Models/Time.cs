using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParciaisCartola.Models
{
    public class Time
    {
        [JsonProperty(PropertyName = "nome")]
        public string Nome { get; set; }

        [JsonProperty(PropertyName = "slug")]
        public string Slug { get; set; }

        [JsonProperty(PropertyName = "url_escudo_png")]
        public string Escudo { get; set; }

        [JsonProperty(PropertyName = "nome_cartola")]
        public string NomeCartola { get; set; }
      
        public string TotalParcial { get; set; }

        public double TotalParcialDouble { get; set; }
    }
}
