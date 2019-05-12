using Listings_Schmidt_Surieux.Models;
using Listings_Schmidt_Surieux.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Listings_Schmidt_Surieux.Services
{
    public class ListingsWebService
    {
        // Méthode d'authentification
        public async Task<bool> ApiAuthenticateUser()
        {
            try
            {
                HttpClient clientTest = new HttpClient();
                Dictionary<string, string> keys = new Dictionary<string, string>();
                keys.Add("email", Settings.Login);
                keys.Add("password", Settings.Pwd);
                FormUrlEncodedContent content = new FormUrlEncodedContent(keys);
                var response = await clientTest.PostAsync(@"https://localhost:3000/auth", content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //TODO On récupère le token retourné, et on l'enregistre
                    var responsedata = await response.Content.ReadAsStringAsync();
                    var responseformatted = JsonConvert.DeserializeObject<API_Response_Authenticate>(responsedata);
                    Settings.TokenAPI = responseformatted.Token;
                    return true;
                }
                else
                {
                    Settings.TokenAPI = String.Empty;
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Settings.TokenAPI = String.Empty;
                return false;
            }
        }

        // Méthode qui récupères toutes les annonces
        public async Task<List<Listing>> ApiGetListings()
        {
            List<Listing> resultats = new List<Listing>();
            if (String.IsNullOrWhiteSpace(Settings.TokenAPI))
            {
                await ApiAuthenticateUser();
            }

            try
            {
                HttpClient clientTest = new HttpClient();
                clientTest.DefaultRequestHeaders.Add("token", Settings.TokenAPI);
                var response = await clientTest.GetAsync(@"https://localhost:3000/listings");
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //OK, on désérialise et retourne le résultat
                    var responsedata = await response.Content.ReadAsStringAsync();
                    var responseformatted = JsonConvert.DeserializeObject<API_Response_Listings>(responsedata);
                    return responseformatted.Listings;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    //RéAuthentifie
                    if (await ApiAuthenticateUser())
                    {
                        //On rejoue la requête après authentification correcte
                        return await ApiGetListings();
                    }
                    else
                    {
                        //Réauthentification NOK... dialog ?
                    }
                }
                //else
                //{
                //    //autre erreur
                //}

            }
            catch (Exception ex)
            {

            }
            return resultats;
        }
        
        // Méthode qui récupère une seul annonce
        public async Task<Listing> ApiGetListing(string id)
        {
            Listing resultat = new Listing();
            if (String.IsNullOrWhiteSpace(Settings.TokenAPI))
            {
                await ApiAuthenticateUser();
            }

            try
            {
                HttpClient clientTest = new HttpClient();
                clientTest.DefaultRequestHeaders.Add("token", Settings.TokenAPI);
                var response = await clientTest.GetAsync(@"http://localhost:3000/listings/" + id);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //OK, on désérialise et retourne le résultat
                    var responsedata = await response.Content.ReadAsStringAsync();
                    var responseformatted = JsonConvert.DeserializeObject<API_Response_Listings>(responsedata);
                    if (responseformatted.Listings.Count > 0)
                        return responseformatted.Listings[0];
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    //RéAuthentifie
                    if (await ApiAuthenticateUser())
                    {
                        //On rejoue la requête après authentification correcte
                        return await ApiGetListing(id);
                    }
                    else
                    {
                        //Réauthentification NOK... dialog ?
                    }
                }
                //else
                //{
                //    //autre erreur
                //}

            }
            catch (Exception ex)
            {

            }
            return resultat;
        }

        // Méthode qui créer une annonce
        public async Task<bool> ApiCreateListing(Listing listing)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("token", Settings.TokenAPI);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var contentstring = "{\"listing\":" + JsonConvert.SerializeObject(listing) + "}";
                StringContent content = new StringContent(contentstring, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(@"https://localhost:3000/listings", content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responsedata = await response.Content.ReadAsStringAsync();
                    var responseformatted = JsonConvert.DeserializeObject<API_Response_Listings>(responsedata);
                    if (responseformatted.Success == "true"
                        && responseformatted.Listings != null
                        && responseformatted.Listings.Count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        //API_Response_Category
        public async Task<List<Category>> ApiGetCategories()
        {
            List<Category> resultats = new List<Category>();
            if (String.IsNullOrWhiteSpace(Settings.TokenAPI))
            {
                await ApiAuthenticateUser();
            }

            try
            {
                HttpClient clientTest = new HttpClient();
                clientTest.DefaultRequestHeaders.Add("token", Settings.TokenAPI);
                var response = await clientTest.GetAsync(@"https://localhost:3000/categories");
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //OK, on désérialise et retourne le résultat
                    var responsedata = await response.Content.ReadAsStringAsync();
                    var responseformatted = JsonConvert.DeserializeObject<API_Response_Category>(responsedata);
                    return responseformatted.Categories;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    //RéAuthentifie
                    if (await ApiAuthenticateUser())
                    {
                        //On rejoue la requête après authentification correcte
                        return await ApiGetCategories();
                    }
                    else
                    {
                        //Réauthentification NOK... dialog ?
                    }
                }
                //else
                //{
                //    //autre erreur
                //}

            }
            catch (Exception ex)
            {

            }
            return resultats;
        }

        public async Task<User> ApiGetMyAccount()
        {
            User resultat = new User();
            if (String.IsNullOrWhiteSpace(Settings.TokenAPI))
            {
                await ApiAuthenticateUser();
            }

            try
            {
                HttpClient clientTest = new HttpClient();
                clientTest.DefaultRequestHeaders.Add("token", Settings.TokenAPI);
                var response = await clientTest.GetAsync(@"https://best-team-listing.herokuapp.com/api/v1/account");
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //OK, on désérialise et retourne le résultat
                    var responsedata = await response.Content.ReadAsStringAsync();
                    var responseformatted = JsonConvert.DeserializeObject<API_Response_User>(responsedata);
                    return responseformatted.User;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    //RéAuthentifie
                    if (await ApiAuthenticateUser())
                    {
                        //On rejoue la requête après authentification correcte
                        return await ApiGetMyAccount();
                    }
                    else
                    {
                        //Réauthentification NOK... dialog ?
                    }
                }
                //else
                //{
                //    //autre erreur
                //}

            }
            catch (Exception ex)
            {

            }
            return resultat;
        }
    }
}
