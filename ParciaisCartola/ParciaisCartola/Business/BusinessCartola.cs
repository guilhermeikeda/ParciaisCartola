using ParciaisCartola.Business.Interfaces;
using ParciaisCartola.Models;
using ParciaisCartola.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParciaisCartola.Business
{
    public class BusinessCartola
    {
        private IControllerLigas controllerLigas;
        private IControllerUsuariosLiga controllerUsuariosLiga;

        public BusinessCartola(IControllerLigas _controllerLigas)
        {
            controllerLigas = _controllerLigas;
        }

        public BusinessCartola(IControllerUsuariosLiga _controllerUsuariosLiga)
        {
            controllerUsuariosLiga = _controllerUsuariosLiga;
        }

        public async Task BuscaLiga(string nomeLiga)
        {
            try
            {
                List<Liga> ligas = await ServiceRepository.CartolaService.GetLigas(nomeLiga);
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
                foreach (Time time in times)
                {
                    List<Atleta> atletas = await ServiceRepository.CartolaService.GetAtletasTime(time.Slug);
                    double TotalParcial = 0.0;
                    foreach (Atleta atleta in atletas)
                    {
                        TotalParcial += atleta.Pontos;
                    }
                    time.TotalParcial = string.Format("{0:0.00}", TotalParcial);
                    time.TotalParcialDouble = TotalParcial;
                }
                times = times.OrderByDescending(time => time.TotalParcialDouble).ToList();
                controllerUsuariosLiga.ExibeTimesLiga(times);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
        }
    }
}