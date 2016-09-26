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
    public partial class Ligas : ContentPage
    {
        public Ligas()
        {
            InitializeComponent();
            BindingContext = App.Locator.Ligas;
            Buscar.Clicked += Buscar_Clicked;
            ListView.ItemTapped += ListView_ItemTapped;
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Liga ligaSelecionada = (Liga)e.Item;
            App.Locator.UsuariosLiga.ligaAtual = ligaSelecionada;
            ((CartolaNavigationPage)App.Current.MainPage).PushAsync(new UsuariosLiga());
        }

        private void Buscar_Clicked(object sender, EventArgs e)
        {
            App.Locator.Ligas.BuscarLiga();
        }
    }
}
