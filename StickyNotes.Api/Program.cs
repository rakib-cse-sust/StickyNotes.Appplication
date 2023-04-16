using StickyNotes.Api;

var builder = WebApplication.CreateBuilder(args);

var app = builder
       .ConfigureServices()
       .ConfigurePipeline();

// Delete the database then run migration
await app.ResetDatabaseAsync();

app.Run();

