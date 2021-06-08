using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChatBot.DataAccess.MySql.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChatResponses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Intent = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true),
                    ResponseMessage = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatResponses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ChatResponses",
                columns: new[] { "Id", "Intent", "ResponseMessage" },
                values: new object[] { 1L, "greeting", "Hi, how can i help you?" });

            migrationBuilder.InsertData(
                table: "ChatResponses",
                columns: new[] { "Id", "Intent", "ResponseMessage" },
                values: new object[] { 2L, "greeting", "Hello there, how can i help you?" });

            migrationBuilder.InsertData(
                table: "ChatResponses",
                columns: new[] { "Id", "Intent", "ResponseMessage" },
                values: new object[] { 3L, "greeting", "Hey there, can i help you?" });

            migrationBuilder.CreateIndex(
                name: "IX_ChatResponses_Intent",
                table: "ChatResponses",
                column: "Intent");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatResponses");
        }
    }
}
