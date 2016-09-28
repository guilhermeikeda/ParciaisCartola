﻿using ParciaisCartola.Models;
using ParciaisCartola.Models.Requests;
using ParciaisCartola.Models.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParciaisCartola.Services
{
    public class CartolaService : ICartolaService
    {
        private IAPIService apiService;
        private const string GLOBO_ID = "1ba23e7940331e6bf2c724675da67eda9443337416c35674d58576c527542415a656e65365072596c5a597a346d6a39596c5a7564334f35453871694244654e5845707a443674454a4733437a376954683a303a6763695f6a61706f6e65697340686f746d61696c2e636f6d";
        public CartolaService(IAPIService _apiService)
        {
            apiService = _apiService;
        }

        public async Task<List<Liga>> GetLigas(string nomeLiga)
        {
            var response = await apiService.RequestService.GetLigasByName(nomeLiga) as List<Liga>;
            Liga liga = response[0];
            return response;
        }

        public async Task<GloboLogin> AutenticaUsuarioGlobo(string email, string password)
        {
            try
            {
                RequestGloboLogin req = new RequestGloboLogin(email, password);
                var response = await apiService.RequestServiceGlobo.AutenticaUsuarioGlobo(req) as GloboLogin;
                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Time>> GetUsuariosLiga(string slugLiga)
        {
            try
            {                
                var response = await apiService.RequestService.GetUsuariosLiga(slugLiga, GLOBO_ID) as ResponseLigaTimes;
                return response.times;
            }
            catch (Exception e)
            {
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
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}