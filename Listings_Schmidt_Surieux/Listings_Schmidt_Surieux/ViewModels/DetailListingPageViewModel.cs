using Listings_Schmidt_Surieux.Models;

namespace Listings_Schmidt_Surieux.ViewModels
{
    public class DetailListingPageViewModel : BaseViewModel
    {
        // Constructeur
        public DetailListingPageViewModel(Listing listing)
        {
            CurrentListing = listing;
            Titre = "Détail de l'article";
        }

        #region BindableProperties

        private Listing currentListing;
        public Listing CurrentListing
        {
            get { return currentListing; }
            set
            {
                currentListing = value;
                OnPropertyChanged();
            }
        }

        #endregion        

    }
}
