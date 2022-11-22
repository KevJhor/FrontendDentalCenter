using FrontendDentalCenter.Areas.Medico.Controllers;
using FrontendDentalCenter.Controllers;
using FrontendDentalCenter.Helpers;
using FrontendDentalCenter.Providers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<PathProvider>();
builder.Services.AddSingleton<HelperUploadFiles>();
//builder.Services.AddTransient

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Security}/{action=Login}/{id?}");

app.Run();
