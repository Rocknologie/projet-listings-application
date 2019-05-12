using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Listings_Schmidt_Surieux.Models;
using Listings_Schmidt_Surieux.Views;
using Listings_Schmidt_Surieux.ViewModels;

namespace Listings_Schmidt_Surieux.Views
{
    public partial class ListListingPage : ContentPage
    {
        ListListingPageViewModel viewmodel;
        public ListListingPage()
        {
            InitializeComponent();

            BindingContext = viewmodel = new ListListingPageViewModel(Navigation);
        }

        private async void ItemsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                Listing selected = ((Listing)e.Item);
                await Navigation.PushAsync(new DetailListingPage(selected));
            }
        }
    }
}