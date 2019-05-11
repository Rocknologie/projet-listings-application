using Newtonsoft.Json;
using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using Listings_Schmidt_Surieux.Models;
using System.Threading.Tasks;
using System.Net.Http;
using Xamarin.Essentials;
using Listings_Schmidt_Surieux.Utils;

namespace Listings_Schmidt_Surieux.DAL
{
    public class ListingsWebService 
    {
        // Récupérer l'URL du fichier JSON (API) 
        string URL = "https://restcountries.eu/rest/v2/all";

        // Vérifier si la connection internet fonctionne 
        public async Task<List<Listing>> GetListingFromAPIAsync()
        {
            List<Listing> resultat = new List<Listing>();
            try
            {
                var current = Connectivity.NetworkAccess;
                if (current == NetworkAccess.Internet)
                {
                    HttpClient client = new HttpClient();
                    var response = await client.GetAsync(URL);
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonbrut = await response.Content.ReadAsStringAsync();
                        resultat = JsonConvert.DeserializeObject<List<Listing>>(jsonbrut);
                    }
                }
                else
                {
                    UserDialogs.Instance.Toast(new ToastConfig("")
                    {
                        BackgroundColor = System.Drawing.Color.Red,
                        Message = "Veuillez vérifier votre connexion",
                        Duration = new TimeSpan(0, 0, 5)
                    });
                }
            }
            catch (Exception ex)
            {
                Insights.ReportError(ex, null);
            }
            return resultat;
        }
    }
}