using Xamarin.Forms;
using ParciaisCartola.ViewModel;
using ParciaisCartola.Views;
using ParciaisCartola.Custom;

namespace ParciaisCartola
{
    public partial class App : Application
    {
        private static ViewModelLocator _locator;

        public static ViewModelLocator Locator
        {
            get
            {
                return _locator;
            }
        }

        public App()
        {
            
            _locator = new ViewModelLocator();
            MainPage = new CartolaNavigationPage(new Ligas());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

