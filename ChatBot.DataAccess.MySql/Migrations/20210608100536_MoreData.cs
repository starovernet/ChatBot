using Microsoft.EntityFrameworkCore.Migrations;

namespace ChatBot.DataAccess.MySql.Migrations
{
    public partial class MoreData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ChatResponses",
                columns: new[] { "Id", "Intent", "ResponseMessage" },
                values: new object[,]
                {
                    { 4L, "goodbye", "Bye bye!" },
                    { 5L, "goodbye", "It was nice talking to you, have a great day!" },
                    { 6L, "affirmative", "Great!" },
                    { 7L, "affirmative", "Perfect :)" },
                    { 8L, "negative", "Alright, please let me know if I can help you with anything else!" },
                    { 9L, "thank you", "It was a pleasure to be of help :)" },
                    { 10L, "are you a bot?", "I'm an AI bot, and I'm here to help you with your questions." },
                    { 11L, "i want to speak with a human", "Let me transfer you to the first available agent." },
                    { 12L, "login problems", "Oh no! Please give me your email and I will fix it." },
                    { 13L, "i want to speak with a human", "Let me transfer you to the first available agent." },
                    { 14L, "open or close account", "Please follow these instructions \"LINK\" to open or close an account." }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ChatResponses",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "ChatResponses",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "ChatResponses",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "ChatResponses",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "ChatResponses",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "ChatResponses",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "ChatResponses",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "ChatResponses",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "ChatResponses",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "ChatResponses",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "ChatResponses",
                keyColumn: "Id",
                keyValue: 14L);
        }
    }
}
