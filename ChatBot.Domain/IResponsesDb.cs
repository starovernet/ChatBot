using System.Threading.Tasks;

namespace ChatBot.Domain
{
    /// <summary>
    /// This is common db interface, can implement any database to access data,
    /// to add another data access layer just add another project and add implementation of this interface
    /// </summary>
    public interface IResponsesDb
    {
        ValueTask<string[]> GetResponsesForIntent(string intent);
    }
}