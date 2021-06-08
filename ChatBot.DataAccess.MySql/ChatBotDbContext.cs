using System.Collections.Generic;
using ChatBot.DataAccess.MySql.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChatBot.DataAccess.MySql
{
    public class ChatBotDbContext : DbContext
    {
        public ChatBotDbContext(DbContextOptions<ChatBotDbContext> optionsBuilderOptions) : base(optionsBuilderOptions)
        {
        }

        public DbSet<ChatResponse> ChatResponses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChatResponse>().HasKey(x => x.Id);
            modelBuilder.Entity<ChatResponse>().HasData(new List<ChatResponse>
            {
                new() {Id = 1, ResponseMessage = "Hi, how can i help you?", Intent = "greeting"},
                new() {Id = 2, ResponseMessage = "Hello there, how can i help you?", Intent = "greeting"},
                new() {Id = 3, ResponseMessage = "Hey there, can i help you?", Intent = "greeting"},
                new() {Id = 4, ResponseMessage = "Bye bye!", Intent = "goodbye"},
                new() {Id = 5, ResponseMessage = "It was nice talking to you, have a great day!", Intent = "goodbye"},
                new() {Id = 6, ResponseMessage = "Great!", Intent = "affirmative"},
                new() {Id = 7, ResponseMessage = "Perfect :)", Intent = "affirmative"},
                new() {Id = 8, ResponseMessage = "Alright, please let me know if I can help you with anything else!", Intent = "negative"},
                new() {Id = 9, ResponseMessage = "It was a pleasure to be of help :)", Intent = "thank you"},
                new() {Id = 10, ResponseMessage = "I'm an AI bot, and I'm here to help you with your questions.", Intent = "are you a bot?"},
                new() {Id = 11, ResponseMessage = "Let me transfer you to the first available agent.", Intent = "i want to speak with a human"},
                new() {Id = 12, ResponseMessage = "Oh no! Please give me your email and I will fix it.", Intent = "login problems"},
                new() {Id = 13, ResponseMessage = "Let me transfer you to the first available agent.", Intent = "i want to speak with a human"},
                new() {Id = 14, ResponseMessage = "Please follow these instructions \"LINK\" to open or close an account.", Intent = "open or close account"},
            });
            modelBuilder.Entity<ChatResponse>().HasIndex(x => x.Intent);
        }
    }
}