using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ChatBot.DataAccess.MySql
{
    /// <summary>
    /// This class used for managing db migrations
    /// </summary>
    public class DesignTimeContextFactory : IDesignTimeDbContextFactory<ChatBotDbContext>
    {
        public ChatBotDbContext CreateDbContext(string[] args)
        {
            var connString = "Server=localhost;Port=3306;Database=chatbot.db;Uid=admin;Pwd=Qwerty2412;ConvertZeroDateTime=True";
            var optionsBuilder = new DbContextOptionsBuilder<ChatBotDbContext>();
            optionsBuilder.UseMySql(connString, ServerVersion.AutoDetect(connString),
                builder => builder.MigrationsAssembly("ChatBot.DataAccess.MySql"));
            return new ChatBotDbContext(optionsBuilder.Options);
        }
    }
}