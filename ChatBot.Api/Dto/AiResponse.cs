using System.Collections.Generic;

namespace ChatBot.Api.Dto
{
    public record AiResponse
    {
        public IReadOnlyCollection<Intent> Intents { get; init; }
        public string Error { get; init; }
    }
}