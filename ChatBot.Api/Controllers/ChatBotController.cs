using System.Threading.Tasks;
using ChatBot.Api.Dto;
using ChatBot.Api.Logic;
using Microsoft.AspNetCore.Mvc;

namespace ChatBot.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatBotController : ControllerBase
    {
        private readonly IAiClient _aiClient;
        private readonly IResponseSelector _responseSelector;

        public ChatBotController(IAiClient aiClient, IResponseSelector responseSelector)
        {
            _aiClient = aiClient;
            _responseSelector = responseSelector;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AiRequest request)
        {
            AiResponse aiResponse = await _aiClient.GetAiPredictions(request);
            if (aiResponse.Intents == null)
                return StatusCode(500, aiResponse.Error);
            string response = await _responseSelector.ChooseResponse(aiResponse.Intents);
            return Ok(new ChatBotResponse {Message = response});
        }
    }
}