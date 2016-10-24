using Xamarin.Forms;

namespace ParciaisCartola
{
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
            BindingContext = App.Locator.Menu;
            ListViewMenu.ItemTapped += ListView_ItemTapped;
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (App.Current != null)
            {
                if (e == null) return;
                MenuType itemMenu = ((ItemMenu)e.Item).Tipo;
                             
                ((RootPage)App.Current.MainPage).Detail = App.Locator.Menu.GetCurrentPage(itemMenu);
                ((RootPage)App.Current.MainPage).IsPresented = false;
            }
        }
    }
}