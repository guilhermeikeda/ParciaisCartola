using ParciaisCartola.Custom;
using ParciaisCartola.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ParciaisCartola
{
	public partial class RootPage : MasterDetailPage
	{
		public RootPage()
		{
			InitializeComponent();
            Detail = App.Locator.Menu.GetCurrentPage(MenuType.LIGAS);
            Master = new MenuPage();
		}
	}
}
