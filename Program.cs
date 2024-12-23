using Microsoft.EntityFrameworkCore;
using Clima.Services;
using Clima.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<WeatherService>(provider =>

{
    var configuration = provider.GetRequiredService<IConfiguration>();
    return new WeatherService(configuration["OpenWeatherMap:ApiKey"]);
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddRazorPages();

builder.Services.AddSession();

var app = builder.Build();

app.UseSession();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
.WithStaticAssets();

app.MapControllers();

await app.RunAsync();