using System;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using Listings_Schmidt_Surieux.Models;
using Listings_Schmidt_Surieux.Services;

namespace Listings_Schmidt_Surieux.ViewModels
{
    public class CreateListingPageViewModel : BaseViewModel
    {
        public CreateListingPageViewModel(INavigation Navigation) : base(Navigation)
        {
            Title = "Créer une annonce";
            SubmitCommand = new Command(async () => await ExecuteSubmitCommand());

        }

        private string titre;
        public string Titre
        {
            get { return titre; }
            set { SetProperty(ref titre, value); }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }

        private string prix;
        public string Prix
        {
            get { return prix; }
            set { SetProperty(ref prix, value); }
        }


        private string errorMessage = String.Empty;
        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public Command SubmitCommand { get; set; }
        private async Task ExecuteSubmitCommand()
        {
            IsBusy = true;

            try
            {
                double price = 0;
                if (!String.IsNullOrWhiteSpace(Titre)
                    && !String.IsNullOrWhiteSpace(Description)
                    && !String.IsNullOrWhiteSpace(Prix)
                    && Double.TryParse(Prix, out price))
                {
                    Listing listing = new Listing();
                    listing.Title = Titre;
                    listing.Description = Description;
                    listing.Price = price;
                    listing.Category_ID = "1";

                    ListingsWebService client = new ListingsWebService();
                    var result = await client.ApiCreateListing(listing);
                    if (result)
                    {
                        //Post OK, on revient à l'écran précédent
                        ErrorMessage = "";
                        await NavigationService.PopAsync();
                    }
                    else
                    {
                        ErrorMessage = "Erreur, veuillez ressayer !";
                    }
                }
                else
                {
                    ErrorMessage = "Les renseignement ne sont pas corrects, veuillez vérifier votre saisie.";
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}