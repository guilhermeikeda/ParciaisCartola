using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParciaisCartola.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<LigasViewModel>();
            SimpleIoc.Default.Register<UsuariosLigaViewModel>();
        }

        public LigasViewModel Ligas
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LigasViewModel>();
            }
        }

        public UsuariosLigaViewModel UsuariosLiga
        {
            get
            {
                return ServiceLocator.Current.GetInstance<UsuariosLigaViewModel>();
            }
        }
    }
}
