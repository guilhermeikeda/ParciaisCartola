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
            SimpleIoc.Default.Register<BuscaTimeViewModel>();
        }

        public BuscaTimeViewModel BuscaTime
        {
            get
            {
                return ServiceLocator.Current.GetInstance<BuscaTimeViewModel>();
            }
        }
    }
}
