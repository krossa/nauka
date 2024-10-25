using WebAppPoligon.Models;
using WebAppPoligon.Services.Interfaces;

namespace WebAppPoligon.Services
{
    public class PoligonService : IPoligonService
    {
        private readonly PoligonClient _client;

        public PoligonService(PoligonClient client)
        {
            _client = client;
        }

        public async Task<string> Process()
        {
            var data = await _client.GetDataAsync();

            var request = new VerifyRequest
            {
                task = "POLIGON",
                answer = ParseData(data).ToList()
            };

            return await _client.VerifyDataAsync(request);
        }

        private IEnumerable<string> ParseData(string data) =>
            data.Split('\n')
                .Where(d => !string.IsNullOrEmpty(d));

    }
}
