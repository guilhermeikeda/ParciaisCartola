using ParciaisCartola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParciaisCartola.Business.Interfaces
{
    public interface IControllerBuscaTime
    {
        void ExibeListaTimes(List<Time> times);
    }
}
