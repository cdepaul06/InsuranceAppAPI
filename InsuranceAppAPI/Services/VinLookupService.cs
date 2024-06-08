using System.Net.Http.Headers;

namespace InsuranceAppAPI.Services
{
    public class VinLookupService
    {
        private readonly HttpClient client;

        public VinLookupService(HttpClient httpClient)
        {
            client = httpClient;
            client.BaseAddress = new Uri("https://vpic.nhtsa.dot.gov/api/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> VinLookup(string vin, int year)
        {
            string url = $"vehicles/DecodeVinValues/{vin}?format=json&modelyear={year}";

            try
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return result;
                }
                else
                {
                    return $"Error: {response.StatusCode}";
                }
            }
            catch (Exception e)
            {
                return $"Exception: {e.Message}";
            }
        }
    }
}
