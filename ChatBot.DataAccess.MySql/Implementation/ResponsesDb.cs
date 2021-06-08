using System.Linq;
using System.Threading.Tasks;
using ChatBot.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace ChatBot.DataAccess.MySql.Implementation
{
    internal class ResponsesDb : IResponsesDb
    {
        //To simplify i use memory cache, but it may be redis for scalability, or can be both.
        //Cache invalidation have to be managed by service, which update db, it may use pub/sub to notify services to invalidate cache
        private readonly IMemoryCache _cache;
        private readonly ChatBotDbContext _dbContext;

        public ResponsesDb(IMemoryCache cache, ChatBotDbContext dbContext)
        {
            _cache = cache;
            _dbContext = dbContext;
        }

        public async ValueTask<string[]> GetResponsesForIntent(string intent)
        {
            if (_cache.TryGetValue(intent, out string[] responses))
                return responses;
            string normalized = intent.ToLowerInvariant();
            responses = await _dbContext.ChatResponses
                .Where(x => x.Intent.Equals(normalized))
                .Select(x => x.ResponseMessage)
                .ToArrayAsync();
            _cache.Set(intent, responses);
            return responses;
        }
    }
}