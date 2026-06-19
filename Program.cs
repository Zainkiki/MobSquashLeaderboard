var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<int> scores = new();

app.MapPost("/score", (ScoreData data) =>
{
    scores.Add(data.score);
    Console.WriteLine("Score received: " + data.score);
    return scores;
});

app.MapGet("/scores", () =>
{
    return scores;
});

app.Run();

record ScoreData(string playerName, int score);