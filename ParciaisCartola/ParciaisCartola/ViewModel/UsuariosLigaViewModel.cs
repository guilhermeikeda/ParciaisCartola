using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ParciaisCartola.Business;
using ParciaisCartola.Business.Interfaces;
using ParciaisCartola.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ParciaisCartola.ViewModel
{
    public class UsuariosLigaViewModel : ViewModelBase, IControllerUsuariosLiga
    {
        private BusinessCartola cartolaBO;
        private ObservableCollection<Time> _ListaTimes;
        private RelayCommand _AtualizaPontuacao;

        public Liga ligaAtual;

        public UsuariosLigaViewModel()
        {
            cartolaBO = new BusinessCartola(this);
        }

        internal void TelaOnAppearing()
        {
            BuscaTimes();
        }

        internal void BuscaTimes()
        {
            Task.Run(async () =>
            {
                await cartolaBO.BuscaUsuariosLiga(ligaAtual.Slug);
            });
        }
        public void ExibeTimesLiga(List<Time> times)
        {
            ListaTimes = new ObservableCollection<Time>(times);
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

        public RelayCommand AtualizaPontuacao
        {
            get
            {
                return _AtualizaPontuacao ?? (_AtualizaPontuacao = new RelayCommand(() =>
                {
                    BuscaTimes();
                }));
            }
        }
    }
}