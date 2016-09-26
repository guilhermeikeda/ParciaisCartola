using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParciaisCartola.Services
{
    public static class ServiceRepository
    {
        private static IAPIService _ApiService = new APIService();
        private static ICartolaService _CartolaService;
        internal static ICartolaService CartolaService
        {
            get
            {
                _CartolaService = new CartolaService(_ApiService);
                return _CartolaService;
            }
        }
    }
}
