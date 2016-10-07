using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ParciaisCartola.Business;
using ParciaisCartola.Models;
using ParciaisCartola.ViewModel;

namespace ParciaisCartola
{
	public class AtletasViewModel : BaseViewModel, IControllerAtletas
	{
		private BusinessCartola cartolaBO;
		private ObservableCollection<Atleta> _AtletasList;
		private Time _Time;

		public string SlugTimeSelecionado { get; set; }
		public string NomeTimeSelecionado { get; set; }

		public AtletasViewModel()
		{
			cartolaBO = new BusinessCartola(this);
			AtletasList = new ObservableCollection<Atleta>();
		}

		public void ExibeListaAtletas(List<Atleta> atletas)
		{
			AtletasList = new ObservableCollection<Atleta>(atletas);
			ShowActivityIndicator = false;
		}

		public void TelaOnAppearing()
		{
			ShowActivityIndicator = true;
			AtletasList.Clear();
			Task.Run(() => BuscaAtleta());
		}

		public async Task BuscaAtleta()
		{
			await cartolaBO.BuscaAtletasTime(SlugTimeSelecionado);
		}

		public void ExibeTime(Time time)
		{
			Time = time;
		}

		public Time Time
		{
			get
			{
				return _Time;
			}
			set
			{
				if (_Time != value)
				{
					_Time = value;
					RaisePropertyChanged("Time");
				}
			}
		}

		public ObservableCollection<Atleta> AtletasList
		{
			get
			{
				return _AtletasList;
			}

			set
			{
				if (value != _AtletasList)
				{
					_AtletasList = value;
					RaisePropertyChanged("AtletasList");
				}
			}
		}
	}
}
