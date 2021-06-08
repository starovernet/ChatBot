namespace ChatBot.DataAccess.MySql
{
    public class ChatResponse
    {
        public long Id { get; set; }
        public string Intent { get; set; }
        public string ResponseMessage { get; set; }
    }
}