using System.Text.Json;
using WebAdmin.Models;

namespace WebAdmin.Services
{
    public class LocalidadeService : ILocalidadeService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly JsonSerializerOptions _options;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private IEnumerable<Estado> estadosVM;
        private IEnumerable<Cidade> cidadesVM;
        private const string apiEndPoint = "api/localidades/";

        public LocalidadeService(IHttpClientFactory clientFactory, IWebHostEnvironment webHostEnvironment)
        {
            _clientFactory = clientFactory;
            _webHostEnvironment = webHostEnvironment;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<IEnumerable<Estado>> GetEstados()
        {
            var client = _clientFactory.CreateClient("ServerClient");

            using (var response = await client.GetAsync(apiEndPoint + "estados"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResult = await response.Content.ReadAsStreamAsync();
                    estadosVM = await JsonSerializer.DeserializeAsync<IEnumerable<Estado>>(apiResult, _options);
                }
                else
                {
                    return null;
                }

            }
            return estadosVM;
        }
    }
 
}
