using ParciaisCartola.Models;
using ParciaisCartola.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParciaisCartola.Services
{
    public interface ICartolaService
    {
        Task<List<Liga>> GetLigas(string nomeLiga);

        Task<GloboLogin> AutenticaUsuarioGlobo(string email, string password);

        Task<List<Time>> GetTimes(string slugLiga);

        Task<List<Atleta>> GetAtletasTime(string slugTime);

        Task<ResponsePontuados> GetAtletasPontuados();

		Task<Time> GetTimeCache(string slugLiga);

		Task InsertTimeCache(string slugTime, Time time);
    }
}
