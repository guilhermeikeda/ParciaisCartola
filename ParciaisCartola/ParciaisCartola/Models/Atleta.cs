using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ParciaisCartola.Models
{
    public class Atleta
    {
        [JsonProperty(PropertyName = "apelido")]
        public string Apelido { get; set; }

        [JsonProperty(PropertyName = "pontos_num")]
        public double Pontos { get; set; }

        [JsonProperty(PropertyName = "foto")]
        public string Foto { get; set; }

        public UriImageSource FotoURI { get; set; }

        [JsonProperty(PropertyName = "atleta_id")]
        public int ID { get; set; }
    }
}
