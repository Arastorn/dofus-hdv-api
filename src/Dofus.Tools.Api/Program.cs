using Autofac;
using Autofac.Extensions.DependencyInjection;
using Dofus.Hdv.Api.Modules;
using Dofus.Hdv.Infrastructure;
using Serilog;

var configuration = new ConfigurationBuilder()
   .SetBasePath(Directory.GetCurrentDirectory())
   .AddJsonFile("appsettings.json", false, true)
   .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", true)
   .AddEnvironmentVariables()
   .Build();

Log.Logger = new LoggerConfiguration()
   .ReadFrom.Configuration(configuration)
   .Enrich.FromLogContext()
   .Enrich.WithMachineName()
   .Enrich.WithProcessId()
   .Enrich.WithProcessName()
   .Enrich.WithThreadId()
   .Enrich.WithThreadName()
   .WriteTo.Debug()
   .WriteTo.Console()
   .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();
builder.Services.AddPersistence(Environment.GetEnvironmentVariable("ConnectionStrings__AppDatabase")!);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(b =>
{
   b.RegisterUseCases(configuration);
   b.RegisterPersistence();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
   app.UseVersionedOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();