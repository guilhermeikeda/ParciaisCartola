using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using ParciaisCartola.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ParciaisCartola.Services
{
    public class AzureClient
    {
        private IMobileServiceClient _client;
        private IMobileServiceSyncTable<Time> _table;
        private const string serviceURI = "http://parciaiscartola.azurewebsites.net/";
        private const string dbPath = "parciaisCartolaDb";

        public AzureClient()
        {
            var store = new MobileServiceSQLiteStore(dbPath);
            store.DefineTable<Time>();

            _client = new MobileServiceClient(serviceURI);
            _client.SyncContext.InitializeAsync(store);

            _table = _client.GetSyncTable<Time>();
        }

        public async Task<IEnumerable<Time>> GetTimes()
        {
            try
            {
                if (Plugin.Connectivity.CrossConnectivity.Current.IsConnected)
                {
                    await SyncAsync();
                }
                return await _table.ToEnumerableAsync();
            }catch(Exception e)
            {
                return new List<Time>();
            }
        }
        public async Task SyncAsync()
        {
            ReadOnlyCollection<MobileServiceTableOperationError> syncError = null;
            try
            {
                await _client.SyncContext.PushAsync();
                await _table.PullAsync("todosTimes", _table.CreateQuery());
            }catch(MobileServicePushFailedException ex)
            {
                if(ex.PushResult != null)
                {
                    syncError = ex.PushResult.Errors;
                }
            }
        }

        public async Task CleanData()
        {
            await _table.PurgeAsync("todosTimes", _table.CreateQuery(), new System.Threading.CancellationToken());
        }
    }
}
