
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParciaisCartola.Custom;
using ParciaisCartola.Models;
using Xamarin.Forms;

namespace ParciaisCartola.Views
{
    public partial class TimesPage : ContentPage
    {
        public TimesPage()
        {
            InitializeComponent();
            BindingContext = App.Locator.Times;
            ListView.ItemTapped += async (object sender, ItemTappedEventArgs e) =>
            {
                Time timeSelecionado = (Time)e.Item;
                App.Locator.Atletas.SlugTimeSelecionado = timeSelecionado.Slug;
                App.Locator.Atletas.NomeTimeSelecionado = timeSelecionado.Nome;
                await App.Locator.Menu.PushPage(MenuType.LIGAS, new AtletasPage());
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            App.Locator.Times.TelaOnAppearing();
        }
    }
}
