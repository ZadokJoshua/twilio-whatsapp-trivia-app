using Newtonsoft.Json;

namespace TwilioWhatsAppTriviaApp.Models;

public class TriviaApiResponse
{
    [JsonProperty("category")]
    public string Category { get; set; }

    [JsonProperty("correctAnswer")]
    public string CorrectAnswer { get; set; }

    [JsonProperty("incorrectAnswers")]
    public List<string> IncorrectAnswers { get; set; }

    [JsonProperty("question")]
    public string Question { get; set; }

    [JsonProperty("type")]
    public string? Type { get; set; }

    [JsonProperty("difficulty")]
    public string Difficulty { get; set; }
}

