using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System;
using Xamarin.Forms;


namespace ParciaisCartola.Models
{
    public class Time
    {
        [Version]
        public string Version { get; set; }

        [JsonProperty(PropertyName = "Nome")]
        public string Nome { get; set; }

        [JsonProperty(PropertyName = "slug")]
        public string Slug { get; set; }

        [JsonProperty(PropertyName = "ImagemEscudo")]
        public string Escudo { get; set; }

        public UriImageSource EscudoURI { get; set; }

        [JsonProperty(PropertyName = "NomeCartola")]
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
