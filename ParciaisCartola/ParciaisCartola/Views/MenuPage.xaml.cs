using Xamarin.Forms;

namespace ParciaisCartola
{
	public partial class MenuPage : ContentPage
	{
		public MenuPage()
		{
			InitializeComponent();
			BindingContext = App.Locator.Menu;
			//ListViewMenu.ItemTapped += ListView_ItemTapped;
		}

		private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
		{
						
		}
	}
}
