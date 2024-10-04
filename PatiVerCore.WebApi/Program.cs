using CoreWCF.Configuration;
using CoreWCF.Description;
using NLog;
using NLog.Config;
using NLog.LayoutRenderers;
using NLog.Web;
using PatiVerCore.Application.Extensions;
using PatiVerCore.Infrastructure.Extensions;
using PatiVerCore.Persistence.Extensions;
using PatiVerCore.WebApi.LayoutRenderers;
using PatiVerCore.WebApi.WCFService;

//Загружаем кастомные классы для Nlog
LogManager.Setup().SetupExtensions(s =>
{
    s.RegisterLayoutRenderer<RequestIpLR>("request-ip");
    s.RegisterLayoutRenderer<TraceIdentifierLR>("trace-identifier");
    s.RegisterLayoutRenderer<RequestMethodLR>("request-method");
    s.RegisterLayoutRenderer<RequestEndpointLR>("request-endpoint");
});

LogManager.Configuration = new XmlLoggingConfiguration("nlog.config");
var logger = NLog.LogManager
    .Setup()
    .LoadConfigurationFromAppSettings()
    .GetCurrentClassLogger();
try
{
    logger.Debug("Запуск приложения");

    var builder = WebApplication.CreateBuilder(args);

    builder.Configuration.AddJsonFile("appsettings.Development.json");

    //Добавляем логгер
    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel
            (Microsoft.Extensions.Logging.LogLevel.Trace);
    builder.Host.UseNLog();

    builder.Services.AddHttpContextAccessor();

    builder.Services.AddServiceModelServices();
    builder.Services.AddServiceModelMetadata();
    builder.Services.AddSingleton<IServiceBehavior, UseRequestHeadersForMetadataAddressBehavior>();

    // Add services to the container.
    builder.Services.AddApplicationLayer();
    builder.Services.AddInfrastructureLayer(builder.Configuration);
    builder.Services.AddPersistenceLayer(builder.Configuration);

    builder.Services.AddTransient<WcfService>();

    var app = builder.Build();

    app.UseServiceModel(serviceBuilder =>
    {
        serviceBuilder.AddService<WcfService>();
        serviceBuilder.AddServiceEndpoint<WcfService, IWcfService>(new CoreWCF.BasicHttpBinding(CoreWCF.Channels.BasicHttpSecurityMode.None)
        {
            OpenTimeout = TimeSpan.FromSeconds(5),
            CloseTimeout = TimeSpan.FromSeconds(5),
            SendTimeout = TimeSpan.FromSeconds(5),
            ReceiveTimeout = TimeSpan.FromSeconds(5)
        }, "/PatiVerWcf.svc");
        var serviceMetadataBehavior = app.Services.GetRequiredService<ServiceMetadataBehavior>();
        serviceMetadataBehavior.HttpGetEnabled = true;
        serviceMetadataBehavior.HttpsGetEnabled = true;
    });

    app.MapGet("/", () => "Приветик!");

    logger.Debug("Приложение запущено");

    app.Run();
}
catch (Exception ex)
{
    logger.Error(ex, $"Остановлено из-за исключения: {ex.Message}");
    throw;
}
finally
{
    NLog.LogManager.Shutdown();
}

