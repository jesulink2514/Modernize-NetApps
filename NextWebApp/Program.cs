using Microsoft.EntityFrameworkCore;
using NextWebApp.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("LegacyDb");
builder.Services.AddDbContext<NextDbContext>(opts => opts.UseSqlServer(connectionString));

builder.Services.AddMvc(opts => opts.EnableEndpointRouting = false);

var proxyBuilder = builder.Services.AddReverseProxy();
proxyBuilder.LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();

app.UseStaticFiles();

app.UseMvcWithDefaultRoute();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapReverseProxy();
});

app.Run();
