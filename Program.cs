using Microsoft.EntityFrameworkCore;
using Minimal;
using Minimal.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("Training"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(config =>
{
    config.DocumentName = "WorkoutAPI";
    config.Title = "WorkoutAPI v1";
    config.Version = "v1";
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi(config =>
    {
        config.DocumentTitle = "WorkoutAPI";
        config.Path = "/swagger";
        config.DocumentPath = "/swagger/{documentName}/swagger.json";
        config.DocExpansion = "list";
    });
}

app.MapGet("/", () => "Hello World!");

app.MapGet("/workoutitems", async (AppDbContext db) =>
    await db.Workouts.ToListAsync());

app.MapPost("/workoutitems", async (Workout workout, AppDbContext db) =>
{
    db.Workouts.Add(workout);
    await db.SaveChangesAsync();

    return Results.Created($"/todoitems/{workout.Id}", workout);
});

app.Run();
