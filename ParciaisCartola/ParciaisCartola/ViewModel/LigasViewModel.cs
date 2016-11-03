using GalaSoft.MvvmLight;
using ParciaisCartola.Business;
using ParciaisCartola.Business.Interfaces;
using ParciaisCartola.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System;
using Xamarin.Forms;

namespace ParciaisCartola.ViewModel
{
    public class LigasViewModel : BaseViewModel, IControllerLigas
    {
        private string _NomeLiga;
        private ObservableCollection<Liga> _LigasList;
        private BusinessCartola cartolaBO;

        public LigasViewModel()
        {
            cartolaBO = new BusinessCartola(this);
			LigasList = new ObservableCollection<Liga>();
        }

        public void BuscarLiga()
        {
			if (!string.IsNullOrEmpty(NomeLiga))
			{
				ShowActivityIndicator = true;
				Task.Run(async () => await cartolaBO.BuscaLiga(NomeLiga));
			}
        }

        public void ExibeListaLigas(List<Liga> _Ligas)
        {
            LigasList = new ObservableCollection<Liga>(_Ligas);
            ShowActivityIndicator = false;
        }

		public void ExibeLigaPageCache(LigaPageCache _LigaPageCache)
		{
			Device.BeginInvokeOnMainThread(() =>
			{ 
				LigasList = new ObservableCollection<Liga>(_LigaPageCache.Ligas);
			});
		}

		internal void  TelaOnAppearing()
		{
			if(LigasList.Count == 0)
				Task.Run(async() => await cartolaBO.BuscaLigaCache());
		}

		public string NomeLiga
        {
            get
            {
                return _NomeLiga;
            }
            set
            {
                if (_NomeLiga != value)
                {
                    _NomeLiga = value;
                    RaisePropertyChanged("NomeLiga");
                }
            }
        }

        public ObservableCollection<Liga> LigasList
        {
            get
            {
                return _LigasList;
            }
            set
            {
                if(_LigasList != value)
                {
                    _LigasList = value;
                    RaisePropertyChanged("LigasList");
                }
            }
        }
    }
}