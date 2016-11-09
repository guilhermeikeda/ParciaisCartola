using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

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

        public UriImageSource EscudoURI { get; set; }

        [JsonProperty(PropertyName = "nome_cartola")]
        public string NomeCartola { get; set; }

		[JsonProperty(PropertyName = "foto_perfil")]
		public string FotoPerfil { get; set; }

        public UriImageSource FotoPerfilURI { get; set; }

        public string TotalParcial { get; set; }

        public double TotalParcialDouble { get; set; }

        public string PosicaoTabela { get; set; }

		public string NumeroAtletasPontuados { get; set; }
    }
}
