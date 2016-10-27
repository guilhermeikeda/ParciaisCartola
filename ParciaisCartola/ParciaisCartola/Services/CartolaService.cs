using Akavache;
using ParciaisCartola.Models;
using ParciaisCartola.Models.Requests;
using ParciaisCartola.Models.Response;
using Refit;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace ParciaisCartola.Services
{
    public class CartolaService : ICartolaService
    {
        private IAPIService apiService;
        private string GLOBO_ID = "1ba23e7940331e6bf2c724675da67eda9443337416c35674d58576c527542415a656e65365072596c5a597a346d6a39596c5a7564334f35453871694244654e5845707a443674454a4733437a376954683a303a6763695f6a61706f6e65697340686f746d61696c2e636f6d";
        private const string BD_ATLETASPONTUADOS = "BD_ATLETASPONTUADOS";
        private const string BD_TOKENGLOBO = "BD_TOKENGLOBO";

        public CartolaService(IAPIService _apiService)
        {
            apiService = _apiService;
        }

        public async Task<List<Liga>> GetLigas(string nomeLiga)
        {
            try
            {
                var response = await apiService.RequestService.GetLigasByName(nomeLiga) as List<Liga>;
                Liga liga = response[0];
                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<GloboLogin> AutenticaUsuarioGlobo(string email, string password)
        {
            try
            {
                RequestGloboLogin req = new RequestGloboLogin(email, password);
                var response = await apiService.RequestServiceGlobo.AutenticaUsuarioGlobo(req) as GloboLogin;
                await UpdateTokenGlobo(response.Token);
                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private async Task UpdateTokenGlobo(string token)
        {
            try
            {
                await BlobCache.LocalMachine.InsertObject<string>(BD_TOKENGLOBO, token);
                GLOBO_ID = token;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
        }

        private async Task<string> GetTokenGlobo()
        {
            try
            {
                return await BlobCache.LocalMachine.GetObject<string>(BD_TOKENGLOBO);
            }catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return "";
            }
        }
        public async Task<List<Time>> GetTimes(string slugLiga)
        {
            try
            {
                var token = await GetTokenGlobo();
                var response = await apiService.RequestService.GetTimesLiga(slugLiga, token) as ResponseLigaTimes;
                return response.times;
            }
            catch (ApiException a)
            {
                throw a;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task InsertTimeCache(string slugTime, Time time)
        {
            try
            {
                await BlobCache.LocalMachine.InsertObject<Time>(slugTime, time);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                throw e;
            }
        }

        public async Task<Time> GetTimeCache(string slugTime)
        {
            try
            {
                Time time = await BlobCache.LocalMachine.GetObject<Time>(slugTime);
                return time;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                throw e;
            }
        }

        public async Task<List<Atleta>> GetAtletasTime(string slugTime)
        {
            try
            {
                var response = await apiService.RequestService.GetAtletasTime(slugTime) as ResponseTime;
                return response.atletas;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<ResponsePontuados> GetAtletasPontuados()
        {
            try
            {
                var response = await apiService.RequestService.GetAtletasPontuados() as ResponsePontuados;
                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task UpdateAtletasPontuados(ResponsePontuados atletasPontuados)
        {
            try
            {
                await BlobCache.LocalMachine.InsertObject<ResponsePontuados>(BD_ATLETASPONTUADOS, atletasPontuados, TimeSpan.FromDays(7));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<ResponsePontuados> GetAtletasPontuadosCache()
        {
            try
            {
                ResponsePontuados res = await BlobCache.LocalMachine.GetObject<ResponsePontuados>(BD_ATLETASPONTUADOS);
                return res;
            }
            catch (KeyNotFoundException)
            {
                return new ResponsePontuados()
                {
                    atletas = new Dictionary<int, ResponsePontuados.AtletasPontuados>()
                };
            }
        }
    }
}