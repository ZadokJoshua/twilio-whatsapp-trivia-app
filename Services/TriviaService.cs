using Newtonsoft.Json;
using TwilioWhatsAppTriviaApp.Models;

namespace TwilioWhatsAppTriviaApp.Services;

public class TriviaService
{
    private const string TheTriviaApiUrl = @"https://the-trivia-api.com/api/questions?limit=3";

    public async Task<IEnumerable<TriviaApiResponse>> GetTrivia()
    {
        using var client = new HttpClient();
        var response = await client.GetAsync(TheTriviaApiUrl);
        var triviaJson = await response.Content.ReadAsStringAsync();
        var trivia = JsonConvert.DeserializeObject<IEnumerable<TriviaApiResponse>>(triviaJson);

        return trivia;
    }

    public List<Question> ConvertTriviaToQuestions(IEnumerable<TriviaApiResponse> questions)
    {
        List<Question> newQuestions = new();

        foreach (var question in questions)
        {
            var options = new List<(string option, bool isCorrect)>()
            {
                (question.CorrectAnswer, true),
                (question.IncorrectAnswers[0], false),
                (question.IncorrectAnswers[1], false),
                (question.IncorrectAnswers[2], false)
            };

            // Shuffle the options randomly
            Random random = new();
            options = options.OrderBy(_ => random.Next()).ToList();

            newQuestions.Add(new Question { QuestionText = question.Question, Options = options });
        }

        return newQuestions;
    }
}