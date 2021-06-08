using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatBot.Api.Common;
using ChatBot.Api.Dto;
using ChatBot.Domain;

namespace ChatBot.Api.Logic
{
    public interface IResponseSelector
    {
        public Task<string> ChooseResponse(IReadOnlyCollection<Intent> intents);
    }

    internal class ResponseSelector : IResponseSelector
    {
        private readonly IResponsesDb _responsesDb;
        private readonly AppSettings _settings;
        private readonly Random _random;

        public ResponseSelector(AppSettings settings, IResponsesDb responsesDb)
        {
            _settings = settings;
            _responsesDb = responsesDb;
            _random = new Random();
        }

        public async Task<string> ChooseResponse(IReadOnlyCollection<Intent> intents)
        {
            Intent intent = intents
                .Where(x => x.Confidence > _settings.PredictionThreshold)
                .OrderByDescending(x => x.Confidence)
                .FirstOrDefault();
            if (intent == null)
                return _settings.DefaultResponse;

            string[] responses = await _responsesDb.GetResponsesForIntent(intent.Name);
            if (responses == null)
                return _settings.DefaultResponse;
            return responses.Length == 1
                ? responses[0]
                : responses[_random.Next(responses.Length - 1)];
        }
    }
}