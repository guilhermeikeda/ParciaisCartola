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
        private string _TotalParcial;

		public string SlugTimeSelecionado { get; set; }
		public string NomeTimeSelecionado { get; set; }

		public AtletasViewModel()
		{
			cartolaBO = new BusinessCartola(this);
			AtletasList = new ObservableCollection<Atleta>();
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

        public void ExibeListaAtletas(List<Atleta> _atletas, string _TotalParcial)
        {
            AtletasList = new ObservableCollection<Atleta>(_atletas);
            TotalParcial = _TotalParcial;
            ShowActivityIndicator = false;
        }

        #region Objetos
        public string TotalParcial
        {
            get
            {
                return _TotalParcial;
            }
            set
            {
                if (_TotalParcial != value)
                {
                    _TotalParcial = value + " pts.";
                    RaisePropertyChanged("TotalParcial");
                }
            }
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

        #endregion

    }
}
