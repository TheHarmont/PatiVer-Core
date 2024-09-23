using PatiVerCore.Application.Extensions;
using PatiVerCore.Infrastructure.Extensions;

try
{
    var builder = WebApplication.CreateBuilder(args);
    var app = builder.Build();

    // Add services to the container.
    builder.Services.AddApplicationLayer();
    builder.Services.AddInfrastructureLayer();
    builder.Services.AddPersistenceLayer(builder.Configuration);

    app.MapGet("/", () => "Hello World!");

    app.Run();
}
catch (Exception)
{

	throw;
}

