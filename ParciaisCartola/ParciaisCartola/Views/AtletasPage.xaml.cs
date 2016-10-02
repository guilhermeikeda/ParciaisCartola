using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ParciaisCartola
{
	public partial class AtletasPage : ContentPage
	{
		public AtletasPage()
		{
			InitializeComponent();
			BindingContext = App.Locator.Atletas;
		}

		protected override void OnAppearing()
		{
			App.Locator.Atletas.TelaOnAppearing();	
		}

	}
}
