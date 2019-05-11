using Listings_Schmidt_Surieux.Models;
using Listings_Schmidt_Surieux.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Listings_Schmidt_Surieux.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailListingPage : ContentPage
    {
        public DetailListingPage(Listing listing)
        {
            InitializeComponent();
            BindingContext = new DetailListingPageViewModel(listing);
        }
    }
}