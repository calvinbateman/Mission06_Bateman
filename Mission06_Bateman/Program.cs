using Microsoft.EntityFrameworkCore;
using Mission06_Bateman.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Use SQLite DB in project directory (not dependent on working directory)
var conn = builder.Configuration.GetConnectionString("MovieConnection");
var dbFileName = string.IsNullOrEmpty(conn) ? "JoelHiltonMovieCollection.sqlite" : conn.Replace("Data Source=", "").Trim();
var dbPath = Path.Combine(builder.Environment.ContentRootPath, dbFileName);
builder.Services.AddDbContext<MovieCollectionContext>(options =>
    options.UseSqlite($"Data Source={dbPath}"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();