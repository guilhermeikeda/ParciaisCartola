using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParciaisCartola.Models;
using Xamarin.Forms;

namespace ParciaisCartola.Views
{
    public partial class BuscaTimePage : ContentPage
    {
        public BuscaTimePage()
        {
            InitializeComponent();
            BindingContext = App.Locator.BuscaTime;
            Buscar.Clicked += Buscar_Clicked;
			ListView.ItemTapped += async (object sender, ItemTappedEventArgs e) =>
			{
				App.Locator.Atletas.SlugTimeSelecionado = ((Time)e.Item).Slug;
				App.Locator.Atletas.NomeTimeSelecionado = ((Time)e.Item).Nome;

				await App.Locator.Menu.PushPage(MenuType.TIMES, new AtletasPage());
			};
        }

        private void Buscar_Clicked(object sender, EventArgs e)
        {
            App.Locator.BuscaTime.BuscarTime();
        }
    }
}
