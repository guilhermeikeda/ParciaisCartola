using GalaSoft.MvvmLight.Command;
using ParciaisCartola.Business;
using ParciaisCartola.Business.Interfaces;
using ParciaisCartola.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ParciaisCartola.ViewModel
{
    public class TimesViewModel : BaseViewModel, IControllerUsuariosLiga
    {
        private BusinessCartola cartolaBO;
        private ObservableCollection<Time> _ListaTimes;
        private RelayCommand _AtualizaPontuacao;
        private bool _IsBusy;

        public Liga ligaAtual;

        public TimesViewModel()
        {
            cartolaBO = new BusinessCartola(this);
        }

        internal void TelaOnAppearing()
        {
            ListaTimes = new ObservableCollection<Time>();

            ShowActivityIndicator = true;
            Task.Run(async () => await BuscaTimes());            
        }

        internal async Task BuscaTimes()
        {                    
            await cartolaBO.BuscaTimesLiga(ligaAtual.Slug);            
        }

        public void ExibeTimesLiga(List<Time> times)
        {
            ListaTimes = new ObservableCollection<Time>(times);
            IsBusy = false;
            ShowActivityIndicator = false;
        }

        public ObservableCollection<Time> ListaTimes
        {
            get { return _ListaTimes; }
            set
            {
                if (_ListaTimes != value)
                {
                    _ListaTimes = value;
                    RaisePropertyChanged("ListaTimes");
                }
            }
        }

        public bool IsBusy
        {
            get { return _IsBusy; }
            set
            {
                if (_IsBusy != value)
                {
                    _IsBusy = value;
                    RaisePropertyChanged("IsBusy");
                }
            }
        }

        public RelayCommand AtualizaPontuacao
        {
            get
            {
                return _AtualizaPontuacao ?? (_AtualizaPontuacao = new RelayCommand(() =>
                {
                    IsBusy = true;
                    Task.Run(async ()=> await BuscaTimes());                    
                }));
            }
        }
    }
}