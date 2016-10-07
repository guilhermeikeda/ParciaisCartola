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
            SimpleIoc.Default.Register<TimesViewModel>();
			SimpleIoc.Default.Register<AtletasViewModel>();
			SimpleIoc.Default.Register<MenuViewModel>();
        }

		public MenuViewModel Menu
		{
			get
			{
				return ServiceLocator.Current.GetInstance<MenuViewModel>();
			}
		}

		public AtletasViewModel Atletas
		{
			get
			{
				return ServiceLocator.Current.GetInstance<AtletasViewModel>();
			}
		}

        public LigasViewModel Ligas
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LigasViewModel>();
            }
        }

        public TimesViewModel Times
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TimesViewModel>();
            }
        }
    }
}
