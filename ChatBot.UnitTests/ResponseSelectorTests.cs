using System;
using System.Threading.Tasks;
using ChatBot.Api.Common;
using ChatBot.Api.Dto;
using ChatBot.Api.Logic;
using ChatBot.Domain;
using Moq;
using Xunit;

namespace ChatBot.UnitTests
{
    public class ResponseSelectorTests
    {
        [Fact]
        public async Task SuccessTest()
        {
            var responsesDb = new Mock<IResponsesDb>();
            responsesDb.Setup(x => x.GetResponsesForIntent("greeting")).ReturnsAsync(() => new[] {"Hello"});
            var responseSelector =
                new ResponseSelector(new AppSettings() {DefaultResponse = "I'm Test", PredictionThreshold = 0.8},
                    responsesDb.Object);
            string response = await responseSelector.ChooseResponse(new[]
            {
                new Intent() {Confidence = 0.4, Name = "nothing"},
                new Intent() {Confidence = 0.7, Name = "Something"},
                new Intent() {Confidence = 0.9, Name = "greeting"}
            });

            Assert.Equal("Hello", response);
        }

        [Fact]
        public async Task SuccessOneOfResponsesTest()
        {
            var possibleResponses = new[] {"Hello", "Yello", "Hola"};
            var responsesDb = new Mock<IResponsesDb>();
            responsesDb.Setup(x => x.GetResponsesForIntent("greeting"))
                .ReturnsAsync(() => possibleResponses);
            var responseSelector =
                new ResponseSelector(new AppSettings() {DefaultResponse = "I'm Test", PredictionThreshold = 0.8},
                    responsesDb.Object);
            string response = await responseSelector.ChooseResponse(new[]
            {
                new Intent() {Confidence = 0.4, Name = "nothing"},
                new Intent() {Confidence = 0.7, Name = "Something"},
                new Intent() {Confidence = 0.9, Name = "greeting"}
            });

            Assert.Contains(response, possibleResponses);
        }
        
        [Fact]
        public async Task MissingIntentTest()
        {
            var possibleResponses = new[] {"Hello", "Yello", "Hola"};
            var responsesDb = new Mock<IResponsesDb>();
            responsesDb.Setup(x => x.GetResponsesForIntent("greeting"))
                .ReturnsAsync(() => possibleResponses);
            var responseSelector =
                new ResponseSelector(new AppSettings() {DefaultResponse = "Default response", PredictionThreshold = 0.8},
                    responsesDb.Object);
            string response = await responseSelector.ChooseResponse(new[]
            {
                new Intent() {Confidence = 0.4, Name = "nothing"},
                new Intent() {Confidence = 0.7, Name = "Something"},
                new Intent() {Confidence = 0.9, Name = "anything"}
            });

            Assert.Equal("Default response",response);
        }
        
        [Fact]
        public async Task AiBelowThresholdTest()
        {
            var possibleResponses = new[] {"Hello", "Yello", "Hola"};
            var responsesDb = new Mock<IResponsesDb>();
            responsesDb.Setup(x => x.GetResponsesForIntent("greeting"))
                .ReturnsAsync(() => possibleResponses);
            var responseSelector =
                new ResponseSelector(new AppSettings {DefaultResponse = "Default response", PredictionThreshold = 0.8},
                    responsesDb.Object);
            string response = await responseSelector.ChooseResponse(new[]
            {
                new Intent {Confidence = 0.4, Name = "nothing"},
                new Intent {Confidence = 0.7, Name = "Something"},
                new Intent {Confidence = 0.65, Name = "greeting"}
            });

            Assert.Equal("Default response",response);
        }
    }
}