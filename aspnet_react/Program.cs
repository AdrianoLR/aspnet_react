using aspnet_react.Models;
using Supabase;
using MediatR;
using aspnet_react.Controllers;
using aspnet_react.DataStore;
using aspnet_react.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<MoviesStore>();

// Configure Supabase
var url = AppConfig.SUPABASE_URL;
var key = AppConfig.SUPABASE_KEY;

builder.Services.AddSingleton(provider => new Supabase.Client(url, key, new SupabaseOptions
{
    AutoRefreshToken = true,
    AutoConnectRealtime = true,
}));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

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
