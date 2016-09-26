using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ParciaisCartola.Custom
{
    public class CartolaNavigationPage : NavigationPage
    {
        public CartolaNavigationPage(Page root): base(root)
        {
            Init();
        }

        private void Init()
        {
            BarTextColor = Color.White;
            BarBackgroundColor = Color.FromHex("#2196F3");
        }
    }
}
