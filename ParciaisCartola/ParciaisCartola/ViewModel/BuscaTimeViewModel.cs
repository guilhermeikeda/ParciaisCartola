using ParciaisCartola.Business;
using ParciaisCartola.Business.Interfaces;
using ParciaisCartola.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

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
        }

        public void ExibeListaTimes(List<Time> times)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                TimesList = new ObservableCollection<Time>(times);
                ShowActivityIndicator = false;
            });
        }

        internal void BuscarTime()
        {
            if (!string.IsNullOrEmpty(NomeTime))
            {
                ShowActivityIndicator = true;
                Task.Run(async () => await cartolaBO.BuscaTimes(NomeTime));
            }
        }

        internal void TelaOnAppearing()
        {
            if (TimesList.Count == 0)
            {
                Task.Run(async () => await cartolaBO.BuscaTimesPageCache());
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