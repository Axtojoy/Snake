using Microsoft.EntityFrameworkCore;
using Snake.DAL;
using Snake.DAL.Repositories;
using Snake.Domain.Repositories.Abstract;
using Snake.Logic;
using Snake.PostgresMigrate;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddScoped<GameService>();
var connectionStringEF = builder.Configuration.GetConnectionString("NpgsqlConnectionString");
PostgresMigrator.Migrate(connectionStringEF);

builder.Services.AddDbContext<PostgreeContext>(
    options => options.UseNpgsql(connectionStringEF));
builder.Services.AddScoped<IGameRepositories, GamePostgreeRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Game}/{action=Game}/{id?}");

app.Run();
