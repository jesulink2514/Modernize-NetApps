using CoreWCF;
using CoreWCF.Configuration;
using CoreWCF.Description;
using LegacySOAP;
using LegacySOAP.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel((context, options) =>
{
    options.AllowSynchronousIO = true;
});

//Add EF
var conn = builder.Configuration.GetConnectionString("Legacy");
builder.Services.AddScoped(sp => new LegacyDbContext(conn));

builder.Services.AddScoped<LegacyService>();

// Add WSDL support
builder.Services.AddServiceModelServices().AddServiceModelMetadata();
builder.Services.AddSingleton<IServiceBehavior, UseRequestHeadersForMetadataAddressBehavior>();

var app = builder.Build();
app.UseServiceModel(serviceModel =>
{
    serviceModel.AddService<LegacyService>((serviceOptions) => {
        serviceOptions.DebugBehavior.IncludeExceptionDetailInFaults = true;
        serviceOptions.DebugBehavior.HttpHelpPageEnabled = true;
    })
    // Add a BasicHttpBinding at a specific endpoint
    .AddServiceEndpoint<LegacyService, ILegacyService>(new BasicHttpBinding(), "/LegacyService.svc");
});

var serviceMetadataBehavior = app.Services.GetRequiredService<CoreWCF.Description.ServiceMetadataBehavior>();
serviceMetadataBehavior.HttpGetEnabled = true;

app.Run();