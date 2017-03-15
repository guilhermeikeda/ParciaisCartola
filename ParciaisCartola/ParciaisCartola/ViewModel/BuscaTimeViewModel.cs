using ParciaisCartola.Business;
using ParciaisCartola.Business.Interfaces;
using ParciaisCartola.Models;
using ParciaisCartola.Services;
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
        private AzureClient _client;

        public BuscaTimeViewModel()
        {
            TimesList = new ObservableCollection<Time>();
            cartolaBO = new BusinessCartola(this);
            _client = new AzureClient();
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
                //Task.Run(async () => await cartolaBO.BuscaTimesPageCache());
                Task.Run(async () => await GetTimesAzure());
            }
        }

        private async Task GetTimesAzure()
        {
            var x = await _client.GetTimes();
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