using Microsoft.EntityFrameworkCore;
using MyMoviesApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add in-memory database
builder.Services.AddDbContext<MovieContext>(options =>
    options.UseInMemoryDatabase("MoviesDB"));

var app = builder.Build();

// Seed the database
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<MovieContext>();
    context.Movies.AddRange(
        new MyMoviesApp.Models.Movie { Title = "Inception", Genre = "Sci-Fi", ReleaseYear = 2010, Price = 9.99m },
        new MyMoviesApp.Models.Movie { Title = "The Dark Knight", Genre = "Action", ReleaseYear = 2008, Price = 12.99m },
        new MyMoviesApp.Models.Movie { Title = "Interstellar", Genre = "Sci-Fi", ReleaseYear = 2014, Price = 14.99m },
        // Add your 3 favorite movies
        new MyMoviesApp.Models.Movie { Title = "Your Movie 1", Genre = "Genre1", ReleaseYear = 2022, Price = 11.99m },
        new MyMoviesApp.Models.Movie { Title = "Your Movie 2", Genre = "Genre2", ReleaseYear = 2021, Price = 10.99m },
        new MyMoviesApp.Models.Movie { Title = "Your Movie 3", Genre = "Genre3", ReleaseYear = 2019, Price = 13.99m }
    );
    context.SaveChanges();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movies}/{action=Index}/{id?}");

app.Run();
