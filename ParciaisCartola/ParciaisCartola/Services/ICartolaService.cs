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
        Task<List<Time>> GetTimes(string nomeTime);

        Task<List<Liga>> GetLigas(string nomeLiga);

        Task<GloboLogin> AutenticaUsuarioGlobo(string email, string password);

        Task<List<Time>> GetTimesLiga(string slugLiga);

        Task<List<Atleta>> GetAtletasTime(string slugTime);

        Task<ResponsePontuados> GetAtletasPontuados();

		Task<Time> GetTimeCache(string slugLiga);

		Task InsertTimeCache(string slugTime, Time time);

        Task<ResponsePontuados> GetAtletasPontuadosCache();

        Task UpdateAtletasPontuados(ResponsePontuados atletasPontuados);

		Task<LigaPageCache> GetLigaPageCache();

		Task UpdateLigaPageCache(string nomeLiga, List<Liga> ligas);

		Task<Time> GetPerfilTime(string slugTime);

        Task<List<Time>> GetTimesPageCache();

        Task UpdateTimesPageCache(List<Time> _times);
    }
}
