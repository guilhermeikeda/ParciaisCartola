using System.Collections.Generic;
using ParciaisCartola.Models;

namespace ParciaisCartola
{
	public interface IControllerAtletas
	{
		void ExibeListaAtletas(List<Atleta> atletas, string TotalParcial);

		void ExibeTime(Time time);
	}
}
