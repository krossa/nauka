using WebAppPoligon.Models;

namespace WebAppPoligon.Services
{
    public class PoligonClient
    {
        private readonly HttpClient _client;

        public PoligonClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> GetDataAsync()
        {
            var response = await _client.GetAsync("dane.txt");

            var result = await response.Content.ReadAsStringAsync();

            return result;
        }

        public async Task<string> VerifyDataAsync(VerifyRequest request)
        {            
           // var content = JsonContent.Create(request);
            //content.Headers.Add("Content-Type", "application/json");
            //var response = await _client.SendAsync("verify", content);

            var response = await _client.PostAsJsonAsync("verify", request);

            var parsedResponse = await response.Content.ReadAsStringAsync();

            return parsedResponse;
        }

    }
}
