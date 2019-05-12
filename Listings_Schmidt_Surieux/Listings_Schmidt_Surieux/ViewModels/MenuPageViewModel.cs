using Listings_Schmidt_Surieux.Models;
using Listings_Schmidt_Surieux.Ressources;
using Listings_Schmidt_Surieux.Services;
using Listings_Schmidt_Surieux.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Listings_Schmidt_Surieux.ViewModels
{
    public class MenuPageViewModel : BaseViewModel
    {
        public MenuPageViewModel(INavigation Navigation) : base(Navigation)
        {
            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.AnnounceList, Title=MyAppRessources.ItemMenu1, Icon="IconMenu1", IsEnable=true},
                new HomeMenuItem {Id = MenuItemType.AnnounceDeposit, Title=MyAppRessources.ItemMenu2, Icon="IconMenu2", IsEnable=true },
                new HomeMenuItem {Id = MenuItemType.Messages, Title=MyAppRessources.ItemMenu3, Icon="IconMenu3", IsEnable=true}
            };
            LogoutCommand = new Command(ExecuteLogoutCommand);
            if (Settings.IsUserConnected)
            {
                Task.Factory.StartNew(async () =>
                {
                    ListingsWebService client = new ListingsWebService();
                    var user = await client.ApiGetMyAccount();
                    UserName = user.Email;
                    Settings.UserID = user.Id;
                    UserImage = ImageSource.FromUri(new Uri("http://www.sefairepayer.com/images/profils-debiteur/profil-irreductible.png"));
                });
            }
        }

        private List<HomeMenuItem> menuItems;
        public List<HomeMenuItem> MenuItems
        {
            get { return menuItems; }
            set { SetProperty(ref menuItems, value); }
        }

        private string userName;
        public string UserName
        {
            get { return userName; }
            set { SetProperty(ref userName, value); }
        }


        private ImageSource userImage;
        public ImageSource UserImage
        {
            get { return userImage; }
            set { SetProperty(ref userImage, value); }
        }


        #region LogoutCommand

        public Command LogoutCommand { get; set; }

        private void ExecuteLogoutCommand()
        {
            Settings.Login = String.Empty;
            Settings.Pwd = String.Empty;
            Settings.TokenAPI = String.Empty;
            ((App)Application.Current).DisplayLogin();
        }

        #endregion

    }
}
