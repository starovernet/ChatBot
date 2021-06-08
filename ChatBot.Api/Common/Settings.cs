using System.Text.Json;

namespace ChatBot.Api.Common
{
    internal class Settings
    {
        public static JsonSerializerOptions JsonSerialization { get; } =
            new()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true
            };
    }
}