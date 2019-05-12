using Listings_Schmidt_Surieux.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Listings_Schmidt_Surieux.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        LoginPageViewModel viewmodel;

        public LoginPage()
        {
            InitializeComponent();
            BindingContext = viewmodel = new LoginPageViewModel(Navigation);
        }
    }
}