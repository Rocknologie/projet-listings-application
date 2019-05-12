using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Listings_Schmidt_Surieux.Views;
using Listings_Schmidt_Surieux.Interfaces;
using Listings_Schmidt_Surieux.ViewModels;
using Listings_Schmidt_Surieux.Services;
using Listings_Schmidt_Surieux.Models;
using System.Threading.Tasks;
using Listings_Schmidt_Surieux.Utils;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Listings_Schmidt_Surieux
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            DependencyService.Register<IDataStore<Listing>>();
            var currentSmartphoneLanguage = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();

            if (Settings.IsUserConnected)
            {
                DisplayHome();
            }
            else
            {
                DisplayLogin();
            }
        }

        public void DisplayLogin()
        {
            //Affectation Mainpage
            MainPage = new LoginPage();
        }

        public void DisplayHome()
        {
            //Affectation Mainpage
            MainPage = new MenuPage();
        }
    }
}
