using ParciaisCartola.Custom;
using ParciaisCartola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ParciaisCartola.Views
{
    public partial class LigasPage : ContentPage
    {
        public LigasPage()
        {
            InitializeComponent();
            BindingContext = App.Locator.Ligas;
            Buscar.Clicked += Buscar_Clicked;
            ListView.ItemTapped += async (object sender, ItemTappedEventArgs e) => {
                Liga ligaSelecionada = (Liga)e.Item;
                App.Locator.Times.ligaAtual = ligaSelecionada;
                await App.Locator.Menu.PushPage(MenuType.LIGAS, new TimesPage());
            };
        }

        private void Buscar_Clicked(object sender, EventArgs e)
        {
            App.Locator.Ligas.BuscarLiga();
        }
    }
}
