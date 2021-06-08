namespace ChatBot.Domain
{
    public record ChatResponse
    {
        public long Id { get; set; }
        public string Intent { get; set; }
        public string ResponseMessage { get; set; }
    }
}