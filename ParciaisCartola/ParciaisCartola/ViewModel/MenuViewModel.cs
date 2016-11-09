using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ParciaisCartola.ViewModel;
using ParciaisCartola.Custom;
using ParciaisCartola.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ParciaisCartola
{
	public class MenuViewModel : BaseViewModel
	{
		private ObservableCollection<ItemMenu> _MenuItems;
        private Dictionary<MenuType, CartolaNavigationPage> Pages;

		public MenuViewModel()
		{
			
			var menu = new List<ItemMenu>();
			menu.Add(new ItemMenu() { Titulo = "Ligas", Tipo = MenuType.LIGAS});
			menu.Add(new ItemMenu() { Titulo = "Seu Time", Tipo = MenuType.TIMES});
			MenuItems = new ObservableCollection<ItemMenu>(menu);
            Pages = new Dictionary<MenuType, CartolaNavigationPage>();
		}

        public CartolaNavigationPage GetCurrentPage(MenuType menuType)
        {
            if (!Pages.ContainsKey(menuType))
            {
                
                switch(menuType)
                {
                    case MenuType.LIGAS:
                        Pages.Add(menuType, new CartolaNavigationPage(new LigasPage()));
                        break;
                    case MenuType.TIMES:
                        // Pages.Add(menuType, new CartolaNavigationPage(new MeuTimePage()));
                        Pages.Add(menuType, new CartolaNavigationPage(new BuscaTimePage()));
                        break;
                }
                
            }            
            return Pages[menuType];
        }

        public async Task PushPage(MenuType origem, ContentPage destino)
        {
           await Pages[origem].PushAsync(destino);
        }

        public async Task PopPage(MenuType origem)
        {
            await Pages[origem].PopAsync();
        }

		public ObservableCollection<ItemMenu> MenuItems { 
			get
			{
				return _MenuItems;
			}

			set
			{
				if (value != _MenuItems) {
					_MenuItems = value;
					RaisePropertyChanged("MenuItems");
				}
			}

		}
	}
}
