using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Listings_Schmidt_Surieux.Models;
using Listings_Schmidt_Surieux.ViewModels;

namespace Listings_Schmidt_Surieux.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailListingPage : ContentPage
    {
        DetailListingPageViewModel viewmodel;
        public DetailListingPage(Listing item)
        {
            InitializeComponent();
            BindingContext = viewmodel = new DetailListingPageViewModel(Navigation, item);
        }
    }
}