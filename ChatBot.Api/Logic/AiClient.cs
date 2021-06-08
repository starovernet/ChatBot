using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ChatBot.Api.Common;
using ChatBot.Api.Dto;

namespace ChatBot.Api.Logic
{
    public interface IAiClient
    {
        Task<AiResponse> GetAiPredictions(AiRequest message);
    }
    internal class AiClient : IAiClient
    {
        private readonly HttpClient _httpClient;

        public AiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AiResponse> GetAiPredictions(AiRequest request)
        {
            var content =
                new StringContent(JsonSerializer.Serialize(request, Settings.JsonSerialization), Encoding.UTF8,
                    "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(@"intents", content);
            if (response.IsSuccessStatusCode)
                return JsonSerializer.Deserialize<AiResponse>(await response.Content.ReadAsStringAsync(), Settings.JsonSerialization);
            return response.StatusCode switch
            {
                HttpStatusCode.NotFound => new AiResponse {Error = Constants.BotNotFound},
                _ => new AiResponse {Error = Constants.GenericError}
            };
        }
    }
}