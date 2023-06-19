using aspnet_react.Models;
using Supabase;
using MediatR;
using aspnet_react.Controllers;
using aspnet_react.DataStore;
using Microsoft.Extensions.Configuration;
using aspnet_react.Behaviors;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<MoviesStore>();
builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
// Configure Supabase
string apiKey = builder.Configuration["SUPABASE_KEY"];
string url = builder.Configuration["SUPABASE_URL"];

builder.Services.AddScoped(provider => new Supabase.Client(url, apiKey, new SupabaseOptions
{
    AutoRefreshToken = true,
    AutoConnectRealtime = true,
}));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();

    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");
app.MapFallbackToFile("index.html");



app.UseHttpsRedirection();
app.Run();
