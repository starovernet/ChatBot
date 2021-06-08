namespace ChatBot.Api.Common
{
    public record AppSettings
    {
        public string AiClientUrl { get; init; }
        public double PredictionThreshold { get; init; }
        public string AiApiKey { get; init; }
        public string DefaultResponse { get; init; }
    }
}