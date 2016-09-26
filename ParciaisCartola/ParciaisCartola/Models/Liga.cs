using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParciaisCartola.Models
{
    public class Liga
    {
        [JsonProperty(PropertyName = "liga_id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "slug")]
        public string Slug { get; set; }

        [JsonProperty(PropertyName = "descricao")]
        public string Descricao { get; set; }

        [JsonProperty(PropertyName = "nome")]
        public string Nome { get; set; }

        [JsonProperty(PropertyName = "imagem")]
        public string Imagem { get; set; }
    }
}
