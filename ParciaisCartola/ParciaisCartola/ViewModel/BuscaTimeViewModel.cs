using ParciaisCartola.Business;
using ParciaisCartola.Business.Interfaces;
using ParciaisCartola.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ParciaisCartola.ViewModel
{
    public class BuscaTimeViewModel : BaseViewModel, IControllerBuscaTime
    {
        private ObservableCollection<Time> _TimesList;
        private string _NomeTime;

        private BusinessCartola cartolaBO;

        public BuscaTimeViewModel()
        {
            TimesList = new ObservableCollection<Time>();
            cartolaBO = new BusinessCartola(this);
			NomeTime = "Ikeda F.C";
        }

        public void ExibeListaTimes(List<Time> times)
        {
            TimesList = new ObservableCollection<Time>(times);
            ShowActivityIndicator = false;
        }

        internal void BuscarTime()
        {
            if (!string.IsNullOrEmpty(NomeTime))
            {
                ShowActivityIndicator = true;
                Task.Run(async () => await cartolaBO.BuscaTimes(NomeTime));
            }
        }

        #region Objects

        public string NomeTime
        {
            get
            {
                return _NomeTime;
            }
            set
            {
                if (_NomeTime != value)
                {
                    _NomeTime = value;
                    RaisePropertyChanged("NomeTime");
                }
            }
        }

        public ObservableCollection<Time> TimesList
        {
            get
            {
                return _TimesList;
            }

            set
            {
                if (_TimesList != value)
                {
                    _TimesList = value;
                    RaisePropertyChanged("TimesList");
                }
            }
        }

        #endregion Objects
    }
}