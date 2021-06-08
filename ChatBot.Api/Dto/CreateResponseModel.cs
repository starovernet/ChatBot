using System.ComponentModel.DataAnnotations;

namespace ChatBot.Api.Dto
{
    public record CreateResponseModel
    {
        [Required] public string Intent { get; set; }
        [Required] public string Response { get; set; }
    }
}