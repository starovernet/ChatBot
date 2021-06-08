using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatBot.Domain
{
    public interface IResponsesAdminDb
    {
        Task<long> AddResponsesForIntent(string intent, string response);
        Task<bool> DeleteResponse(long id);
        Task<List<ChatResponse>> GetResponses(int start, int pageSize, string intent = null);
    }
}