using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using BlazorApp1.Server.Repository;
using BlazorApp1.Server.Repository.Interfaces;
using BlazorApp1.Shared;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddSingleton<IMongoClient>(s =>
    new MongoClient(Environment.GetEnvironmentVariable("MongoDbSettings__ConnectionString")));
builder.Services.AddScoped<IMongoDatabase>(s =>
{
    var mongoClient = s.GetRequiredService<IMongoClient>();
    return mongoClient.GetDatabase("DiscordClone");
});
builder.Services.AddScoped<IRepository<User>, UserRepository>();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
Console.WriteLine($"Here's the MongoDb connection string: {Environment.GetEnvironmentVariable("MongoDbSettings__ConnectionString")}");


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
