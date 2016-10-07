using ModernHttpClient;
using Refit;
using System;
using System.Net.Http;
using Akavache;

namespace ParciaisCartola.Services
{
    public class APIService : IAPIService
    {
        private const string ApiBaseAddress = "https://api.cartolafc.globo.com";
        private const string ApiGloboAddress = "https://login.globo.com/api";

        private readonly Lazy<IRequestService> _requestService;

        private readonly Lazy<IRequestService> _requestServiceGlobo;


        public APIService()
        {
			BlobCache.ApplicationName = "ParciaisCartola";
            Func<HttpMessageHandler, IRequestService> createClient = (messageHandler) =>
            {
                var client = new HttpClient(messageHandler)
                {
                    BaseAddress = new Uri(ApiBaseAddress)
                };

                return RestService.For<IRequestService>(client);
            };

            Func<HttpMessageHandler, IRequestService> createClientGlobo = (messageHandler) =>
            {
                var client = new HttpClient(messageHandler)
                {
                    BaseAddress = new Uri(ApiGloboAddress)
                };

                return RestService.For<IRequestService>(client);
            };

            _requestService = new Lazy<IRequestService>(() => createClient(
               new NativeMessageHandler()));

            _requestServiceGlobo = new Lazy<IRequestService>(() => createClientGlobo(
               new NativeMessageHandler()));
        }

        public IRequestService RequestService
        {
            get
            {
                return _requestService.Value;
            }
        }

        public IRequestService RequestServiceGlobo
        {
            get
            {
                return _requestServiceGlobo.Value;
            }
        }
    }
}