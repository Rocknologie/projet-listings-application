using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using Listings_Schmidt_Surieux.Models;
using Listings_Schmidt_Surieux.Views;
using Listings_Schmidt_Surieux.Ressources;
using Listings_Schmidt_Surieux.Utils;
using Listings_Schmidt_Surieux.Services;
using System.Threading;

namespace Listings_Schmidt_Surieux.ViewModels
{
    public class ListListingPageViewModel : BaseViewModel
    {
        public ListListingPageViewModel(INavigation Navigation) : base(Navigation)
        {
            Title = MyAppRessources.Title_AnnouncesPage;
            Items = new ObservableCollection<Listing>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            AddItemCommand = new Command(async () => await ExecuteAddItemCommand());
            //Au démarrage, on charge les items
            LoadItemsCommand.Execute(null);
        }
        public ObservableCollection<Listing> Items { get; set; }

        public Command LoadItemsCommand { get; set; }
        private async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            try
            {
                Items.Clear();
                var items = await ProductDataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
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

        public Command AddItemCommand { get; set; }
        private async Task ExecuteAddItemCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                await NavigationService.PushAsync(new CreateListingPage(), true);
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