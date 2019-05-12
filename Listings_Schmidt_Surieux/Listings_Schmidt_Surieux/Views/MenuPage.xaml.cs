using Listings_Schmidt_Surieux.Models;
using Listings_Schmidt_Surieux.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Listings_Schmidt_Surieux.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : MasterDetailPage
    {
        MenuPageViewModel viewmodel;
        public MenuPage()
        {
            InitializeComponent();
            BindingContext = viewmodel = new MenuPageViewModel(Navigation);
        }

        private void ListViewMenu_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                HomeMenuItem selected = ((HomeMenuItem)e.Item);
                switch (selected.Id)
                {
                    case MenuItemType.AnnounceList:
                        Detail = new NavigationPage(new ListListingPage());
                        break;
                    case MenuItemType.AnnounceDeposit:
                        Detail = new NavigationPage(new CreateListingPage());
                        break;
                    case MenuItemType.Messages:
                        Detail = new NavigationPage(new ListListingPage());
                        break;

                }

                IsPresented = false;
            }
        }
    }
}