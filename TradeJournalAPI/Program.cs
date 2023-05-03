using TradeJournalAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TradeJournalAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<TradeJournalDBSettings>(
    builder.Configuration.GetSection(nameof(TradeJournalDBSettings)));

builder.Services.AddSingleton<ITradeJournalDBSettings>(
    db => db.GetRequiredService<IOptions<TradeJournalDBSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(
    s => new MongoClient(builder.Configuration.GetValue<string>("TradeJournalDBSettings:ConnectionString")));

builder.Services.AddScoped<IWeeklyScanService, WeeklyScanService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
