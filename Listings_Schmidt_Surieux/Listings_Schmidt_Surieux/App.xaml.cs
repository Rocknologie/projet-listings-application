using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Listings_Schmidt_Surieux.Views;

namespace Listings_Schmidt_Surieux
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ListListingPage()); ;
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
