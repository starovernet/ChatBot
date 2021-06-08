using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ChatBot.DataAccess.MySql
{
    public class ChatBotDbContext : DbContext
    {
        public DbSet<ChatResponse> ChatResponses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChatResponse>().HasKey(x => x.Id);
            modelBuilder.Entity<ChatResponse>().HasIndex(x => x.Intent);
            modelBuilder.Entity<ChatResponse>().HasData(new List<ChatResponse>
            {
                new() {ResponseMessage = "Hi, how can i help you?", Intent = "greeting"},
                new() {ResponseMessage = "Hello there, how can i help you?", Intent = "greeting"},
                new() {ResponseMessage = "Hey there, can i help you?", Intent = "greeting"}
            });
        }
    }
}