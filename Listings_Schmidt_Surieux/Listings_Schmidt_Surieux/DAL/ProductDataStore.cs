using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Listings_Schmidt_Surieux.DAL;
using Listings_Schmidt_Surieux.Interfaces;
using Listings_Schmidt_Surieux.Models;
using Listings_Schmidt_Surieux.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(ProductDataStore))]
namespace Listings_Schmidt_Surieux.DAL
{
    public class ProductDataStore : IDataStore<Listing>
    {

        public ProductDataStore()
        {

        }

        public async Task<bool> AddItemAsync(Listing item)
        {
            //Need API
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Listing item)
        {
            //Need API !!!

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            //Need API !!!

            return await Task.FromResult(true);
        }

        public async Task<Listing> GetItemAsync(string id)
        {
            ListingsWebService WSclient = new ListingsWebService();
            return await WSclient.ApiGetListing(id);
        }

        public async Task<List<Listing>> GetItemsAsync(bool forceRefresh = false)
        {
            ListingsWebService WSclient = new ListingsWebService();
            return await WSclient.ApiGetListings();
        }
    }
}