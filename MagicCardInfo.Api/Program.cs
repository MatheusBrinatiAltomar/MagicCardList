using MagicCardInfo.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Register Infrastructure Layer (Database, Repositories)
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();
app.Run();

//to run database locally -> sqlcmd -S DESKTOP-GEK05PA\SQLEXPRESS -E
