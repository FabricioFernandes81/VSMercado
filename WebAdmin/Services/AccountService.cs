using System.Text.Json;
using WebAdmin.Models;

namespace WebAdmin.Services
{
    public class AccountService : IAccountService
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly JsonSerializerOptions _options;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private const string apiEndpoint = "api/Account/";
        public AccountService(IHttpClientFactory httpClient, IWebHostEnvironment webHostEnvironment)
        {
            _httpClient = httpClient;
            _webHostEnvironment = webHostEnvironment;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }


        public async Task<ResponseToken> Registro(RegistroView registroView)
        {
            ResponseToken responseToken = new ResponseToken();
            var Cliente = _httpClient.CreateClient("ServerClient");

            var form = new MultipartFormDataContent();
            var fileStream = registroView.Imagens.OpenReadStream();
            form.Add(new StreamContent(fileStream), "Imagens", Path.GetFileName(registroView.Imagens.FileName));
            form.Add(new StringContent(registroView.CNPJ.ToString()), "CNPJ");
            form.Add(new StringContent(registroView.Nome.ToString()), "Nome");
            form.Add(new StringContent(registroView.Email.ToString()), "Email");
            form.Add(new StringContent(registroView.Fone.ToString()), "Fone");
            form.Add(new StringContent(registroView.Celular.ToString()), "Celular");

            form.Add(new StringContent(registroView.EstadoId.ToString()), "EstadosId");
            form.Add(new StringContent(registroView.CidadeId.ToString()), "CidadesId");
            form.Add(new StringContent(registroView.Endereco.ToString()), "Endereco");
            form.Add(new StringContent(registroView.Numero.ToString()), "Numero");
            form.Add(new StringContent(registroView.Password.ToString()), "Password");
            form.Add(new StringContent(registroView.ConfirmPassword.ToString()), "ConfirmPassword");

            var result = await Cliente.PostAsync(apiEndpoint + "Register", form);
            if (result.IsSuccessStatusCode) 
            {
                var apiResponse = await result.Content.ReadAsStreamAsync();
                responseToken = await JsonSerializer.DeserializeAsync<ResponseToken>(apiResponse, _options);
             
            }
               return responseToken;
        }
    }
}
