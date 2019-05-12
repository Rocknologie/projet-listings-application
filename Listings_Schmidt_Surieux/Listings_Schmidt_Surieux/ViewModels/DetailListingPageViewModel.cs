using System;

using Listings_Schmidt_Surieux.Models;
using Xamarin.Forms;

namespace Listings_Schmidt_Surieux.ViewModels
{
    public class DetailListingPageViewModel : BaseViewModel
    {
        public Listing Item { get; set; }
        public DetailListingPageViewModel(INavigation Navigation, Listing listing) : base(Navigation)
        {
            Title = listing?.Title;
            Item = listing;
        }
    }
}
