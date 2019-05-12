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

namespace Listings_Schmidt_Surieux.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        public LoginPageViewModel(INavigation Navigation) : base(Navigation)
        {
            Title = MyAppRessources.Title_AnnouncesPage;
            LoginCommand = new Command(async () => await ExecuteLoginCommand());
        }

        private string login = Settings.Login;
        public string Login
        {
            get { return login; }
            set { SetProperty(ref login, value); }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }

        private string errorMessage = String.Empty;
        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public Command LoginCommand { get; set; }
        private async Task ExecuteLoginCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                //
                if (!String.IsNullOrWhiteSpace(Login)
                    && !String.IsNullOrWhiteSpace(Password))
                {
                    Settings.Login = Login;
                    Settings.Pwd = Password;
                    Settings.TokenAPI = String.Empty;

                    ListingsWebService client = new ListingsWebService();
                    var result = await client.ApiAuthenticateUser();
                    if (result)
                    {
                        ErrorMessage = "";
                        ((App)Application.Current).DisplayHome();
                    }
                    else
                    {
                        ErrorMessage = MyAppRessources.LoginPage_LblError_Unknown;
                    }
                }
                else
                {
                    ErrorMessage = MyAppRessources.LoginPage_LblError_Uncomplete;
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