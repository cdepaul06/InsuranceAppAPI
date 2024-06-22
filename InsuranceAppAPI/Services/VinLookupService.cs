using System.Net.Http.Headers;

namespace InsuranceAppAPI.Services
{
    public class VinLookupService
    {
        private readonly HttpClient _client;

        #region Initialize
        public VinLookupService(HttpClient httpClient)
        {
            _client = httpClient;
            _client.BaseAddress = new Uri("https://vpic.nhtsa.dot.gov/api/");
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        #endregion

        #region VIN Lookup
        public async Task<string> VinLookup(string vin, int year)
        {
            string url = $"vehicles/DecodeVinValues/{vin}?format=json&modelyear={year}";

            try
            {
                var response = await _client.GetAsync(url);
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
        #endregion
    }
}
