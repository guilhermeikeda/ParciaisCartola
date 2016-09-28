using GalaSoft.MvvmLight;
using ParciaisCartola.Business;
using ParciaisCartola.Business.Interfaces;
using ParciaisCartola.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

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
            NomeLiga = "Opus Software";
        }

        public void BuscarLiga()
        {
            ShowActivityIndicator = true;
            Task.Run(async () => await cartolaBO.BuscaLiga(NomeLiga));
        }

        public void ExibeListaLigas(List<Liga> _Ligas)
        {
            LigasList = new ObservableCollection<Liga>(_Ligas);
            ShowActivityIndicator = false;
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