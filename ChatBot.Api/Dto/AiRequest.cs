namespace ChatBot.Api.Dto
{
    public record AiRequest
    {
        public string BotId { get; init; }
        public string Message { get; init; }
    }
}