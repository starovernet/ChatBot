namespace ChatBot.Api.Common
{
    public record AppSettings
    {
        public string AiClientUrl { get; set; }
        public double PredictionThreshold { get; set; }
        public string AiApiKey { get; set; }
        public string DefaultResponse { get; set; }
    }
}