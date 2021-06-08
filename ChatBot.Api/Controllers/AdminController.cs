using System.Collections.Generic;
using System.Threading.Tasks;
using ChatBot.Api.Dto;
using ChatBot.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChatBot.Api.Controllers
{
    /// <summary>
    /// This is admin controller, use for manage database, like list possible responses, remove or add.
    /// Use api key to authenticate, to simplify same authentication scheme as AI service.
    /// </summary>
    [ApiController]
    [Route("[controller]/responses")]
    [Authorize("Admin")]
    public class AdminController : Controller
    {
        private readonly IResponsesAdminDb _responsesAdminDb;

        public AdminController(IResponsesAdminDb responsesAdminDb)
        {
            _responsesAdminDb = responsesAdminDb;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int start = 0, int pageSize = 10, string intent = null)
        {
            List<ChatResponse> responses = await _responsesAdminDb.GetResponses(start, pageSize, intent);
            return Ok(responses);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateResponseModel request)
        {
            long generatedId = await _responsesAdminDb.AddResponsesForIntent(request.Intent, request.Response);
            return Ok(generatedId);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            await _responsesAdminDb.DeleteResponse(id);
            return Ok();
        }
    }
}