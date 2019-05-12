
using Listings_Schmidt_Surieux.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Listings_Schmidt_Surieux.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateListingPage : ContentPage
    {
        CreateListingPageViewModel viewmodel;
        public CreateListingPage()
        {
            InitializeComponent();
            BindingContext = viewmodel = new CreateListingPageViewModel(Navigation);
        }
    }
}