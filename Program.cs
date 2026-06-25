var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();
var app = builder.Build();

app.UseCors(policy => policy
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

List<ScoreEntry> scores = new();

app.MapPost("/score", (ScoreEntry data) =>
{
    scores.Add(data);
    Console.WriteLine($"Score received: {data.playerName} - {data.score}");
});

app.MapGet("/leaderboard", () =>
{
    return scores
        .OrderByDescending(s => s.score)
        .Take(5);
});

app.Run();

record ScoreEntry(string playerName, int score);