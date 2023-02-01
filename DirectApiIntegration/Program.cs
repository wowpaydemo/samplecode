var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvcCore();

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseRouting();

app.UseStaticFiles();

app.MapControllerRoute(name: "default", pattern: "{controller=CheckOut}/{action=CheckOut}");

app.Run();
