using System.Text.Json;
using mnpd_dispatch_viewer.Models;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace mnpd_dispatch_viewer.Services
{
    public class RestService
    {
        HttpClient Client;
        JsonSerializerOptions SerializerOptions;

        public List<DispatchItem> Items { get; set; }

        public RestService()
        {
            Client = new HttpClient();
            SerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<List<DispatchItem>> RefreshDataAsync()
        {
            Items = new List<DispatchItem>();

            Uri uri = new Uri(string.Format(Constants.MNPDJsonLink, string.Empty));

            try
            {
                HttpResponseMessage response = await Client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string body = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<List<DispatchItem>>(body);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return Items;
        }
    }
}
