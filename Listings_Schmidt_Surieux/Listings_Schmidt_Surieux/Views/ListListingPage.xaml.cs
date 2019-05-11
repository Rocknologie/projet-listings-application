using Listings_Schmidt_Surieux.ViewModels;
using Listings_Schmidt_Surieux.Models;
using Listings_Schmidt_Surieux.Utils;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Listings_Schmidt_Surieux.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListListingPage : ContentPage
    {
        private ListListingPageViewModel viewModel;
        public ListListingPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ListListingPageViewModel();

            MyListview.ItemTapped += MyListview_ItemTapped;
        }

        //  Action lorsqu'un pays est séléctionné
        private void MyListview_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            try
            {
                ((ListListingPageViewModel)BindingContext).SelectedListing = null;
                Listing selectedListing = (Listing)e.Item;
                Navigation.PushAsync(new DetailListingPage(selectedListing), true);
            }
            catch (Exception ex)
            {
                Insights.ReportError(ex, null);
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.RefreshCountryCommand.Execute(null);
        }
    }
}