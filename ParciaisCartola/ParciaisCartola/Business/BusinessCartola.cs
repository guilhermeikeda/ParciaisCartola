using ParciaisCartola.Business.Interfaces;
using ParciaisCartola.Models;
using ParciaisCartola.Models.Response;
using ParciaisCartola.Services;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ParciaisCartola.Business
{
    public class BusinessCartola
    {
        private IControllerLigas controllerLigas;
        private IControllerUsuariosLiga controllerUsuariosLiga;
        private IControllerAtletas controllerAtletas;
        private IControllerBuscaTime controllerBuscaTime;

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

        public BusinessCartola(IControllerBuscaTime _controllerBuscaTime)
        {
            controllerBuscaTime = _controllerBuscaTime;
        }

        /// <summary>
        /// Busca times pelo nome do time.
        ///
        /// </summary>
        /// <param name="nomeTime"></param>
        /// <returns></returns>
        public async Task BuscaTimes(string nomeTime)
        {
            try
            {
                List<Time> times = await ServiceRepository.CartolaService.GetTimes(nomeTime);

                foreach (Time time in times)
                {
                    Time t = await ServiceRepository.CartolaService.GetPerfilTime(time.Slug);

                    if (t != null)
                    {
                        time.EscudoURI = new UriImageSource()
                        {
                            Uri = new Uri(t.Escudo),
                            CachingEnabled = true,
                        };

                        time.FotoPerfilURI = new UriImageSource()
                        {
                            Uri = new Uri(t.FotoPerfil),
                            CachingEnabled = true,
                            CacheValidity = TimeSpan.FromDays(3)
                        };
                        await ServiceRepository.CartolaService.InsertTimeCache(time.Slug, t);
                    }
                }

                await ServiceRepository.CartolaService.UpdateTimesPageCache(times);
                controllerBuscaTime.ExibeListaTimes(times);
            }
            catch (Exception e)
            {
                controllerBuscaTime.ExibeErro();
                System.Diagnostics.Debug.WriteLine(e);
            }
        }

        public async Task BuscaLiga(string nomeLiga)
        {
            try
            {
                List<Liga> ligas = await ServiceRepository.CartolaService.GetLigas(nomeLiga);
                foreach (var liga in ligas)
                {
                    liga.ImagemURI = new UriImageSource()
                    {
                        Uri = new Uri(liga.Imagem),
                        CachingEnabled = true,
                        CacheValidity = new TimeSpan(5, 0, 0)
                    };
                }
                await ServiceRepository.CartolaService.UpdateLigaPageCache(nomeLiga, ligas);
                controllerLigas.ExibeListaLigas(ligas);
            }
            catch (Exception e)
            {
                controllerLigas.ExibeErro();
                System.Diagnostics.Debug.WriteLine(e);
            }
        }

        public async Task BuscaTimesLiga(string slugLiga)
        {
            try
            {
                List<Time> times = await ServiceRepository.CartolaService.GetTimesLiga(slugLiga);
                ResponsePontuados atletasPontuados = await GetAtletasPontuados();

                foreach (Time time in times)
                {
                    List<Atleta> atletas = await ServiceRepository.CartolaService.GetAtletasTime(time.Slug);
                    double TotalParcial = 0.0;
                    int NumeroAtletasPontuados = 0;

                    time.EscudoURI = new UriImageSource()
                    {
                        Uri = new Uri(time.Escudo),
                        CachingEnabled = true,
                    };

                    foreach (Atleta atleta in atletas)
                    {
                        if (atletasPontuados.atletas.ContainsKey(atleta.ID))
                        {
                            TotalParcial += atletasPontuados.atletas[atleta.ID].pontuacao;
                            NumeroAtletasPontuados += 1;
                        }
                    }

                    time.TotalParcial = string.Format("{0:0.00}", TotalParcial);
                    time.TotalParcialDouble = TotalParcial;
                    time.NumeroAtletasPontuados = NumeroAtletasPontuados + "/12";

                    await ServiceRepository.CartolaService.InsertTimeCache(time.Slug, time);
                }

                times = times.OrderByDescending(time => time.TotalParcialDouble).ToList();

                for (var i = 0; i < times.Count; i++)
                {
                    times[i].PosicaoTabela = (i + 1).ToString() + 'º';
                }
                controllerUsuariosLiga.ExibeTimesLiga(times);
            }
            catch (ApiException a)
            {
                if (a.StatusCode.Equals(HttpStatusCode.Unauthorized))
                {
                    await AutenticaAdmin();
                    BuscaTimesLiga(slugLiga);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
        }

        public async Task BuscaAtletasTime(string slugTime)
        {
            Time time = new Time();
            double pontuacaoParcial = 0;

            try
            {
                time = await ServiceRepository.CartolaService.GetTimeCache(slugTime);
                controllerAtletas.ExibeTime(time);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }

            try
            {
                List<Atleta> atletas = await ServiceRepository.CartolaService.GetAtletasTime(slugTime);
                ResponsePontuados atletasPontuados = await GetAtletasPontuados();

                foreach (var atleta in atletas)
                {
                    if (atletasPontuados.atletas.ContainsKey(atleta.ID))
                    {
                        var pontuacao = atletasPontuados.atletas[atleta.ID].pontuacao;
                        atleta.PontosParcial = string.Format("{0:0.00}", pontuacao);
                        pontuacaoParcial += pontuacaoParcial;
                    }
                    else
                        atleta.PontosParcial = "-";

                    atleta.FotoURI = new UriImageSource()
                    {
                        Uri = new Uri(atleta.Foto.Replace("FORMATO", "50x50")),
                        CachingEnabled = true
                    };
                }

                atletas = atletas.OrderBy(atleta => atleta.PosicaoID).ToList();
                controllerAtletas.ExibeListaAtletas(atletas, string.Format("{0:0.00}", pontuacaoParcial));
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
        }

        private async Task<ResponsePontuados> GetAtletasPontuados()
        {
            try
            {
                ResponsePontuados atletasPontuados = await ServiceRepository.CartolaService.GetAtletasPontuados();
                return atletasPontuados;
            }
            catch (ApiException e)
            {
                System.Diagnostics.Debug.WriteLine(e);

                if (e.StatusCode.Equals(HttpStatusCode.NotFound))
                {
                    return await ServiceRepository.CartolaService.GetAtletasPontuadosCache();
                }
                throw e;
            }
        }

        public async Task BuscaLigaCache()
        {
            try
            {
                LigaPageCache _ligaPageCache = await ServiceRepository.CartolaService.GetLigaPageCache();
                if (_ligaPageCache != null)
                {
                    controllerLigas.ExibeLigaPageCache(_ligaPageCache);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
        }

        public async Task BuscaTimesPageCache()
        {
            try
            {
                List<Time> times = await ServiceRepository.CartolaService.GetTimesPageCache();
                if (times != null)
                {
                    controllerBuscaTime.ExibeListaTimes(times);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
        }

        /// <summary>
        /// Ao realizar alguma busca na API da Globo, caso ela retorne StatusCode = Unauthorized, devemos
        /// realizar o login e passar o token para as demais chamadas
        /// </summary>
        private async Task AutenticaAdmin()
        {
            await ServiceRepository.CartolaService.AutenticaUsuarioGlobo("gci_japoneis@hotmail.com", "345288ikeda");
        }
    }
}