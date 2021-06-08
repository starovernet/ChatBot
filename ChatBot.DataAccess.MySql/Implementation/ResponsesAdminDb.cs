using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ChatBot.Domain;
using Microsoft.EntityFrameworkCore;

namespace ChatBot.DataAccess.MySql.Implementation
{
    internal class ResponsesAdminDb : IResponsesAdminDb
    {
        private readonly ChatBotDbContext _dbContext;
        private readonly IMapper _mapper;

        public ResponsesAdminDb(ChatBotDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<long> AddResponsesForIntent(string intent, string response)
        {
            var entity = new Entities.ChatResponse {Intent = intent.ToLower(), ResponseMessage = response};
            _dbContext.ChatResponses.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> DeleteResponse(long id)
        {
            Entities.ChatResponse entry = await _dbContext.ChatResponses.FindAsync(id);
            if (entry == null)
                return false;
            _dbContext.Entry(entry).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<ChatResponse>> GetResponses(int start, int pageSize, string intent = null)
        {
            IQueryable<Entities.ChatResponse> query = _dbContext.ChatResponses.AsQueryable();
            if (!string.IsNullOrWhiteSpace(intent))
                query = query.Where(x => x.Intent == intent.ToLower());
            if (start > 0)
                query = query.Skip(start);
            query = query.Take(pageSize)
                .OrderBy(x => x.Id);
            return await query.ProjectTo<ChatResponse>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}