namespace ChatBot.Api.Dto
{
    public record Intent
    {
        public string Name { get; set; }
        public double Confidence { get; set; }
    }
}