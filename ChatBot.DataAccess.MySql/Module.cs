using AutoMapper;
using ChatBot.DataAccess.MySql.Implementation;
using ChatBot.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChatBot.DataAccess.MySql
{
    public static class Module
    {
        public static void InitializeMySql(IServiceCollection services, IConfiguration configuration)
        {
            //I used MySql, it's simple and free database engine, can easily handle millions of records.
            services.AddDbContextPool<ChatBotDbContext>(options =>
                options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
                    ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection"))));
            services.AddTransient<IResponsesDb, ResponsesDb>();
            services.AddTransient<IResponsesAdminDb, ResponsesAdminDb>();
            services.AddAutoMapper(typeof(MySqlMapperProfile));
        }
    }

    public class MySqlMapperProfile : Profile
    {
        public MySqlMapperProfile()
        {
            CreateMap<Entities.ChatResponse, ChatResponse>();
        }
    }
}