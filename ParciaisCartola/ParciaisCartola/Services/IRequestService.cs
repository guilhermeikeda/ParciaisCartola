using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refit;
using ParciaisCartola.Models;
using ParciaisCartola.Models.Requests;
using ParciaisCartola.Models.Response;

namespace ParciaisCartola.Services
{
    [Headers("Accept: application/json")]
    public interface IRequestService
    {
        [Get("/ligas?q={nomeLiga}")]
        Task<List<Liga>> GetLigasByName(string nomeLiga);

        [Post("/authentication")]
        Task<GloboLogin> AutenticaUsuarioGlobo([Body] RequestGloboLogin nomeLiga);

        [Get("/auth/liga/{nomeLiga}")]
        Task<ResponseLigaTimes> GetUsuariosLiga(string nomeLiga, [Header("X-GLB-Token")] string globoId);

        [Get("/time/{slugTime}")]
        Task<ResponseTime> GetAtletasTime(string slugTime);

    }
}
