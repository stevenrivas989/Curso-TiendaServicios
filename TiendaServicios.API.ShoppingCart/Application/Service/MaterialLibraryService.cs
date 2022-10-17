using System.Text.Json;
using TiendaServicios.API.ShoppingCart.Application.Service.Remote;

namespace TiendaServicios.API.ShoppingCart.Application.Service
{
    public class MaterialLibraryService : IMaterialLibraryService
    {

        private readonly IHttpClientFactory _httpClient;
        private readonly ILogger<MaterialLibraryService> _logger;

        public MaterialLibraryService(IHttpClientFactory httpClientFactory, ILogger<MaterialLibraryService> logger)
        {
            _httpClient = httpClientFactory;
            _logger = logger;
        }

        public async Task<(bool isSuccess, MaterialLibraryRemote book, string errorMessage)> GetBook(Guid idBook)
        {
            try
            {
                var client = _httpClient.CreateClient("Books");
                var response = await client.GetAsync($"api/materiallibrary/{idBook}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions()
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    var materialLibrary = JsonSerializer.Deserialize<MaterialLibraryRemote>(content, options);
                    return (true, materialLibrary, null);
                }

                return (false, null, response.ReasonPhrase);

            }
            catch (Exception e)
            {
                _logger?.LogError(e.Message);
                return (false, null, e.Message);
            }
        }
    }
}
