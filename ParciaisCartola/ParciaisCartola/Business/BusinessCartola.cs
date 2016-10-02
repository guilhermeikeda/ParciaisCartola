using ParciaisCartola.Business.Interfaces;
using ParciaisCartola.Models;
using ParciaisCartola.Models.Response;
using ParciaisCartola.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ParciaisCartola.Business
{
	public class BusinessCartola
	{
		private IControllerLigas controllerLigas;
		private IControllerUsuariosLiga controllerUsuariosLiga;
		private IControllerAtletas controllerAtletas;

		public BusinessCartola(IControllerLigas _controllerLigas)
		{
			controllerLigas = _controllerLigas;
		}

		public BusinessCartola(IControllerUsuariosLiga _controllerUsuariosLiga)
		{
			controllerUsuariosLiga = _controllerUsuariosLiga;
		}

		public BusinessCartola(IControllerAtletas _controllerAtletas)
		{
			controllerAtletas = _controllerAtletas;
		}

		public async Task BuscaLiga(string nomeLiga)
		{
			try
			{
                ResponsePontuados res = await ServiceRepository.CartolaService.GetAtletasPontuados();
				List<Liga> ligas = await ServiceRepository.CartolaService.GetLigas(nomeLiga);
                foreach(var liga in ligas)
                {
                    liga.ImagemURI = new UriImageSource()
                    {
                        Uri = new Uri(liga.Imagem),
                        CachingEnabled = true,
                        CacheValidity = new TimeSpan(5, 0, 0)
                    };
                }
				controllerLigas.ExibeListaLigas(ligas);
				//GloboLogin log = await ServiceRepository.CartolaService.AutenticaUsuarioGlobo("gci_japoneis@hotmail.com", "345288ikeda");
				//await ServiceRepository.CartolaService.GetUsuariosLiga("opus-software");
			}
			catch (Exception e)
			{
				System.Diagnostics.Debug.WriteLine(e);
			}
		}

		public async Task BuscaUsuariosLiga(string slugLiga)
		{
			try
			{
				List<Time> times = await ServiceRepository.CartolaService.GetUsuariosLiga(slugLiga);
                ResponsePontuados atletasPontuados = await ServiceRepository.CartolaService.GetAtletasPontuados();

                foreach (Time time in times)
				{
					List<Atleta> atletas = await ServiceRepository.CartolaService.GetAtletasTime(time.Slug);
                    time.EscudoURI = new UriImageSource()
                    {
                        Uri = new Uri(time.Escudo),
                        CachingEnabled = true,

                    };
					double TotalParcial = 0.0;
					foreach (Atleta atleta in atletas)
					{
                        atleta.FotoURI = new UriImageSource()
                        {
                            Uri = new Uri(atleta.Foto),
                            CachingEnabled = true

                        }
                        if(atletasPontuados.atletas.ContainsKey(atleta.ID))
                            TotalParcial += atletasPontuados.atletas[atleta.ID].pontuacao;
                    }
					time.TotalParcial = string.Format("{0:0.00}", TotalParcial);
					time.TotalParcialDouble = TotalParcial;
				}

				times = times.OrderByDescending(time => time.TotalParcialDouble).ToList();

				for (var i = 0; i < times.Count; i++)
				{
					times[i].PosicaoTabela = (i + 1).ToString() + 'º';
				}
				controllerUsuariosLiga.ExibeTimesLiga(times);
			}
			catch (Exception e)
			{
				System.Diagnostics.Debug.WriteLine(e);
			}
		}

		public async Task BuscaAtletasTime(string slugTime)
		{
			try
			{
				List<Atleta> atletas = await ServiceRepository.CartolaService.GetAtletasTime(slugTime);
				controllerAtletas.ExibeListaAtletas(atletas);
			}
			catch (Exception e)
			{
				System.Diagnostics.Debug.WriteLine(e);
			}
		}
	}
}