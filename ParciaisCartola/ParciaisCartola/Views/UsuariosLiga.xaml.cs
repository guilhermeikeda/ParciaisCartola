using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ParciaisCartola.Views
{
    public partial class UsuariosLiga : ContentPage
    {
        public UsuariosLiga()
        {
            InitializeComponent();
            BindingContext = App.Locator.UsuariosLiga;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            App.Locator.UsuariosLiga.TelaOnAppearing();
        }
    }
}
