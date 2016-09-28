using GalaSoft.MvvmLight;

namespace ParciaisCartola.ViewModel
{
    public class BaseViewModel : ViewModelBase
    {
        protected bool _ShowActivityIndicator;

        public bool ShowActivityIndicator
        {
            get { return _ShowActivityIndicator; }
            set
            {
                if (_ShowActivityIndicator != value)
                    _ShowActivityIndicator = value;
                RaisePropertyChanged("ShowActivityIndicator");
            }
        }
    }
}