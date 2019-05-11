using System.Collections.Generic;
using Listings_Schmidt_Surieux.Models;
using Listings_Schmidt_Surieux.DAL;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Listings_Schmidt_Surieux.ViewModels
{
    public class ListListingPageViewModel : BaseViewModel
    {
        public ObservableCollection<Listing> Listings { get; set; }

        public ListListingPageViewModel()
        {
            Titre = "Liste des articles";
            Listings = new ObservableCollection<Listing>();

            RefreshCountryCommand = new Command(async () => await ExecuteRefreshListingCommand());
        }

        #region Bindable Properties

        private List<Listing> listListing;
        public List<Listing> ListListing
        {
            get
            {
                return listListing;
            }
            set
            {
                listListing = value;
                OnPropertyChanged("ListListing");
            }
        }
        

        private Listing selectedListing;
        public Listing SelectedListing
        {
            get
            {
                return selectedListing;
            }
            set
            {
                selectedListing = value;
                OnPropertyChanged();
            }
        }
        #endregion


        #region Bindable Commands

        public Command RefreshCountryCommand { get; set; }

        // Methode asyncrone pour rafraichir la liste des articles
        private async Task ExecuteRefreshListingCommand()
        {
            IsBusy = true;
            //si on est en ligne
            await GetListListings();

            IsBusy = false;
        }

        #endregion
        // Get tous les articles
        #region Methods 
        private async Task GetListListings()
        {
            ListingsWebService cws = new ListingsWebService();
            List<Listing> listListings = await cws.GetListingFromAPIAsync();
            foreach (Listing listing in listListings)
            {
                this.Listings.Add(listing);
            }
        }
        #endregion
    }
}