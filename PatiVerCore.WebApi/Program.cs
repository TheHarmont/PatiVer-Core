using NLog;
using NLog.Web;
using PatiVerCore.Application.Extensions;
using PatiVerCore.Infrastructure.Extensions;
using PatiVerCore.Persistence.Extensions;

var logger = NLog.LogManager.Setup()
        .LoadConfigurationFromAppSettings()
        .GetCurrentClassLogger();
try
{
    logger.Debug("������ ����������");

    var builder = WebApplication.CreateBuilder(args);

    builder.Configuration.AddJsonFile("appsettings.Development.json");

    // ��������� ������
    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel
            (Microsoft.Extensions.Logging.LogLevel.Trace);
    builder.Host.UseNLog();

    // Add services to the container.
    builder.Services.AddApplicationLayer();
    builder.Services.AddInfrastructureLayer(builder.Configuration);
    builder.Services.AddPersistenceLayer(builder.Configuration);

    var app = builder.Build();

    app.MapGet("/", () => "Hello World!");

    app.Run();
}
catch (Exception)
{

	throw;
}

