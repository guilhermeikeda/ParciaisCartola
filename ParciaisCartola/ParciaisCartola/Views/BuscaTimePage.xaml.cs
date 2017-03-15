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
            /*
			ListView.ItemTapped += async (object sender, ItemTappedEventArgs e) =>
			{
			};
            */
        }

        private void Buscar_Clicked(object sender, EventArgs e)
        {
            App.Locator.BuscaTime.BuscarTime();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            App.Locator.BuscaTime.TelaOnAppearing();
        }
    }
}
