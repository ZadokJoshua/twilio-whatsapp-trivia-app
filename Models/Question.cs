namespace TwilioWhatsAppTriviaApp.Models;

public class Question
{
    public string QuestionText { get; set; }
    public List<(string option, bool isCorrect)> Options { get; set; }
}