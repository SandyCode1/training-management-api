//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();





//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllers();

//// Keep your existing configuration registrations.

//// Register health check services
//builder.Services.AddHealthChecks();

//var app = builder.Build();

//app.UseHttpsRedirection();

//app.MapControllers();

//// Expose a health check endpoint
//app.MapHealthChecks("/health");

//app.Run();




using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using TrainingManagement.API.HealthChecks;
using TrainingManagement.API.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.Configure<TrainingSettings>(
    builder.Configuration.GetSection("TrainingSettings"));

// Shared simulation state
builder.Services.AddSingleton<DependencyState>();

// Register the custom readiness check
builder.Services.AddHealthChecks()
    .AddCheck<DatabaseReadinessCheck>(
        "database",
        tags: new[] { "ready" });

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

// Combined health checks
app.MapHealthChecks("/health");

// Liveness: don't execute dependency checks
app.MapHealthChecks("/health/live",
    new HealthCheckOptions
    {
        Predicate = _ => false
    });

// Readiness: execute checks tagged "ready"
app.MapHealthChecks("/health/ready",
    new HealthCheckOptions
    {
        Predicate = check =>
            check.Tags.Contains("ready")
    });


if (app.Environment.IsDevelopment())
{
    app.MapPost("/dev/database-status/{available:bool}",
        (bool available, DependencyState state) =>
        {
            state.DatabaseAvailable = available;

            return Results.Ok(new
            {
                DatabaseAvailable = state.DatabaseAvailable
            });
        });
}

app.Run();
